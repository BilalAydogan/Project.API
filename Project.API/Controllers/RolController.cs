using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Project.Model;
using Project.Repository;
using Newtonsoft.Json.Linq;
using Microsoft.AspNetCore.Authorization;

namespace Project.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolController : BaseController
    {
        public RolController(RepositoryWrapper repo) : base(repo)
        {
        }
        
        [HttpGet("AllRol/{limit}")]
        public dynamic AllRol(int limit)
        {
            List<Rol> items = repo.RolRepository.FindAll().Take(limit).ToList<Rol>();
            return new
            {
                success = true,
                data = items,
            };
        }
        [HttpPost("Save")]

        public dynamic Save([FromBody] dynamic model)
        {
            dynamic json = JObject.Parse(model.GetRawText());
            Rol item = new Rol()
            {
                Id = json.Id,
                Name = json.Name
            };

            if (string.IsNullOrEmpty(item.Name))
            {
                return new
                {
                    success = false,
                    message = "Name cannot be null.",
                };
            }
            if (item.Name.Length > 20)
            {
                return new
                {
                    success = false,
                    message = "Name must be less than 20 character",
                };
            }
            if (item.Id > 0)
            {
                repo.RolRepository.Update(item);
            }
            else
            {
                repo.RolRepository.Create(item);
            }

            repo.SaveChanges();
            return new
            {
                success = true
            };
        }
        [HttpDelete("Delete")]
        public dynamic Delete(int id)
        {
            if (id <= 0)
            {
                return new
                {
                    success = false,
                    message = "Invalid id"
                };
            }

            repo.RolRepository.DeleteRol(id);
            return new
            {
                success = true
            };

        }
    }
}

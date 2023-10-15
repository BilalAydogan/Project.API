using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using Project.Model;
using Project.Repository;
using System.Linq;

namespace Project.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StorageController : BaseController
    {
        public StorageController(RepositoryWrapper repo) : base(repo)
        {
        }
        [HttpGet("AllStorage")]
        public dynamic AllStorage()
        {
            List<Storage> items = repo.StorageRepository.FindAll().ToList<Storage>();
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
            Storage item = new Storage()
            {
                Id = json.Id,
                Name = json.Name,
                CompanyId = json.CompanyId,
                Description = json.Description,
                Amount = json.Amount,
                EntryDate = json.EntryDate
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
                repo.StorageRepository.Update(item);
            }
            else
            {
                repo.StorageRepository.Create(item);
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

            repo.StorageRepository.DeleteStorage(id);
            return new
            {
                success = true
            };

        }
    }
}

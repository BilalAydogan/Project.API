using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using Project.Model;
using Project.Repository;
using System.Linq;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Project.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HoldingController : BaseController
    {
        public HoldingController(RepositoryWrapper repo) : base(repo)
        {
        }
        [HttpPost("Save")]

        public dynamic Save([FromBody] dynamic model)
        {
            dynamic json = JObject.Parse(model.GetRawText());
            Company item = new Company()
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
            if (item.Name.Length > 50)
            {
                return new
                {
                    success = false,
                    message = "Name must be less than 50 character",
                };
            }
            if (item.Id > 0)
            {
                repo.CompanyRepository.Update(item);
            }
            else
            {
                repo.CompanyRepository.Create(item);
            }

            repo.SaveChanges();
            return new
            {
                success = true
            };
        }
        [HttpGet("AllHolding")]
        public dynamic AllHolding()
        {
            List<Company> items = repo.CompanyRepository.FindAll().ToList<Company>();
            return new
            {
                success = true,
                data = items,
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

            repo.CompanyRepository.DeleteCompany(id);
            return new
            {
                success = true
            };

        }
    }
}

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
    public class RequestController : BaseController
    {
        public RequestController(RepositoryWrapper repo) : base(repo)
        {
        }
        [HttpGet("AllRequest")]
        public dynamic AllRequest()
        {
            List<Request> items = repo.RequestRepository.FindAll().ToList<Request>();
            return new
            {
                success = true,
                data = items,
            };
        }
        [HttpGet("RequestById/{id}")]
        public dynamic RequestById(int id)
        {
            List<Request> items = repo.RequestRepository.FindByCondition(a => a.UserId == id).ToList<Request>();
            return new
            {
                success = true,
                data = items
            };
        }
        [HttpPost("Save")]

        public dynamic Save([FromBody] dynamic model)
        {
            dynamic json = JObject.Parse(model.GetRawText());
            Request item = new Request()
            {
                Id = json.Id,
                Name = json.Name,
                Description = json.Description,
                Amount = json.Amount,
                UserId = json.UserId
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
                repo.RequestRepository.Update(item);
            }
            else
            {
                repo.RequestRepository.Create(item);
            }

            repo.SaveChanges();
            return new
            {
                success = true
            };
        }
    }
}

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using Project.Model;
using Project.Repository;

namespace Project.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OfferController : BaseController
    {
        public OfferController(RepositoryWrapper repo) : base(repo)
        {
        }
        [HttpPost("Save")]
        public dynamic Save([FromBody] dynamic model)
        {
            dynamic json = JObject.Parse(model.GetRawText());
            Offer item = new Offer()
            {
                
                Id = json.Id,
                RequestId = json.RequestId,
                UserName = json.UserName,
                Price = json.Price,
                Description = json.Description,
                Status = json.Status,
                OfferDate = json.OfferDate

            };

            if (string.IsNullOrEmpty(item.UserName))
            {
                return new
                {
                    success = false,
                    message = "Name cannot be null.",
                };
            }
            if (item.Id > 0)
            {
                repo.OfferRepository.Update(item);
            }
            else
            {
                repo.OfferRepository.Create(item);
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

            repo.OfferRepository.DeleteOffer(id);
            return new
            {
                success = true
            };

        }
    }
}

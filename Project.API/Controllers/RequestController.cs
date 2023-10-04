using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
    }
}

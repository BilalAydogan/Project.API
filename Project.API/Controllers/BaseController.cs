using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project.Repository;

namespace Project.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        protected RepositoryWrapper repo;

        public BaseController(RepositoryWrapper repo)
        {
            this.repo = repo;
        }
    }
}

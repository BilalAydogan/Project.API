using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using Project.Model;
using Project.Model.Views;
using Project.Repository;

namespace Project.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : BaseController
    {
        public UserController(RepositoryWrapper repo) : base(repo)
        {
        }
        [HttpPost("GetUser")]
        public dynamic GetUser([FromBody] dynamic model)
        {
            dynamic Json = JObject.Parse(model.GetRawText());
            string email = Json.Email;
            string password = Json.Password;
            User item = repo.UserRepository.FindByCondition(u => u.Email == email && u.Password == password).SingleOrDefault<User>();
            if (item != null)
            {
                return new
                {
                    success = true,
                    date = item
                };
            }
            else
            {
                return new
                {
                    success = false,
                    message = "Email or password is incorrect pls try again."
                };
            }
        }
        [HttpGet("AllUsers")]       
        public dynamic AllUsers()
        {
            List<User> items = repo.UserRepository.FindAll().ToList<User>();
            return new
            {
                success = true,
                data = items,
            };
        }
        [HttpGet("AllUs")]
        public dynamic AllUs()
        {
            List<V_User> items = repo.UserRepository.UserOzet().ToList<V_User>();
            return new
            {
                success = true,
                data = items,
            };
        }
        [HttpPost("CreateUser")]
        public dynamic CreateUser([FromBody] dynamic model)
        {
            dynamic json = JObject.Parse(model.GetRawText());
            User item = new User
            {
                Id = json.Id,
                Name = json.Name,
                Surname = json.Surname,
                Email = json.Email,
                Password = json.Password,
                RolId = json.RolId,
                DepartmentId = json.DepartmentId
            };
            if (item.Id > 0)
            {
                repo.UserRepository.Update(item);
            }
            else
            {
                repo.UserRepository.Create(item);
            }
            repo.SaveChanges();
            return new
            {
                success = true
            };
        }
        [HttpDelete("Delete")]
        public dynamic Sil(int id)
        {
            if (id <= 0)
            {
                return new
                {
                    success = false,
                    message = "Invalid Id."
                };
            }

            repo.UserRepository.DeleteUser(id);
            return new
            {
                success = true
            };

        }
    }
}

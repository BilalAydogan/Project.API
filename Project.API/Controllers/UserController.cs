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
                SupervisorId = json.SupervisorId
            };
            if(item.Surname == "" || item.Name == "" || item.Email=="" || item.Password == "")
            {
                
                    return new
                    {
                        success = false,
                        message = "Please fill the inputs..."
                    };
                
            } 
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
        [HttpPost("CreateUserDepartment")]

        public dynamic CreateUserDepartment([FromBody] dynamic model)
        {
            dynamic json = JObject.Parse(model.GetRawText());
            UserDepartment item = new UserDepartment()
            {
                Id = json.Id,
                UserId = json.UserId,
                DepartmentId = json.DepartmentId
            };
            if (item.Id > 0)
            {
                repo.UserDepartmentRepository.Update(item);
            }
            else
            {
                repo.UserDepartmentRepository.Create(item);
            }

            repo.SaveChanges();
            return new
            {
                success = true
            };
        }
        [HttpPost("CreateUserRol")]

        public dynamic CreateUserRol([FromBody] dynamic model)
        {
            dynamic json = JObject.Parse(model.GetRawText());
            UserRol item = new UserRol()
            {
                Id = json.Id,
                UserId = json.UserId,
                RolId = json.RolId
            };
            if (item.Id > 0)
            {
                repo.UserRolRepository.Update(item);
            }
            else
            {
                repo.UserRolRepository.Create(item);
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
        [HttpDelete("DeleteUserDepartment")]
        public dynamic DeleteUserDepartment(int id)
        {
            if (id <= 0)
            {
                return new
                {
                    success = false,
                    message = "Invalid Id."
                };
            }

            repo.UserDepartmentRepository.DeleteUserDepartment(id);
            return new
            {
                success = true
            };

        }
        [HttpDelete("DeleteUserRol")]
        public dynamic DeleteUserRol(int id)
        {
            if (id <= 0)
            {
                return new
                {
                    success = false,
                    message = "Invalid Id."
                };
            }

            repo.UserRolRepository.DeleteUserRol(id);
            return new
            {
                success = true
            };

        }
    }
}

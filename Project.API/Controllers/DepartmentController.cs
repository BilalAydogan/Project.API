using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using Project.Model;
using Project.Model.Views;
using Project.Repository;
using System.Linq;

namespace Project.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : BaseController
    {
        public DepartmentController(RepositoryWrapper repo) : base(repo)
        {
        }
        [HttpPost("Save")]

        public dynamic Save([FromBody] dynamic model)
        {
            dynamic json = JObject.Parse(model.GetRawText());
            Department item = new Department()
            {
                Id = json.Id,
                Name = json.Name,
                CompanyId = json.CompanyId,
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
                repo.DepartmentRepository.Update(item);
            }
            else
            {
                repo.DepartmentRepository.Create(item);
            }

            repo.SaveChanges();
            return new
            {
                success = true
            };
        }
        [HttpGet("AllDepartment")]
        public dynamic AllDeparment()
        {
            List<Department> items = repo.DepartmentRepository.FindAll().ToList<Department>();
            return new
            {
                success = true,
                data = items,
            };
        }
        [HttpGet("DepartmentCompany")]
        public dynamic DepartmentCompany()
        {
            List<V_DepartmentCompany> items = repo.DepartmentRepository.DepartmentCompany();
            return new
            {
                success = true,
                data = items,
            };
        }
        [HttpGet("AllCompany")]
        public dynamic DepartmentByCompId()
        {
            List<Company> items = repo.CompanyRepository.FindAll().ToList<Company>();
            return new
            {
                success = true,
                data = items,
            };
        }
        [HttpGet("DepartmentByCompany/{id}")]
        public dynamic DepartmentByCompany(int id)
        {
            List<Department> items = repo.DepartmentRepository.FindByCondition(x=> x.CompanyId == id).ToList<Department>();
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

            repo.DepartmentRepository.DeleteDepartment(id);
            return new
            {
                success = true
            };

        }
    }
}

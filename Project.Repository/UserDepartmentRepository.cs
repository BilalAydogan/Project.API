using Microsoft.EntityFrameworkCore;
using Project.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Repository
{
    public class UserDepartmentRepository : RepositoryBase<UserDepartment>
    {
        public UserDepartmentRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }
        public void DeleteUserDepartment(int userDepId)
        {
            RepositoryContext.UserDepartments.Where(r => r.Id == userDepId).ExecuteDelete();
        }

    }
}

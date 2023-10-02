using Microsoft.EntityFrameworkCore;
using Project.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Repository
{
    public class DepartmentRepository : RepositoryBase<Department>
    {
        public DepartmentRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }
        public void DeleteDepartment(int departmentId)
        {
            RepositoryContext.Departments.Where(u => u.Id == departmentId).ExecuteDelete();
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Project.Model;
using Project.Model.Views;
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

        public List<V_DepartmentCompany> DepartmentCompany() => RepositoryContext.V_DepartmentOzet.OrderBy(dc => dc.CompanyName).ThenBy(dc => dc.Name).ToList<V_DepartmentCompany>();

    }
}

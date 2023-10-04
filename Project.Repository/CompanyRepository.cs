using Microsoft.EntityFrameworkCore;
using Project.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Repository
{
    public class CompanyRepository : RepositoryBase<Company>
    {
        public CompanyRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }
        public void DeleteCompany(int companyId)
        {
            RepositoryContext.Companies.Where(u => u.Id == companyId).ExecuteDelete();
        }
    }
}

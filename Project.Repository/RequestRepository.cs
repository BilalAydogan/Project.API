using Microsoft.EntityFrameworkCore;
using Project.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Repository
{
    public class RequestRepository : RepositoryBase<Request>
    {
        public RequestRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }
        public void DeleteRequest(int offerId)
        {
            RepositoryContext.Requests.Where(u => u.Id == offerId).ExecuteDelete();
        }
    }
}

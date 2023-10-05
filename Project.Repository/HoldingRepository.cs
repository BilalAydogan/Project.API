using Microsoft.EntityFrameworkCore;
using Project.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Repository
{
    public class HoldingRepository : RepositoryBase<Holding>
    {
        public HoldingRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public void DeleteHolding(int holdingId)
        {
            RepositoryContext.Holdings.Where(r => r.Id == holdingId).ExecuteDelete();
        }
    }
}

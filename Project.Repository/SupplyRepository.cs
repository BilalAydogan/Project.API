using Project.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Repository
{
    public class SupplyRepository : RepositoryBase<Ofer>
    {
        public SupplyRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }
    }
}

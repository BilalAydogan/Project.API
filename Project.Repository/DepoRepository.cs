using Project.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Repository
{
    public class DepoRepository : RepositoryBase<Depo>
    {
        public DepoRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

    }
}

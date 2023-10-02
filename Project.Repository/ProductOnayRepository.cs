using Project.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Repository
{
    public class ProductOnayRepository : RepositoryBase<ProductOnay>
    {
        public ProductOnayRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }
    }
}

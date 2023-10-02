using Project.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Repository
{
    public class ItemRepository : RepositoryBase<Item>
    {
        public ItemRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }
    }
}

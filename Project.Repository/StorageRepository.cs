using Microsoft.EntityFrameworkCore;
using Project.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Repository
{
    public class StorageRepository : RepositoryBase<Storage>
    {
        public StorageRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }
        public void DeleteStorage(int id)
        {
            RepositoryContext.Storages.Where(r => r.Id == id).ExecuteDelete();
        }
    }
}

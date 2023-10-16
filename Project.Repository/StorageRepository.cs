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
    public class StorageRepository : RepositoryBase<Storage>
    {
        public StorageRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }
        public void DeleteStorage(int id)
        {
            RepositoryContext.Storages.Where(r => r.Id == id).ExecuteDelete();
        }
        public List<Storage> StorageByCompId(int id) => RepositoryContext.Storages.Where(x => x.CompanyId == id && x.Amount>0).OrderByDescending(x => x.Id).ToList();
        public List<Storage> UnStorageByCompId(int id) => RepositoryContext.Storages.Where(x => x.CompanyId == id && x.Amount == 0).OrderByDescending(x => x.Id).ToList();

    }
}

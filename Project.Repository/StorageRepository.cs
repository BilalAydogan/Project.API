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
        public List<V_Storage> StorageByCompId(int id) => RepositoryContext.V_Storages.Where(x => x.CompanyId == id).OrderByDescending(x => x.StorageId).ToList();

    }
}

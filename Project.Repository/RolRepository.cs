using Microsoft.EntityFrameworkCore;
using Project.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Repository
{
    public class RolRepository : RepositoryBase<Rol>
    {
        public RolRepository(RepositoryContext context) : base(context)
        {
        }
        public void DeleteRol(int rolId)
        {
            RepositoryContext.Roller.Where(r => r.Id == rolId).ExecuteDelete();
        }
    }
}

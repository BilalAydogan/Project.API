using Project.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.Model.Views;

namespace Project.Repository
{
    public class UserRepository : RepositoryBase<User>
    {
        public UserRepository(RepositoryContext context) : base(context)
        {

        }
        public void DeleteUser(int userId)
        {
            RepositoryContext.Users.Where(u => u.Id == userId).ExecuteDelete();
        }
        public List<V_User> UserOzet() => RepositoryContext.V_Users.ToList<V_User>();
    }
}
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
    public class RepositoryContext : DbContext
    {
        public RepositoryContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Depo> Depos { get; set; }
        public DbSet<Rol> Roller { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Request> Requests { get; set; }
        public DbSet<RequestOnay> RequesttOnays { get; set; }
        public DbSet<RequestSupply> RequestSupplies { get; set; }
        public DbSet<Supply> Supplies { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Holding> Holdings { get; set; }
        public DbSet<V_User> V_Users { get; set; }
    }
}

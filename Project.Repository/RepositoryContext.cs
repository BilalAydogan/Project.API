using Microsoft.EntityFrameworkCore;
using Project.Model;
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
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductOnay> ProductOnays { get; set; }
        public DbSet<ProductSupply> ProductSupplies { get; set; }
        public DbSet<Supply> Supplies { get; set; }
        public DbSet<Department> Departments { get; set; }
    }
}

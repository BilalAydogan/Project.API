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
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<V_User>().HasNoKey();
            modelBuilder.Entity<V_Offer>().HasNoKey();
            modelBuilder.Entity<V_Purchasing>().HasNoKey();
            modelBuilder.Entity<V_Storage>().HasNoKey();
        }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Offer> Offers { get; set; }
        public DbSet<Request> Requests { get; set; }
        public DbSet<Rol> Roller { get; set; }
        public DbSet<Storage> Storages { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserDepartment> UserDepartments { get; set; }
        public DbSet<UserRol> UserRols { get; set; }
        public DbSet<V_User> V_Users { get; set; }
        public DbSet<V_Offer> V_Offers { get; set; }
        public DbSet<V_Purchasing> V_Purchasings { get; set; }
        public DbSet<V_Storage> V_Storages { get; set; }
        public DbSet<V_DepartmentCompany> V_DepartmentOzet { get; set; }
    }
}

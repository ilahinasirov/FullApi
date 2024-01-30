using Core.Enums;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete.EntityFramework.Contexts
{
    public class ProjectContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-JN80QO8\SQLEXPRESS;Database=ProjectApi;Trusted_Connection=true");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasQueryFilter(m=> !m.IsDeleted);
            modelBuilder.Entity<Role>().HasData(
                new Role()
                {
                    Id = 1,
                    Key=ERole.admin.ToString(),
                    Name="ADMIN"
                },
                new Role()
                {
                    Id = 2,
                    Key=ERole.user.ToString(),
                    Name="USER"
                },
                new Role()
                {
                    Id = 3,
                    Key=ERole.superadmin.ToString(),
                    Name="SUPERADMIN"
                }
                );
        }
        /*
        dotnet tool install --global dotnet-ef
        dotnet ef migrations add InitialCreate
        dotnet ef database update
        */
        DbSet<User> Users { get; set; }
        DbSet<Role> Roles { get; set; }
    }
}

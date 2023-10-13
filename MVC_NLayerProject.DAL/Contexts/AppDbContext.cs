using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MVC_NLayerProject.CORE.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_NLayerProject.DAL.Contexts
{
    public class AppDbContext : IdentityDbContext<AppUser>
    {
        public DbSet<Article> Articles { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Subject>().HasData(
                    new Subject { Id = 1, SubjectName = "Konu1" },
                    new Subject { Id = 2, SubjectName = "Konu2" },
                    new Subject { Id = 3, SubjectName = "Konu3" }
                );
            base.OnModelCreating(builder);
        }
    }
}

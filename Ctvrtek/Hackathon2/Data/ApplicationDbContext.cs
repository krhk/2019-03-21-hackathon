using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Hackathon2.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Hackathon2.Models.TestModel> TestModel { get; set; }

        public DbSet<Hackathon2.Models.Emergency> Emergency { get; set; }

        public DbSet<Hackathon2.Models.Pharmacies> Pharmacies { get; set; }
    }
}

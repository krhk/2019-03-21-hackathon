using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Hackathon.Models;

namespace Hackathon.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Hackathon.Models.Policie> Policie { get; set; }
        public DbSet<Hackathon.Models.Hasici> Hasici { get; set; }
        public DbSet<Hackathon.Models.Nemocnice> Nemocnice { get; set; }
        public DbSet<Hackathon.Models.Update> Update { get; set; }
        public DbSet<Hackathon.Models.Stomatologie> Stomatologie { get; set; }
        public DbSet<Hackathon.Models.NaslednaPece> NaslednaPece { get; set; }
    }
}

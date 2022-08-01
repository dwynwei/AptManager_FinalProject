using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Models;
using Models.Entities;

namespace DataAccessLayer.DbContexts
{
    public class AptManagerDbContext:DbContext
    {
        private IConfiguration _configuration;

        public AptManagerDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Building> Buildings { get; set; }
        public DbSet<UserPassword> Passwords { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            base.OnConfiguring(builder.UseSqlServer(@"Server=DESKTOP-G0BEQN4\SQLEXPRESS;Database=AptManager;Trusted_Connection=True;"));
        }
    }
}

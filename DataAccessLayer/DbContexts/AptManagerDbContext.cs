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
        public AptManagerDbContext(DbContextOptions options) : base(options)
        {

        }

        public virtual DbSet<User> Users { get; set; } = default!;
        public virtual DbSet<Building> Buildings { get; set; } = default!;
        public virtual DbSet<UserPassword> Passwords { get; set; } = default!;

        //protected override void OnConfiguring(DbContextOptionsBuilder builder)
        //{
        //    var connectionString = _configuration.GetConnectionString("MsSql");
        //    base.OnConfiguring(builder.UseSqlServer(connectionString));
        //}
    }
}

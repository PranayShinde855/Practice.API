using API.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Database
{
    public class DbModelContext : DbContext
    {
        public DbModelContext(DbContextOptions options) : base(options)
        {
          //  Database.EnsureCreated();
        }

        public DbSet<Product> products { get; set; }
    }
}

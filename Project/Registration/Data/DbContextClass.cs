using Microsoft.EntityFrameworkCore;
using Registration.Models;

namespace Registration.Data
{
        public class DbContextClass : DbContext
        {
            protected readonly IConfiguration Configuration;

            public DbContextClass(IConfiguration configuration)
            {
                Configuration = configuration;
            }
            protected override void OnConfiguring(DbContextOptionsBuilder options)
            {
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
            }

            public DbSet<Register> Details { get; set; }
        }
    }

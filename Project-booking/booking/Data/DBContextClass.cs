using Microsoft.EntityFrameworkCore;

using booking.Models;

namespace booking.Data
{
    public class DBContextClass:DbContext
    {
        protected readonly IConfiguration Configuration;

        public DBContextClass(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
        }

        public DbSet<Booking> Bookings { get; set; }
    }
}


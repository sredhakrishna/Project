using Microsoft.EntityFrameworkCore;
using ParcelProject.Model;

namespace ParcelProject.Data
{
    public class DbContextClass : DbContext
    {
        public DbContextClass(DbContextOptions<DbContextClass> option) : base(option)
        {

        }
        public DbSet<AdminUser> ADMIN_USER { get; set; }
    }
}

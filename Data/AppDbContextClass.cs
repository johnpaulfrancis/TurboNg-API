using Microsoft.EntityFrameworkCore;
using TurboNg_API.Models;

namespace TurboNg_API.Data
{
    public class AppDbContextClass : DbContext
    {
        public AppDbContextClass(DbContextOptions<AppDbContextClass> options) : base(options) 
        { 

        }

        public DbSet<UserEntity> UserMaster { get; set; }
    }
}

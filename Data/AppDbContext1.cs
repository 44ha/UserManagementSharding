using Microsoft.EntityFrameworkCore;
using UserManagementSharding.Models;

namespace UserManagementSharding.Data
{
    public class AppDbContext1 : DbContext
    {
        public AppDbContext1(DbContextOptions<AppDbContext1> options) : base(options) { }
        public DbSet<User> Users { get; set; }
    }
}

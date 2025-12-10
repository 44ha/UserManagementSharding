using Microsoft.EntityFrameworkCore;
using UserManagementSharding.Models;

namespace UserManagementSharding.Data
{
    public class AppDbContext2 : DbContext
    {
        public AppDbContext2(DbContextOptions<AppDbContext2> options) : base(options) { }
        public DbSet<User> Users { get; set; }
    }
}

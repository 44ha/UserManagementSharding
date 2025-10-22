using Microsoft.EntityFrameworkCore;
using UserManagementSharding.Data;
using UserManagementSharding.Models;

namespace UserManagementSharding.Services
{
    public class UserService
    {
        private readonly ShardManager _shardManager;

        public UserService(ShardManager shardManager)
        {
            _shardManager = shardManager;
        }

        public async Task AddUser(User user)
        {
            var db = _shardManager.GetDbForUser(user);
            db.Users.Add(user);
            await db.SaveChangesAsync();
        }

        public async Task<List<User>> GetAllUsers()
        {
            var db1Users = await _shardManager.GetDb1().Users.ToListAsync();
            var db2Users = await _shardManager.GetDb2().Users.ToListAsync();
            return db1Users.Concat(db2Users).ToList();
        }

        public async Task<bool> DeleteUserById(int id)
        {
            var db = _shardManager.GetDbForId(id);
            var user = await db.Users.FindAsync(id);

            if (user == null) return false;

            db.Users.Remove(user);
            await db.SaveChangesAsync();
            return true;
        }

        public async Task DeleteAllUsers()
        {
            var db1 = _shardManager.GetDb1();
            var db2 = _shardManager.GetDb2();

            db1.Users.RemoveRange(db1.Users);
            db2.Users.RemoveRange(db2.Users);

            await db1.SaveChangesAsync();
            await db2.SaveChangesAsync();
        }
    }
}

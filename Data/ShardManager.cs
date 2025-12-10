using UserManagementSharding.Models;

namespace UserManagementSharding.Data
{
    public class ShardManager
    {
        private readonly AppDbContext1 _db1;
        private readonly AppDbContext2 _db2;

        public ShardManager(AppDbContext1 db1, AppDbContext2 db2)
        {
            _db1 = db1;
            _db2 = db2;
        }

       
        public dynamic GetDbForUser(User user)
        {

            return user.Id % 2 == 0 ? _db1 : _db2;
        }

        
        public dynamic GetDbForId(int id)
        {
            return id % 2 == 0 ? _db1 : _db2;
        }

        public AppDbContext1 GetDb1() => _db1;
        public AppDbContext2 GetDb2() => _db2;
    }
}

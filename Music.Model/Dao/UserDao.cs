using Music.Model.EF;
using System.Linq;

namespace Music.Model.Dao
{
    public class UserDao
    {
        private MusicDbContext db = null;

        public UserDao()
        {
            db = new MusicDbContext();
        }

        public int Insert(user entity)
        {
            db.users.Add(entity);
            db.SaveChanges();
            return entity.user_id;
        }

        public user GetById(string email)
        {
            return db.users.SingleOrDefault(x => x.email == email);
        }

        public bool Login(string email, string password)
        {
            var result = db.users.Count(x => x.email == email && x.password == password);
            if (result > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
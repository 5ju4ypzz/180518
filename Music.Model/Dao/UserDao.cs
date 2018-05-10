using Music.Model.EF;
using System.Linq;

namespace Music.Model.Dao
{
    public class UserDAO
    {
        private DBContext db = null;

        public UserDAO()
        {
            db = new DBContext();
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

        public int Login(string email, string password)
        {
            var result = db.users.SingleOrDefault(x => x.email == email);
            if (result == null)
            {
                return 0;
            }
            else
            {
                if (result.status == false)
                {
                    return -1;
                }
                else
                {
                    if (result.password == password)
                    {
                        return 1;
                    }
                    else
                        return -2;
                }
            }
        }
    }
}
using Music.Model.EF;

namespace Music.Model.Dao
{
    public class AuthorDao
    {
        private MusicDbContext db = null;

        public int Insert(author entity)
        {
            db.authors.Add(entity);
            db.SaveChanges();
            return entity.author_id;
        }
    }
}
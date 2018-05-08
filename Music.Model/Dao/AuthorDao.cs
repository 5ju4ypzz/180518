using Music.Model.EF;

namespace Music.Model.Dao
{
    public class AuthorDAO
    {
        private MSEntities db = null;

        public int Insert(author entity)
        {
            db.authors.Add(entity);
            db.SaveChanges();
            return entity.author_id;
        }
    }
}
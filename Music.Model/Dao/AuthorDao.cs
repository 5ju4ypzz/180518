using Music.Model.EF;

namespace Music.Model.Dao
{
    public class AuthorDAO
    {
        private RunNow db = null;

        public int Insert(author entity)
        {
            db.authors.Add(entity);
            db.SaveChanges();
            return entity.author_id;
        }

        public bool Delete(int? id)
        {
            try
            {
                var author = db.authors.Find(id);
                db.authors.Remove(author);
                db.SaveChanges();
                return true;
            }
            catch (System.Exception)
            {
                return false;
            }
        }
    }
}
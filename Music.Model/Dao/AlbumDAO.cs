using Music.Model.EF;
using System;

namespace Music.Model.Dao
{
    public class AlbumDAO
    {
        private RunNow db = null;

        public AlbumDAO()
        {
            db = new RunNow();
        }

        public bool Delete(int? id)
        {
            try
            {
                var album = db.albums.Find(id);
                db.albums.Remove(album);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
using Music.Model.EF;
using System;

namespace Music.Model.Dao
{
    public class SongDAO
    {
        private RunNow db = null;

        public SongDAO()
        {
            db = new RunNow();
        }

        public bool Delete(int? id)
        {
            try
            {
                var song = db.songs.Find(id);
                db.songs.Remove(song);
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
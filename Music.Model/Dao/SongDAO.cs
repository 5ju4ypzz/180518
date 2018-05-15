using Music.Model.EF;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
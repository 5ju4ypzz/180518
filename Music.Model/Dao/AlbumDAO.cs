using Music.Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
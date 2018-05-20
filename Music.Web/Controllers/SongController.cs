using Music.Model.EF;
using System.Data.Entity;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Music.Web.Controllers
{
    public class SongController : Controller
    {
        private RunNow db = new RunNow();

        // GET: SongPlay
        public ActionResult Index(int id)
        {
            song song = db.songs.Find(id);
            return View();
        }

        [HttpGet]
        public ActionResult Play(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            song song = db.songs.Find(id);
            if (song == null)
            {
                return View("Error");
            }
            return View(song);
        }

        [HttpPost, ActionName("Play")]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Play(int id, song song)
        {
            song.song_view = song.song_view + 1;
            db.Entry(song).State = EntityState.Modified;
            db.SaveChanges();
            return View();
        }
    }
}
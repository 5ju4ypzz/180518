using Music.Model.EF;
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

        public async Task<ActionResult> Play(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            song song = await db.songs.FindAsync(id);
            if (song == null)
            {
                return HttpNotFound();
            }
            return View(song);
        }
    }
}
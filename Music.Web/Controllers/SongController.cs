using Music.Model.EF;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Music.Web.Controllers
{
    public class SongController : Controller
    {
        private Model_12_05 db = new Model_12_05();

        // GET: SongPlay
        public ActionResult Index()
        {
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
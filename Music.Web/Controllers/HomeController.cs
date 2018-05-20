using Music.Model.EF;
using System.Data.Entity;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Music.Web.Controllers
{
    public class HomeController : Controller
    {
        private RunNow db = new RunNow();

        // GET: Albums
        public async Task<ActionResult> Index()
        {
            var albums = db.albums.Include(a => a.singer);
            return View(await albums.ToListAsync());
        }
    }
}
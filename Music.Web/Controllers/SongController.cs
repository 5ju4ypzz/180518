using System.Web.Mvc;

namespace Music.Web.Controllers
{
    public class SongController : Controller
    {
        // GET: SongPlay
        public ActionResult Index()
        {
            return View();
        }
    }
}
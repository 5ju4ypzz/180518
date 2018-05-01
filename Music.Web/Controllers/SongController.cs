using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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
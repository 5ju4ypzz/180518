using Music.Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Music.Web.Controllers
{
    public class _TOPController : Controller
    {
        private RunNow db = new RunNow();

        // GET: _TOP
        public ActionResult _TOP()
        {
            //var top = from s in db.songs orderby song.song_view descending select s;
            //int numberOfrecords = 10; // read from user
            var song = from s in db.songs select s;
            song = song.OrderByDescending(x => x.song_view).Take(10);
            return View(song);
        }
    }
}
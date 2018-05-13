using Music.Model.EF;
using System;
using System.Data.Entity;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Music.Web.Areas.Admin.Controllers
{
    public class SongsController : Controller
    {
        private RunNow db = new RunNow();

        // GET: Admin/Songs
        public async Task<ActionResult> Index()
        {
            var songs = db.songs.Include(s => s.album).Include(s => s.author).Include(s => s.singer);
            return View(await songs.ToListAsync());
        }

        // GET: Admin/Songs/Details/5
        public async Task<ActionResult> Details(int? id)
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

        // GET: Admin/Songs/Create
        public ActionResult Create()
        {
            ViewBag.album_id = new SelectList(db.albums, "album_id", "album_name");
            ViewBag.author_id = new SelectList(db.authors, "author_id", "author_name");
            ViewBag.singer_id = new SelectList(db.singers, "singer_id", "singer_name");
            return View();
        }

        // POST: Admin/Songs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost, ActionName("Create")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "song_id,album_id,singer_id,author_id,song_name,song_path,song_lyric,song_image,song_view,song_viewed_day,song_viewed_week,song_viewed_month,song_download,song_downloaded_week,song_downloaded_month,song_datemodify")] song song, HttpPostedFileBase fileUpload)
        {
            if (ModelState.IsValid)
            {
                if (Request.Files.Count > 0)
                {
                    var file = Request.Files[0];
                    if (file != null && file.ContentLength > 0)
                    {
                        var moresongname = Guid.NewGuid() + ".mp3";
                        var moreimgname = Guid.NewGuid() + ".jpg";
                        var pathSong = Path.Combine(Server.MapPath("~/source/audio/"), moresongname);
                        song.song_path = "~/source/audio/" + moresongname;
                        var pathImg = Path.Combine(Server.MapPath("~/source/images/"), moreimgname);
                        song.song_image = "~/source/images/" + moreimgname;
                        if (System.IO.File.Exists(pathSong))
                        {
                            pathSong = Path.Combine(Server.MapPath("~/source/audio/"), moresongname);
                            song.song_path = "~/source/audio/" + moresongname;
                            pathImg = Path.Combine(Server.MapPath("~/source/images/"), moreimgname);
                            song.song_image = "~/source/images/" + moreimgname;
                        }
                        else
                        {
                            fileUpload.SaveAs(pathSong);
                            fileUpload.SaveAs(pathImg);
                        }
                    }

                    song.song_datemodify = DateTime.Now;
                }
                db.songs.Add(song);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.album_id = new SelectList(db.albums, "album_id", "album_name", song.album_id);
            ViewBag.author_id = new SelectList(db.authors, "author_id", "author_name", song.author_id);
            ViewBag.singer_id = new SelectList(db.singers, "singer_id", "singer_name", song.singer_id);
            return View(song);
        }

        // GET: Admin/Songs/Edit/5
        public async Task<ActionResult> Edit(int? id)
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

            ViewBag.album_id = new SelectList(db.albums, "album_id", "album_name", song.album_id);
            ViewBag.author_id = new SelectList(db.authors, "author_id", "author_name", song.author_id);
            ViewBag.singer_id = new SelectList(db.singers, "singer_id", "singer_name", song.singer_id);
            return View(song);
        }

        // POST: Admin/Songs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "song_id,album_id,singer_id,author_id,song_name,song_path,song_lyric,song_image,song_view,song_viewed_day,song_viewed_week,song_viewed_month,song_download,song_downloaded_week,song_downloaded_month,song_datemodify")] song song, HttpPostedFileBase fileUpload)
        {
            if (ModelState.IsValid)
            {
                for (int i = 0; i < Request.Files.Count; i++)
                {
                    var file = Request.Files[i];
                    if (file != null && file.ContentLength > 0)
                    {
                        var moresongname = Guid.NewGuid() + ".mp3";
                        var moreimgname = Guid.NewGuid() + ".jpg";
                        var pathSong = Path.Combine(Server.MapPath("~/source/audio/"), moresongname);
                        song.song_path = "~/source/audio/" + moresongname;
                        var pathImg = Path.Combine(Server.MapPath("~/source/images/"), moreimgname);
                        song.song_image = "~/source/images/" + moreimgname;
                        if (System.IO.File.Exists(pathSong))
                        {
                            pathSong = Path.Combine(Server.MapPath("~/source/audio/"), moresongname);
                            song.song_path = "~/source/audio/" + moresongname;
                            pathImg = Path.Combine(Server.MapPath("~/source/images/"), moreimgname);
                            song.song_image = "~/source/images/" + moreimgname;
                        }
                        else
                        {
                            fileUpload.SaveAs(pathSong);
                            fileUpload.SaveAs(pathImg);
                        }
                        song.song_datemodify = DateTime.Now;
                        db.Entry(song).State = EntityState.Added;
                    }
                }
                db.Entry(song).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.album_id = new SelectList(db.albums, "album_id", "album_name", song.album_id);
            ViewBag.author_id = new SelectList(db.authors, "author_id", "author_name", song.author_id);
            ViewBag.singer_id = new SelectList(db.singers, "singer_id", "singer_name", song.singer_id);
            return View(song);
        }

        // GET: Admin/Songs/Delete/5
        public async Task<ActionResult> Delete(int? id)
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

        // POST: Admin/Songs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            song song = await db.songs.FindAsync(id);
            var pathSong = Path.Combine(Server.MapPath("~/source/audio/"), song.song_path + ".mp3");
            var pathImg = Path.Combine(Server.MapPath("~/source/images/"), song.song_image + ".jpg");
            if (System.IO.File.Exists(pathSong))
            {
                System.IO.File.Delete(pathSong);
            }
            if (System.IO.File.Exists(pathImg))
            {
                System.IO.File.Delete(pathImg);
            }
            db.songs.Remove(song);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
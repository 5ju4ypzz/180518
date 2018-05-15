using Music.Model.Dao;
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
    public class SongsController : BaseController
    {
        private RunNow db = new RunNow();

        public async Task<ActionResult> Index()
        {
            var songs = db.songs.Include(s => s.album).Include(s => s.author).Include(s => s.singer);
            return View(await songs.ToListAsync());
        }

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

        public ActionResult Create()
        {
            ViewBag.album_id = new SelectList(db.albums, "album_id", "album_name");
            ViewBag.author_id = new SelectList(db.authors, "author_id", "author_name");
            ViewBag.singer_id = new SelectList(db.singers, "singer_id", "singer_name");
            return View();
        }

        [HttpPost, ActionName("Create")]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "song_id,album_id,singer_id,author_id,song_name,song_path,song_lyric,song_image,song_view,song_viewed_day,song_viewed_week,song_viewed_month,song_download,song_downloaded_week,song_downloaded_month,song_datemodify")] song song, HttpPostedFileBase SUpload)
        {
            if (ModelState.IsValid)
            {
                if (song.song_name == null)
                    ModelState.AddModelError("", "Moi nhap ten bai hat - Ten bai hat khong duoc trong");
                else if (song.song_lyric == null)
                {
                    ModelState.AddModelError("", "Moi nhap ten bai hat");
                }
                else
                {
                    var file = Request.Files[0];
                    if (file != null && file.ContentLength > 0)
                    {
                        var _FileName = Path.GetFileName(file.FileName);
                        var _Ext = Path.GetExtension(file.FileName);
                        var path = Path.Combine(Server.MapPath("~/source/audio/"), _FileName + "");
                        song.song_path = "~/source/audio/" + _FileName;
                        if (System.IO.File.Exists(path))
                        {
                            var _NewName = Guid.NewGuid();
                            _FileName = _NewName.ToString();
                            path = Path.Combine(Server.MapPath("~/source/audio/"), _NewName + _Ext);
                            song.song_path = "~/source/audio/" + _NewName + _Ext;
                        }
                        SUpload.SaveAs(path);
                    }
                    song.song_view = 1;
                    db.Entry(song).State = EntityState.Added;
                    song.song_datemodify = DateTime.Now;
                }
                db.songs.Add(song);
                await db.SaveChangesAsync();
            }
            ViewBag.album_id = new SelectList(db.albums, "album_id", "album_name", song.album_id);
            ViewBag.author_id = new SelectList(db.authors, "author_id", "author_name", song.author_id);
            ViewBag.singer_id = new SelectList(db.singers, "singer_id", "singer_name", song.singer_id);
            return RedirectToAction("Index");
        }

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

        [HttpPost]
        [ValidateInput(false)]
        public async Task<ActionResult> Edit([Bind(Include = "song_id,album_id,singer_id,author_id,song_name,song_path,song_lyric,song_datemodify")] song song, HttpPostedFileBase SUpload, int id)
        {
            if (ModelState.IsValid)
            {
                var file = Request.Files[0];
                if (file != null && file.ContentLength > 0)
                {
                    var _FileName = Path.GetFileName(file.FileName);
                    var _Ext = Path.GetExtension(file.FileName);
                    var path = Path.Combine(Server.MapPath("~/source/audio/"), _FileName + "");
                    song.song_path = "~/source/audio/" + _FileName;
                    if (System.IO.File.Exists(path) == true)
                    {
                        var _NewName = Guid.NewGuid();
                        _FileName = _NewName.ToString();
                        path = Path.Combine(Server.MapPath("~/source/audio/"), _NewName + _Ext);
                        song.song_path = "~/source/audio/" + _NewName + _Ext;
                    }
                    song.song_view = song.song_view;
                    song.song_datemodify = DateTime.Now;
                    SUpload.SaveAs(path);
                    db.Entry(song).State = EntityState.Modified;
                    await db.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
            }
            ViewBag.album_id = new SelectList(db.albums, "album_id", "album_name", song.album_id);
            ViewBag.author_id = new SelectList(db.authors, "author_id", "author_name", song.author_id);
            ViewBag.singer_id = new SelectList(db.singers, "singer_id", "singer_name", song.singer_id);
            return View();
        }

        [HttpDelete]
        public ActionResult Delete(int? id)
        {
            new SongDAO().Delete(id);
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
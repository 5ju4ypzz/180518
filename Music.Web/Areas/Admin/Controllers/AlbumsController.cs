using Music.Model.EF;
using System.Data.Entity;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Music.Web.Areas.Admin.Controllers
{
    public class AlbumsController : Controller
    {
        private RunNow db = new RunNow();

        public async Task<ActionResult> Index()
        {
            var albums = db.albums.Include(a => a.singer);
            return View(await albums.ToListAsync());
        }

        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            album album = await db.albums.FindAsync(id);
            if (album == null)
            {
                return HttpNotFound();
            }
            return View(album);
        }

        public ActionResult Create()
        {
            ViewBag.singer_id = new SelectList(db.singers, "singer_id", "singer_name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "album_id,singer_id,album_name,album_createdate,album_image,album_view,album_viewed_day,album_viewed_week,album_viewed_month")] album album, HttpPostedFileBase Upload)
        {
            if (ModelState.IsValid)
            {
                var file = Request.Files[0];
                if (file != null && file.ContentLength > 0)
                {
                    string _FileName = Path.GetFileName(file.FileName);
                    string _Ext = Path.GetExtension(file.FileName);
                    string path = Path.Combine(Server.MapPath("~/source/images/"), _FileName);
                    album.album_image = "~/source/images/" + _FileName;
                    Upload.SaveAs(path);
                }
                album.album_view = 1;
                album.album_viewed_day = 1;
                album.album_viewed_week = 1;
                album.album_viewed_month = 1;
                db.albums.Add(album);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.singer_id = new SelectList(db.singers, "singer_id", "singer_name", album.singer_id);
            return View(album);
        }

        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            album album = await db.albums.FindAsync(id);
            if (album == null)
            {
                return HttpNotFound();
            }
            ViewBag.singer_id = new SelectList(db.singers, "singer_id", "singer_name", album.singer_id);
            return View(album);
        }

        // POST: Admin/Albums/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "album_id,singer_id,album_name,album_createdate,album_image,album_view,album_viewed_day,album_viewed_week,album_viewed_month")] album album)
        {
            if (ModelState.IsValid)
            {
                db.Entry(album).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.singer_id = new SelectList(db.singers, "singer_id", "singer_name", album.singer_id);
            return View(album);
        }

        // GET: Admin/Albums/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            album album = await db.albums.FindAsync(id);
            if (album == null)
            {
                return HttpNotFound();
            }

            return View(album);
        }

        // POST: Admin/Albums/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            album album = await db.albums.FindAsync(id);
            db.albums.Remove(album);
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
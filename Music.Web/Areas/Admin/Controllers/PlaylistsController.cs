using Music.Model.EF;
using System.Data.Entity;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Music.Web.Areas.Admin.Controllers
{
    public class PlaylistsController : BaseController
    {
        private RunNow db = new RunNow();

        // GET: Admin/Playlists
        public async Task<ActionResult> Index()
        {
            var playlists = db.playlists.Include(p => p.user);
            return View(await playlists.ToListAsync());
        }

        // GET: Admin/Playlists/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            playlist playlist = await db.playlists.FindAsync(id);
            if (playlist == null)
            {
                return HttpNotFound();
            }
            return View(playlist);
        }

        // GET: Admin/Playlists/Create
        public ActionResult Create()
        {
            ViewBag.user_id = new SelectList(db.users, "user_id", "email");
            return View();
        }

        // POST: Admin/Playlists/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "playlist_id,user_id,playlist_name,playlist_createdate")] playlist playlist)
        {
            if (ModelState.IsValid)
            {
                db.playlists.Add(playlist);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.user_id = new SelectList(db.users, "user_id", "email", playlist.user_id);
            return View(playlist);
        }

        // GET: Admin/Playlists/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            playlist playlist = await db.playlists.FindAsync(id);
            if (playlist == null)
            {
                return HttpNotFound();
            }
            ViewBag.user_id = new SelectList(db.users, "user_id", "email", playlist.user_id);
            return View(playlist);
        }

        // POST: Admin/Playlists/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "playlist_id,user_id,playlist_name,playlist_createdate")] playlist playlist)
        {
            if (ModelState.IsValid)
            {
                db.Entry(playlist).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.user_id = new SelectList(db.users, "user_id", "email", playlist.user_id);
            return View(playlist);
        }

        // GET: Admin/Playlists/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            playlist playlist = await db.playlists.FindAsync(id);
            if (playlist == null)
            {
                return HttpNotFound();
            }
            return View(playlist);
        }

        // POST: Admin/Playlists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            playlist playlist = await db.playlists.FindAsync(id);
            db.playlists.Remove(playlist);
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
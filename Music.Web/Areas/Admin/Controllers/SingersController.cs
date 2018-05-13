using Music.Model.EF;
using System.Data.Entity;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Music.Web.Areas.Admin.Controllers
{
    public class SingersController : Controller
    {
        private RunNow db = new RunNow();

        // GET: Admin/Singers
        public async Task<ActionResult> Index()
        {
            return View(await db.singers.ToListAsync());
        }

        // GET: Admin/Singers/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            singer singer = await db.singers.FindAsync(id);
            if (singer == null)
            {
                return HttpNotFound();
            }
            return View(singer);
        }

        // GET: Admin/Singers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Singers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "singer_id,singer_name,singer_nickname,singer_sex,singer_country,singer_image,singer_cover_image,singer_dateofbirth,singer_description")] singer singer)
        {
            if (ModelState.IsValid)
            {
                db.singers.Add(singer);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(singer);
        }

        // GET: Admin/Singers/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            singer singer = await db.singers.FindAsync(id);
            if (singer == null)
            {
                return HttpNotFound();
            }
            return View(singer);
        }

        // POST: Admin/Singers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "singer_id,singer_name,singer_nickname,singer_sex,singer_country,singer_image,singer_cover_image,singer_dateofbirth,singer_description")] singer singer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(singer).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(singer);
        }

        // GET: Admin/Singers/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            singer singer = await db.singers.FindAsync(id);
            if (singer == null)
            {
                return HttpNotFound();
            }
            return View(singer);
        }

        // POST: Admin/Singers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            singer singer = await db.singers.FindAsync(id);
            db.singers.Remove(singer);
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
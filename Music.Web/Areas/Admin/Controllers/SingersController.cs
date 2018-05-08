using Music.Model.EF;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace Music.Web.Areas.Admin.Controllers
{
    public class SingersController : Controller
    {
        private MusicDbContext db = new MusicDbContext();

        // GET: Admin/Singers
        public ActionResult Index()
        {
            return View(db.singers.ToList());
        }

        // GET: Admin/Singers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            singer singer = db.singers.Find(id);
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
        public ActionResult Create([Bind(Include = "singer_id,singer_name,singer_nickname,singer_sex,singer_country,singer_image,singer_cover_image,singer_dateofbirth,singer_description,singer_createdate")] singer singer)
        {
            if (ModelState.IsValid)
            {
                db.singers.Add(singer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(singer);
        }

        // GET: Admin/Singers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            singer singer = db.singers.Find(id);
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
        public ActionResult Edit([Bind(Include = "singer_id,singer_name,singer_nickname,singer_sex,singer_country,singer_image,singer_cover_image,singer_dateofbirth,singer_description,singer_createdate")] singer singer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(singer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(singer);
        }

        // GET: Admin/Singers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            singer singer = db.singers.Find(id);
            if (singer == null)
            {
                return HttpNotFound();
            }
            return View(singer);
        }

        // POST: Admin/Singers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            singer singer = db.singers.Find(id);
            db.singers.Remove(singer);
            db.SaveChanges();
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
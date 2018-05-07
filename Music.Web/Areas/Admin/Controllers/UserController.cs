using Music.Model.EF;
using System.Web.Mvc;
using Music.Model.Dao;
using Music.Web.Common;

namespace Music.Web.Areas.Admin.Controllers
{
    public class UserController : Controller
    {
        // GET: Admin/User
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(user user)
        {
            var dao = new UserDao();
            //Mã hóa mật khẩu
            var encryptorMd5has = Encryptor.MD5Hash(user.password);
            user.password = encryptorMd5has;

            int id = dao.Insert(user);
            if (id > 0)
            {
                return RedirectToAction("Index", "User");
            }
            else
            {
                ModelState.AddModelError("", "Thêm thành công!");
            }
            return View("Index");
        }
        public ActionResult List()
        {
            return View();
        }
    }
}
using Music.Model.Dao;
using Music.Web.Areas.Admin.Models;
using Music.Web.Common;
using System.Web.Mvc;

namespace Music.Web.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        // GET: Admin/Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var dao = new UserDao();
                var result = dao.Login(model.email, model.password);
                if (result)
                {
                    var user = dao.GetById(model.email);
                    var userSession = new UserLogin();
                    userSession.email = user.email;
                    userSession.user_id = user.user_id;
                    Session.Add(CommonConstants.USER_SESSION, userSession);
                    return RedirectToAction("Index", "Login");
                }
                else
                {
                    ModelState.AddModelError("", "Đăng nhập không đúng");
                }
            }
            return View();
        }

        public ActionResult ListMusic()
        {
            return View();
        }
    }
}
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
                var dao = new UserDAO();
                var result = dao.Login(model.email, Encryptor.MD5Hash(model.password));
                if (result == 1)
                {
                    var user = dao.GetById(model.email);
                    var userSession = new UserLogin();
                    userSession.email = user.email;
                    userSession.user_id = user.user_id;
                    Session.Add(CommonConstants.USER_SESSION, userSession);
                    return RedirectToAction("Index", "Login");
                }
                else if (result == 0)
                {
                    ModelState.AddModelError("", "Tài khoản không tồn tại!");
                }
                else if (result == -1)
                {
                    ModelState.AddModelError("", "Tài khoản đang bị khóa!");
                }
                else if (result == -2)
                {
                    ModelState.AddModelError("", "Mật khẩu không đúng!");
                }
                else
                {
                    ModelState.AddModelError("", "Đăng nhập không thành công !");
                }
            }
            return View();
        }
    }
}
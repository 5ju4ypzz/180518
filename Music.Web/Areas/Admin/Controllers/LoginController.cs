using Music.Model.Dao;
using Music.Model.EF;
using Music.Web.Areas.Admin.Models;
using Music.Web.Common;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Music.Web.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        private RunNow db = new RunNow();

        // GET: Admin/Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SignUp()
        {
            return View();
        }

        [HttpPost, ActionName("SignUp")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> SignUp([Bind(Include = "user_id,email,password,user_name")] user user)
        {
            if (ModelState.IsValid)
            {
                var encryptorMd5has = Encryptor.MD5Hash(user.password);
                user.password = encryptorMd5has;
                db.users.Add(user);
                await db.SaveChangesAsync();
                return RedirectToAction("Login");
            }

            return View(user);
        }

        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var dao = new LoginDAO();
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
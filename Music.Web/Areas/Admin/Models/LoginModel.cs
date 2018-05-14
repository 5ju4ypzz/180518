using System.ComponentModel.DataAnnotations;

namespace Music.Web.Areas.Admin.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Mời nhập email!")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Invalid")]
        public string email { get; set; }

        [Required(ErrorMessage = "Mời nhập mật khẩu!")]
        public string password { get; set; }

        public bool RememberMe { get; set; }
    }
}
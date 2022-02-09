using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServerHost.Quickstart.UI
{
    public class RegisterViewModel
    {

        [Required(ErrorMessage = "昵称需要填写")]
        [Display(Name = "昵称")]
        public string RealName { get; set; }

        [Required(ErrorMessage = "登录名需要填写")]
        [Display(Name = "登录名")]
        public string LoginName { get; set; }

        [Required(ErrorMessage ="邮箱需要填写")]
        [EmailAddress]
        [Display(Name = "邮箱")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "密码")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "确认密码")]
        [Compare("Password", ErrorMessage = "The 密码 and 确认密码 do not match.")]
        public string ConfirmPassword { get; set; }



        [Required]
        [Display(Name = "密保问题一：你喜欢的动漫？")]
        public string FirstQuestion { get; set; }

        [Required]
        [Display(Name = "密保问题二：你喜欢的名著？")]
        public string SecondQuestion { get; set; }

        [Display(Name = "性别")]
        public int Sex { get; set; } = 0;

        [Display(Name = "生日")]
        public DateTime Birth { get; set; } = DateTime.Now;
    }
}

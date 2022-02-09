using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServerHost.Quickstart.UI
{
    public class ForgotPasswordViewModel
    {
        [Required(ErrorMessage ="邮箱必须填写")]
        [EmailAddress]
        public string Email { get; set; }

        [Display(Name = "密保问题一：你喜欢的动漫？")]
        public string FirstQuestion { get; set; }

        [Display(Name = "密保问题二：你喜欢的名著？")]
        public string SecondQuestion { get; set; }
    }
}

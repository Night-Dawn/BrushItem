using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrushItem.Shared.Models
{
    public class UserAddDto
    {
        [Display(Name = "用户名")]
        [Required(ErrorMessage = "{0}这个字段是必填的")]
        [MaxLength(100, ErrorMessage = "{0}的最大长度不可以超过{1}")]
        public string username { get; set; }
        [Display(Name = "姓名")]
        [Required(ErrorMessage = "{0}这个字段是必填的")]
        [MaxLength(100, ErrorMessage = "{0}的最大长度不可以超过{1}")]
        public string name { get; set; }

    }
}

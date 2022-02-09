using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrushItem.Shared.Entities
{
    [Table("choice")]
    public class MultipleChoice: Question
    {
        [Comment("选项A")]
        public string optionA { get; set; }
        [Comment("选项B")]
        public string optionB { get; set; }
        [Comment("选项C")]
        public string optionC { get; set; }
        [Comment("选项D")]
        public string optionD { get; set; }

    }
}

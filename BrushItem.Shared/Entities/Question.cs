using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrushItem.Shared.Entities
{
    /// <summary>
    /// 题目
    /// </summary>
    //[Table("question")]
    //[Index(nameof(Id))]
    public abstract class Question
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity), Comment("题目编号")]
        public Guid Id { get; set; }

        [Comment("题目描述")]
        public string Description { get; set; }

        [Comment("题目分析")]
        public string Analysis { get; set; }
        [Comment("创建时间")]
        public DateTime CreatedTime { get; set; }
        [Comment("更新时间")]
        public DateTime UpdatedTime { get; set; }

        [Comment("类别")]
        public Category Category { get; set; }
    }
}

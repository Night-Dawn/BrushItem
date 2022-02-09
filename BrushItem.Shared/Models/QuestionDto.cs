using BrushItem.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrushItem.Shared.Models
{
    public class QuestionDto
    {
        public Guid Id { get; set; }

        public string Description { get; set; }

        public string Analysis { get; set; }
        public string CorrectAnswer { get; set; }
        public List<String> Options { get; set; }
        public DateTime CreatedTime { get; set; }
        public DateTime UpdatedTime { get; set; }

        public Category Category { get; set; }
        
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrushItem.Shared.Entities
{
    [Table("user")]
    public class User
    {
        
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid id { get; set; }
        public string username { get; set; }
        public string name { get; set; }

        public override string ToString()
        {
            return $"{id},{username},{name}";
        }
    }
}

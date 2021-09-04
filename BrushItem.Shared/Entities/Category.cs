using System.ComponentModel.DataAnnotations.Schema;

namespace BrushItem.Shared.Entities
{
    [Table("category")]
    public class Category
    {
        public int Id { get; set; }
        public int Name { get; set; }
    }
}
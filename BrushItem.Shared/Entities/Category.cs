using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace BrushItem.Shared.Entities
{
    [Table("category")]
    public class Category
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
using BrushItem.Shared.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BrushItem.Data
{
    public class BrushDbContext:DbContext
    {
        public DbSet<MultipleChoice> MultipleChoices { get; set; }
        public DbSet<SingleChoice> SingleChoices { get; set; }
        public DbSet<Blank> Blanks { get; set; }
        public DbSet<Category> Categories { get; set; }
        public BrushDbContext(DbContextOptions<BrushDbContext> options) : base(options)
        {

        }
    }
}

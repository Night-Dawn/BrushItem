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
        public DbSet<User> Users { get; set; }
        public DbSet<Choice> Choices { get; set; }
        public BrushDbContext(DbContextOptions<BrushDbContext> options) : base(options)
        {

        }
    }
}

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrushItem.IdentityServer.Data
{
    public class ApplicationUser : IdentityUser<int>
    {
        public string LoginName { get; set; }

        public string RealName { get; set; }

        public int sex { get; set; } = 0;

        public int age { get; set; }

        public DateTime birth { get; set; } = DateTime.Now;

        public string addr { get; set; }
        public string FirstQuestion { get; set; }
        public string SecondQuestion { get; set; }

        public bool tdIsDelete { get; set; }

        public ICollection<ApplicationUserRole> UserRoles { get; set; }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, int, IdentityUserClaim<int>,
           ApplicationUserRole, IdentityUserLogin<int>,
           IdentityRoleClaim<int>, IdentityUserToken<int>>
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
         : base(options)
        {
        }
        //public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        //public DbSet<ApplicationRole> ApplicationRoles { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }
}

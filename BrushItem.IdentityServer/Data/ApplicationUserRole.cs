using Microsoft.AspNetCore.Identity;

namespace BrushItem.IdentityServer.Data
{
    public class ApplicationUserRole: IdentityUserRole<int>
    {
        public virtual ApplicationUser User { get; set; }
        public virtual ApplicationRole Role { get; set; }
    }
}
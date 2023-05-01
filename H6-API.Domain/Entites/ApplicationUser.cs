using Microsoft.AspNetCore.Identity;

namespace H6_API.Domain.Entites
{
    public class ApplicationUser : IdentityUser
    {
        public List<TrackedMedia> trackedMedias { get; set; }
    }
}

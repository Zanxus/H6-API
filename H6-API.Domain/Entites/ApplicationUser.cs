using IdentityModel;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H6_API.Domain.Entites
{
    public class ApplicationUser : IdentityUser
    {
        public List<TrackedMedia> trackedMedias { get; set; }
    }
}

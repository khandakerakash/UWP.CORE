using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace OBS.API.Model
{
    public class ApplicationRole: IdentityRole<long>
    {
        public virtual ICollection<ApplicationUserRole> UserRoles { get; set; }
    }
}
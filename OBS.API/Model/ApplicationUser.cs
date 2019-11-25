using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using OBS.API.Model.Interfaces;

namespace OBS.API.Model
{
    public class ApplicationUser : IdentityUser<long>, ITrackable
    {
        public string FullName { get; set; }
        public long KeyMakerId { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public DateTimeOffset LastUpdatedAt { get; set; }
        public string LastUpdatedBy { get; set; }
        public bool IsDeleted { get; set; }
        public virtual ICollection<IdentityUserClaim<long>> Claims { get; set; }
        public virtual ICollection<IdentityUserLogin<long>> Logins { get; set; }
        public virtual ICollection<IdentityUserToken<long>> Tokens { get; set; }
        public virtual ICollection<ApplicationUserRole> UserRoles { get; set; }
    }
}
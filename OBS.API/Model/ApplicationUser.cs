using Microsoft.AspNetCore.Identity;

namespace OBS.API.Model
{
    public class ApplicationUser: IdentityUser<long>
    {
        public string Address { get; set; }
    }
}
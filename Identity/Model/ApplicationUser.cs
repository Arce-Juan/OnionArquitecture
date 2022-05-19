using Microsoft.AspNetCore.Identity;

namespace Identity.Model
{
    public class ApplicationUser : IdentityUser
    {
        public string LastName { get; set; }
        public string Name { get; set; }
    }
}

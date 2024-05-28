using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Nerdnest.Model
{
    public class User : IdentityUser
    {
        [Required]
        public string FirstName { get; set; } = string.Empty;
        [Required]
        public string LastName { get; set; } = string.Empty;
        [Required]
        public string Country { get; set; } = string.Empty;
        [Required]
        public string Password { get; set; } = string.Empty;
        [Required]
        public string Role {  get; set; } = string.Empty;
    }
}

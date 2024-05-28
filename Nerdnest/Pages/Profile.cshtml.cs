using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Nerdnest.Model
{
    [Authorize]
    [BindProperties]
    public class ProfileModel : PageModel
    {
        private readonly UserManager<User> _userManager;

        public ProfileModel(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public User Profile { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound("User not found.");
            }

            Profile = new User
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                PhoneNumber = user.PhoneNumber,
                Email = user.Email,
                Country = user.Country
            };

            return Page();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound("User not found.");
            }


            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}

            if (FirstName != null)
            {
                user.FirstName = FirstName;
            }

            if (LastName != null)
            {
                user.LastName = LastName;
            }

            if (PhoneNumber != null)
            {
                user.PhoneNumber = PhoneNumber;
            }

            if (Email != null)
            {
                user.Email = Email;
            }

            var result = await _userManager.UpdateAsync(user);
            if (result.Succeeded)
            {
                return Page();
            }
            else
            {
                return BadRequest("Failed to update user.");
            }
            
        }
    }

}


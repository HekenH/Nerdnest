using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Nerdnest.Model;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Nerdnest.Pages.Login
{
    public class LogoutModel : PageModel
    {
        private readonly SignInManager<User> _signInManager;

        public LogoutModel(SignInManager<User> signInManager)
        {
            _signInManager = signInManager;
        }

        public async Task<IActionResult> OnPostLogoutAsync()
        {
            await _signInManager.SignOutAsync();
            return RedirectToPage("/Index");
        }
        public void OnGet()
        {
        }
    }
}

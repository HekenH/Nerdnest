using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Nerdnest.Data;
using Nerdnest.Model;
using System.ComponentModel.DataAnnotations;

namespace Nerdnest.Pages.Login
{
    [BindProperties]
    public class IndexModel : PageModel
    {
        private readonly SignInManager<User> _signInManager;
        public IndexModel(SignInManager<User> signInManager)
        {
            _signInManager = signInManager;
        }
        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {
            [Required]
            public string? Login { get; set; }

            [Required]
            [DataType(DataType.Password)]
            public string? Password { get; set; }
            [Display(Name = "Remember me?")]
            public bool RememberMe { get; set; }
        }
        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(Input.Login!, Input.Password!, Input.RememberMe, lockoutOnFailure: false);
                if (result.Succeeded)
                {
                    return RedirectToPage("../Index");
                }
                ModelState.AddModelError(string.Empty, "Invalid login attempt.");
            }
            return Page();
        }
    }
}

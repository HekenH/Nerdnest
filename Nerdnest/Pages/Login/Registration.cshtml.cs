using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Nerdnest.Data;
using Nerdnest.Model;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Metrics;
using System.Net.Http.Headers;
using System.Numerics;
using System.Text.RegularExpressions;

namespace Nerdnest.Pages.Login
{
    [BindProperties]
    public class RegistrationModel : PageModel
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        public RegistrationModel(UserManager<User> userManager, SignInManager<User> signInManager, ILogger<RegistrationModel> logger)
        {
            _userManager = userManager;
            _signInManager = signInManager;

        }
        [BindProperty]
        public InputModel Input { get; set; }
        public List<SelectListItem> CountryList { get; set; }

        public class InputModel
        {
            [Required]
            public string? FirstName { get; set; }
            [Required]
            public string? LastName { get; set; }
            [Required]
            public string? PhoneNumber { get; set; }
            [Required]
            public string? Country { get; set; }
            [Required]
            [EmailAddress]
            public string? Email { get; set; }
            [Required]
            public string? Login { get; set; }

            [Required]
            [DataType(DataType.Password)]
            public string? Password { get; set; }
        }
        public void OnGet()
        {
            CountryList = new List<SelectListItem>
            {
                new SelectListItem { Value = "USA", Text = "United States" },
                new SelectListItem { Value = "CAN", Text = "Canada" },
                new SelectListItem { Value = "UK", Text = "United Kingdom" },
                new SelectListItem { Value = "RU", Text = "Russia" },
                new SelectListItem { Value = "UZ", Text = "Uzbekistan" },
                new SelectListItem { Value = "KZ", Text = "Kazakstan" },
                new SelectListItem { Value = "KG", Text = "Kirgizistan" },
                new SelectListItem { Value = "TR", Text = "Turkiye" },
            };
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                var user = new User { FirstName = Input.FirstName!, LastName = Input.LastName!, PhoneNumber = Input.PhoneNumber, Country = Input.Country!, Email = Input.Email, UserName = Input.Login, Password = Input.Password!, };
                var result = await _userManager.CreateAsync(user, Input.Password!);
                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToPage("/Index");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, "Invalid Registration attempt!");
                }
            }
            return Page();
        }
    }
}

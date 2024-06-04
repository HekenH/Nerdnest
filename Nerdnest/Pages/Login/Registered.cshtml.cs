using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Nerdnest.Data;
using Nerdnest.Model;

namespace Nerdnest.Pages.Login
{
    public class RegisteredModel : PageModel
    {
        [BindProperty]
        public string? Verification { get; set; }
        [BindProperty]
        public string? Message { get; set; }
        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid) 
            {
                if(Verification != "4525")
                {
                    Message = "Verification Code is not valid, try againt!";
                    return Page();
                }
            }
            return RedirectToPage("/Profile");

        }
    }
}

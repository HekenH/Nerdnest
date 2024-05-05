using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
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

        private readonly ApplicationDbContext _db;
        public Category NewAccount {  get; set; }
        public RegistrationModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public void OnGet()
        {
        }
        
        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                NewAccount.Country = Request.Form["Country"];
                _db.Category.AddAsync(NewAccount);
                _db.SaveChanges();
                return RedirectToPage("/Index");
            }
            else
            {
                return Page();
            }
        }
    }
}

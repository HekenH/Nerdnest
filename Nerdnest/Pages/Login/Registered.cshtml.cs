using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Nerdnest.Data;
using Nerdnest.Model;

namespace Nerdnest.Pages.Login
{
    public class RegisteredModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        public IEnumerable<Category> Categories { get; set; }
        public RegisteredModel(ApplicationDbContext db)
        {
            _db=db;
        }
        public void OnGet()
        {
            Categories = _db.Category;
        }
    }
}

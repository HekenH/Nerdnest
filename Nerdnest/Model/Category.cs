using System.ComponentModel.DataAnnotations;

namespace Nerdnest.Model
{
    public class Category
    {
        [Key]
        public int Id {  get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;   
        public string Phone { get; set; } = string.Empty;
        public string Login { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}

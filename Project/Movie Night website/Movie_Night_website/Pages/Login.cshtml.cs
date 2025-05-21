using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Movie_Night_Website.DataAccess.Data;
using System.Security.Cryptography.X509Certificates;

namespace Movie_Night_website.Pages
{
    public class LoginModel : PageModel
    {
        private readonly MovieNightDatabase _database;

        [BindProperty]
        public string Username { get; set; }
        
        [BindProperty]
        public string Password { get; set; }

        public void OnGet()
        {
        }

        public void OnPost()
        {
            string hashPassword = BCrypt.Net.BCrypt.EnhancedHashPassword(Password);
            
            _database.GetUser(Username, hashPassword);
        }
    }
}

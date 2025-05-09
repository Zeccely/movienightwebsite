using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Movie_Night_website.Data;
using System.Security.Cryptography.X509Certificates;

namespace Movie_Night_website.Pages
{
    public class LoginModel : PageModel
    {
        private MovieNightDatabase _database;

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
            //Verify it here
            _database.GetUser(Username, hashPassword);
        }
    }
}

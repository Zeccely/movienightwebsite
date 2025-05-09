using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Movie_Night_website.Data;

namespace Movie_Night_website.Pages
{
    public class RegisterModel : PageModel
    {
        private MovieNightDatabase _database;
        [BindProperty]
        public string NewUsername { get; set; }

        [BindProperty]
        public string NewPassword { get; set; }


        public void OnGet()
        {

        }

        public void OnPost()
        {
            string passwordHash = BCrypt.Net.BCrypt.EnhancedHashPassword(NewPassword, 13); //this is cheats
            _database.AddUser(NewUsername, passwordHash); //include salt
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Movie_Night_Website.DataAccess.Data;


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
            string salt = BCrypt.Net.BCrypt.GenerateSalt(13);
            string hash = BCrypt.Net.BCrypt.HashPassword(NewPassword, salt); 
            _database.AddUser(NewUsername, hash, salt); //include salt
        }
    }
}

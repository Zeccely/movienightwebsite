using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Movie_Night_Website.Service;


namespace Movie_Night_website.Pages
{
    public class RegisterModel : PageModel
    {
        private UserService userserve;



        [BindProperty]
        public string NewUsername { get; set; }

        [BindProperty]
        public string NewPassword { get; set; }


        public void OnGet()
        {

        }

        public void OnPost()
        {
            
            userserve.RegisterUser(NewUsername, NewPassword);
        }
    }
}

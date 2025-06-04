using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Movie_Night_website.Models;
using Movie_Night_Website.Service;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;
using System.Security.Cryptography.X509Certificates;

namespace Movie_Night_website.Pages
{
    public class LoginModel : PageModel
    {
        private readonly UserService userService;
        
        public LoginModel(UserService userService)
        {
            this.userService = userService;
        }


        [BindProperty]
        public string Username { get; set; }
        
        [BindProperty]
        public string Password { get; set; }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            User loggingin = userService.Login(Username, Password);

            if (loggingin != null)
            {
                HttpContext.Session.SetInt32("UserID", loggingin.UserID);
                HttpContext.Session.SetString("Username", loggingin.Username);

              
                return RedirectToPage("/Index");
            }
            else
            {
                return RedirectToPage("/Login");
            }



        }
    }
}

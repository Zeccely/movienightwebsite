using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Movie_Night_website.Models;
using Movie_Night_Website.Service;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;
using System.Security.Cryptography.X509Certificates;
using Microsoft.AspNetCore.Authorization;



namespace Movie_Night_website.Pages
{
    [AllowAnonymous]
    public class IndexModel : PageModel
    {
        
        private readonly UserService userService;
        
        public IndexModel(UserService userService)
        {
            this.userService = userService;
        }


        [BindProperty]
        public string Username { get; set; }
        
        [BindProperty]
        public string Password { get; set; }

        public async Task<IActionResult> OnGet()
        {
            if (HttpContext.User.Identity?.IsAuthenticated == true )
            {
                return RedirectToPage("/Home");
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            User loggingin = userService.Login(Username, Password);

            if (loggingin != null)
            {

                List<Claim> claims = new List<Claim>
                {
                    new Claim (ClaimTypes.Name, loggingin.Username),
                    new Claim (ClaimTypes.NameIdentifier, loggingin.GetUserID.ToString()),
                    new Claim (ClaimTypes.Role, loggingin.Role.ToString())
                };

                ClaimsIdentity identity = new ClaimsIdentity(claims, "MyCookieAuth");
                ClaimsPrincipal principal = new ClaimsPrincipal(identity);

                await HttpContext.SignInAsync("MyCookieAuth", principal);


                return RedirectToPage("/Home");
            }
            else
            {
                return Page();
            }



        }
    }
}

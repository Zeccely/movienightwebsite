using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Movie_Night_website.Models;
using Movie_Night_Website.Service;

namespace Movie_Night_website.Pages
{
    [Authorize]
    public class VoteModel : PageModel
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string MediaTitle { get; set; }
        
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            throw new NotImplementedException();
        }
    }
}

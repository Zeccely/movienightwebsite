using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Movie_Night_website.Pages
{
    [Authorize]
    public class VoteModel : PageModel
    {
        public void OnGet()
        {
        }
    }
}

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
//using Microsoft.EntityFrameworkCore;
using System.Data.Entity;

namespace Movie_Night_website.Pages
{
    [Authorize]
    public class HomeModel : PageModel
    {
        private readonly ILogger<HomeModel> _logger;

    }
}

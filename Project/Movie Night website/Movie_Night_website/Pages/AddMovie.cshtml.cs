using System.Data.Entity;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration.UserSecrets;
using Movie_Night_website.Services;

namespace Movie_Night_website.Pages
{
    [Authorize]
    public class AddMovieModel : PageModel
    {
        private readonly MediaService _mediaService;

        public AddMovieModel(MediaService mediaService)
        {
            _mediaService = mediaService;
        }

        [BindProperty]
        public string Title { get; set; }

        [BindProperty]
        public string TrailerURL { get; set; }

        [BindProperty]
        public string MediaType { get; set; }

        public int? UserID { get; set; } 


        public void OnPost()
        {
            string? UserID = HttpContext.GetClaimValue(ClaimTypes.NameIdentifier);
            
            if (UserID != null)
            {
                _mediaService.AddMediaToDB(Title, TrailerURL, MediaType, Convert.ToInt32(UserID));
                //clear text boxes pls
            }
            
            
        }

        public void OnGet() 
        {
          

        }

    }
}

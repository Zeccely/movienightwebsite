using System.Data.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
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

        public int UserID { get; set; }

        public void OnPost()
        {
            _mediaService.AddMediaToDB(Title, TrailerURL, MediaType, UserID);
        }

        public void OnGet() 
        {
          

        }

    }
}

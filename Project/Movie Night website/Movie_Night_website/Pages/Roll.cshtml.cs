using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Movie_Night_website.Models;
using Movie_Night_website.Services;

namespace Movie_Night_website.Pages
{
    [Authorize]
    public class RollModel : PageModel
    {
        public List<Media> MediaList { get; set; } = [];
        public Media ChosenMedia { get; set; }
        OrganizerService _admin;
        MediaService _mediaService;
        public RollModel(OrganizerService admin, MediaService _mediaServ)
        {
            _admin = admin;
            _mediaService = _mediaServ;
        }

       
        public void OnGet()
        {
            MediaList = _mediaService.GetApprovedMedia();
        }
        public void OnPost() 
        {
            _admin.GrabRandomMovie(MediaList);
        }
    }
}

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Movie_Night_website.Models;
using Movie_Night_website.Services;
using Movie_Night_Website.Service;

namespace Movie_Night_website.Pages
{
    [Authorize]
    public class RollModel : PageModel
    {
        public List<Media> MediaList { get; set; } = [];
        public Media ChosenMedia { get; set; }
        OrganizerService _admin;
        MediaService _mediaService;
        UserService _userService;
        public RollModel(OrganizerService admin, MediaService _mediaServ, UserService userService)
        {
            _admin = admin;
            _mediaService = _mediaServ;
            _userService = userService;
        }

       
        public void OnGet()
        {
        }
        public void OnPost() 
        {
            MediaList = _mediaService.GetApprovedMedia();
            ChosenMedia = _admin.GrabRandomMovie(MediaList);

            User submittedby = _userService.GetUserById(ChosenMedia.ContributorID);


        }
    }
}

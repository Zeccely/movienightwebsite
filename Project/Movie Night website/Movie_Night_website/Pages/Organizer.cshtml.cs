using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Movie_Night_website.Models;
using Movie_Night_website.Services;
using Movie_Night_Website.DataAccess.Data;
using Movie_Night_Website.Service;

namespace Movie_Night_website.Pages
{
    [Authorize(Roles ="Organizer")] //needs to be authorized only to organizer role later
    public class OrganizerModel : PageModel
    {
        private readonly UserService _userService;
        private readonly MediaService _mediaService;
        private readonly VotingService _votingService;
        private OrganizerService _organizerService;
        public OrganizerModel(UserService userService, MediaService mediaService, OrganizerService organizerService, VotingService votingService)
        {
            _userService = userService;
            _mediaService = mediaService;
            _organizerService = organizerService;
            _votingService = votingService;
        }

        public List<int> selectedUsers = new List<int>();
        public List<Media> MediaList { get; set; } = [];

        public List<Media> ApprovedMediaList { get; set; } = [];
        public List<User> UserList { get; set; }
        [BindProperty]
        public List<int> Attendees { get; set; } = new List<int>();
        [BindProperty]
        public int ChosenMediaID { get; set; }

        public void OnGet()
        {
            
            UserList = _userService.GetUsers();
            MediaList = _mediaService.GetApprovedMedia();
            foreach (Media media in MediaList)
            {
               
                User Submittedby = _userService.GetUserById(media.ContributorID);
                media.Contributor = Submittedby;
   
            }
        }

        public void OnPost()
        {
            // Always reload these so the page doesn't crash after POST
            UserList = _userService.GetUsers();
            MediaList = _mediaService.GetApprovedMedia();

            foreach (Media media in MediaList)
            {
                User submittedBy = _userService.GetUserById(media.ContributorID);
                media.Contributor = submittedBy;
            }

            _organizerService.CreateMovieNight(Attendees, ChosenMediaID);



        }
    }
}

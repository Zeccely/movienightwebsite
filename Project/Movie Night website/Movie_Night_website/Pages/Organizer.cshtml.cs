using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Movie_Night_website.Models;
using Movie_Night_Website.Service;

namespace Movie_Night_website.Pages
{
    [Authorize] //needs to be authorized only to organizer role later
    public class OrganizerModel : PageModel
    {
        private readonly UserService _userService;
        public OrganizerModel(UserService userService)
        {
            _userService = userService;
        }

        public List<Media> MediaList { get; set; } = [];
        public List<User> Attendees { get; set; } = new List<User>();

        //might need to finalize votes manually here

        public void OnGet()
        {
           Attendees = _userService.GetUsers(); 
        }

        public void OnPost() 
        {
            //set final verdicts
            //create movienight object

        }
    }
}

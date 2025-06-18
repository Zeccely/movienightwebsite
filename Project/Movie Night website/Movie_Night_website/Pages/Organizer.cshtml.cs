using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Movie_Night_website.Models;

namespace Movie_Night_website.Pages
{
    [Authorize] //needs to be authorized only to organizer role later
    public class OrganizerModel : PageModel
    {
        public List<Media> MediaList { get; set; } = [];
        public List<User> Atendees { get; set; } = new List<User>();

        //might need to finalize votes manually here

        public void OnGet()
        {
            //get filtered list of approved media and all users in database
        }

        public void OnPost() 
        {
            //set final verdicts
            //create movienight object

        }
    }
}

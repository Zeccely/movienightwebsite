using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Movie_Night_website.Models;
using Movie_Night_website.Services;
using Movie_Night_Website.Domain.Interfaces;
using Movie_Night_Website.Service;

namespace Movie_Night_website.Pages
{
    [Authorize]
    public class VoteModel : PageModel
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string MediaTitle { get; set; }
        public string YoutubeLink { get; set; }
        public List<Media> MediaList { get; set; }

        [BindProperty]
        public bool Vote  { get; set; }

        public VotingService _votingService;
        public readonly UserService _userService;
        public VoteModel(VotingService votingService, UserService userService)
        {
            _votingService = votingService;
            _userService = userService;
        }

        public void OnGet()
        {
            int.TryParse(HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value, out int UserId);
            
            MediaList = _votingService.DisplayMedia();
            List<Media> filteredList = new();
            foreach (Media media in MediaList)
            {
                if (!_votingService.HasUserVoted(UserId, media.GetMediaID()))
                {
                    filteredList.Add(media);
                }
                User Submittedby = _userService.GetUserById(media.GetContributorID());
                Username = Submittedby.GetUserName();
            }

            MediaList = filteredList;
        }

        public async Task<IActionResult> OnPostAsync(int mediaId)
        {
            int.TryParse(HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value, out int UserId);
            _votingService.CastVote(UserId, mediaId, Vote);
            return RedirectToPage();
        }
    }
}

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

        private VotingService _votingService;
        
        public void OnGet()
        {
            int.TryParse(HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value, out int UserId);
            MediaList = _votingService.DisplayMedia();
        }

        public async Task<IActionResult> OnPostAsync(int movieId, bool vote)
        {
            _votingService.CastVote(UserId, movieId, vote);
            return RedirectToPage();
        }
    }
}

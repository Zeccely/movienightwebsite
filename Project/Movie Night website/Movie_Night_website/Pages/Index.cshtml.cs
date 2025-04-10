using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Data.Entity;

namespace Movie_Night_website.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly MovieNightDatabase database;

        public IndexModel(ILogger<IndexModel> logger, MovieNightDatabase database)
        {
            _logger = logger;
            this.database = database;
            
        }

        public int MovieCount { get; private set; }

        public void OnGet()
        {
            MovieCount = database.Movies.Count();

        }
    }
}

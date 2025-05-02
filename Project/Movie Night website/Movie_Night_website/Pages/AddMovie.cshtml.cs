using System.Data.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Movie_Night_website.Data;

namespace Movie_Night_website.Pages
{
    public class AddMovieModel : PageModel
    {
        private MovieNightDatabase _database;

        public AddMovieModel(MovieNightDatabase database)
        {
            _database = database;
        }

        [BindProperty]
        public string Title { get; set; }

        [BindProperty]
        public string TrailerURL { get; set; }

        [BindProperty]
        public string Type { get; set; }

        public void OnPost()
        {
            _database.AddMediaToDB(Title, TrailerURL, Type);
        }

        public void OnGet() 
        {
          

        }

    }
}

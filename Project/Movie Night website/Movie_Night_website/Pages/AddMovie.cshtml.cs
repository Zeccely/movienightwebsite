using System.Data.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Movie_Night_Website.DataAccess.Data;

namespace Movie_Night_website.Pages
{
    [Authorize]
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
        public int TypeID { get; set; }

        public int UserID { get; set; }

        public void OnPost()
        {
            _database.AddMediaToDB(Title, TrailerURL, TypeID, UserID);
        }

        public void OnGet() 
        {
          

        }

    }
}

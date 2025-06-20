using Movie_Night_Website.Domain.Interfaces;

namespace Movie_Night_website.Services
{
    public class OrganizerService
    {
        private IMovieNightRepository _movieNightRepo;

        public OrganizerService(IMovieNightRepository movieNightRepo)
        {
            _movieNightRepo = movieNightRepo;
        }

        public void CreateMovieNight(List<int> ids, int chosenMediaId)
        {
            _movieNightRepo.AddUsersToMovieNight(ids, chosenMediaId);
        }
    }
}

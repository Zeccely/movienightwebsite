using Movie_Night_website.Models;
using Movie_Night_Website.Domain.Interfaces;


namespace Movie_Night_website.Services
{
    public class OrganizerService
    {
        private IMovieNightRepository _movieNightRepo;
        private IMediaRepository _mediaRepo;
        Random rng = new Random();

        public OrganizerService(IMovieNightRepository movieNightRepo, IMediaRepository mediaRepository)
        {
            _movieNightRepo = movieNightRepo;
            _mediaRepo = mediaRepository;
        }

        public void CreateMovieNight(List<int> ids, int chosenMediaId)
        {
            _movieNightRepo.AddUsersToMovieNight(ids, chosenMediaId);
        }

        public Media GrabRandomMovie(List<Media> MediaList) //Should this be in mediaservice? this is unit testable!
        {
            
            MediaList = _mediaRepo.GetApprovedMedia();

            if (MediaList.Count == 0 || MediaList == null)
            {
                return null;
            }
            int randomindex = rng.Next(0, MediaList.Count);
            
            return MediaList[randomindex];

        }

    }
}

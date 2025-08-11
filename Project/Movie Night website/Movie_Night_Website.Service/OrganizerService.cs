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
            if (ids != null || chosenMediaId != 0)
            {
                _movieNightRepo.AddUsersAndCreateMovieNight(ids, chosenMediaId);
            }

        }

        public void CreateHistory(List<int> ids, int chosenMediaId)
        {
            if (ids != null && chosenMediaId != 0)
            {   
                foreach (int userId in ids)
                {
                    _movieNightRepo.AddToHistory(userId, chosenMediaId);
                }

            }
         
        }

        public Media GrabRandomMovie(List<Media> MediaList) //Should this be in mediaservice? this is unit testable!
        {
            
            MediaList = _mediaRepo.GetApprovedMedia();

            if (MediaList != null && MediaList.Count != 0)
            {
                int randomindex = rng.Next(0, MediaList.Count);
                Media ChosenMedia = _mediaRepo.GetMedia(MediaList[randomindex].GetMediaID());

                return ChosenMedia;
            }

            return null;
            

        }

    }
}

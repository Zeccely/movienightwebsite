
using Movie_Night_website.Models;

using Movie_Night_Website.Domain.Interfaces;

namespace Movie_Night_website.Services
{
    public class MediaService
    {
        private readonly IMediaRepository _mediaRepository;

        public MediaService (IMediaRepository mediaRepository)
        {
            _mediaRepository = mediaRepository;
        }

        public List<Media> TheCurrentList { get; set; } = [];

        public List<Media> WatchedMedia { get; set; } = [];

        public void AddMediaToDB(string title, string trailerURL, string mediaTypeText, int userID) //unit test this
        {
            int mediaTypeId;

            if (!_mediaRepository.CheckMediaType(mediaTypeText))
            {
                _mediaRepository.AddMediaType(mediaTypeText);
            }
            else
            {
                Console.WriteLine("That did not work or Mediatype exists");
            }
           
            mediaTypeId = _mediaRepository.GetMediaTypeID(mediaTypeText);

            _mediaRepository.AddMedia(title, trailerURL, mediaTypeId, userID);
        }

        public List<Media> GetAllMedia()
        {
           return _mediaRepository.GetAllMedia();
        }

        public List<Media> GetApprovedMedia()
        {
            return _mediaRepository.GetApprovedMedia();
        }

        public Media GetMedia(int id)
        {
            return _mediaRepository.GetMedia(id);
        }

    }


}

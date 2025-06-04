
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

        public List<Media> ContributedMedia { get; set; } = [];

        public List<Media> TheCurrentList { get; set; } = [];

        public List<Media> WatchedMedia { get; set; } = [];

        public void AddMediaToDB(string title, string trailerURL, string mediaTypeText, int userID)
        {
            int mediaTypeId;

            if (!_mediaRepository.CheckMediaType(mediaTypeText))
            {
                _mediaRepository.AddMediaType(mediaTypeText);
            }
            else
            {
                Console.WriteLine("That did not work");
            }
           

            mediaTypeId = _mediaRepository.GetMediaTypeID(mediaTypeText);

            _mediaRepository.AddMedia(title, trailerURL, mediaTypeId, userID);
        }


    }


}

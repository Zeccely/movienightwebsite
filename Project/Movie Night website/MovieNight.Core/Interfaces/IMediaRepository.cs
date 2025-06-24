using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Movie_Night_website.Models;

namespace Movie_Night_Website.Domain.Interfaces
{
    public interface IMediaRepository
    {
        void AddMedia(string title, string trailerURL, int mediatypeID, int userID);

        int GetMediaTypeIDFromMovie(string name);

        bool CheckMediaType(string mediaTypeName);

        void AddMediaType(string mediaTypeName);

        int GetMediaTypeID(string mediaTypeName);

        List<Media> GetAllMedia();

        List<Media> GetApprovedMedia();

        bool DidUserSubmitMedia(int userId, int mediaId);

        Media GetMedia(int mediaId);




    }
}

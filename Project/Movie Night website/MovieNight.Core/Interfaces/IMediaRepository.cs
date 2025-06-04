using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie_Night_Website.Domain.Interfaces
{
    public interface IMediaRepository
    {
        void AddMedia(string title, string trailerURL, int mediatypeID, int userID);

        int GetMediaTypeIDFromMovie(string name);

        bool CheckMediaType(string mediaTypeName);

        void AddMediaType(string mediaTypeName);

        int GetMediaTypeID(string mediaTypeName);
        





    }
}

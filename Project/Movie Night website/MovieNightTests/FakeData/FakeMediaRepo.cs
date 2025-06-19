using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Movie_Night_website.Models;
using Movie_Night_Website.Domain.Interfaces;

namespace MovieNightTests.FakeData
{
    public class FakeMediaRepo : IMediaRepository
    {
        public void AddMedia(string title, string trailerURL, int mediatypeID, int userID)
        {
            throw new NotImplementedException();
        }

        public void AddMediaType(string mediaTypeName)
        {
            throw new NotImplementedException();
        }

        public bool CheckMediaType(string mediaTypeName)
        {
            throw new NotImplementedException();
        }

        public List<Media> GetAllMedia()
        {
            throw new NotImplementedException();
        }

        public List<Media> GetApprovedMedia()
        {
            throw new NotImplementedException();
        }

        public int GetMediaTypeID(string mediaTypeName)
        {
            throw new NotImplementedException();
        }

        public int GetMediaTypeIDFromMovie(string name)
        {
            throw new NotImplementedException();
        }
    }
}

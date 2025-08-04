using System.CodeDom;

namespace Movie_Night_website.Models
{
    public class Media
    {
        private int MediaID { get; set; }
        private string TrailerURL { get; set; }
        private string Title { get; set; }
        private MediaType MediaType { get; set; } //hm..
        private int MediaTypeID { get; set; }
        private int ContributorID { get; set; }
        private User Contributor { get; set; } //hm...

        public Media (int mediaID, string trailerURL, string title, MediaType mediaType)
        {
            MediaID = mediaID;
            TrailerURL = trailerURL;
            Title = title;
            MediaType = mediaType;
        }

        public Media(int mediaID, string trailerURL, string title, int mediaTypeId, int contributorID)
        {
            MediaID = mediaID;
            TrailerURL = trailerURL;
            Title = title;
            MediaTypeID = mediaTypeId;
            ContributorID = contributorID;
        }

        public int GetMediaID()
        {
            return MediaID;
        }

        public void SetMediaId(int mediaID)
        {
            MediaID = mediaID;
        }

        public string GetTrailerURL() { return TrailerURL; }
        public void SetTrailerURL(string trailerURL) {  TrailerURL = trailerURL; }
        public string GetTitle() { return Title; }
        public void SetTitle(string title) { Title = title; }
        public int GetMediaTypeID() { return MediaTypeID; }
        public void SetMediaTypeID(int mediaTypeID) { MediaTypeID = mediaTypeID; }
        public int GetContributorID() { return ContributorID; }



    }
}

using Microsoft.AspNetCore.Mvc.Formatters;

namespace Movie_Night_website.Models
{
    public class ContenderMedia 
    {
        private int _id;

        public int UserID;

        public int MediaID;

        public bool Votedin;

        public MediaType MediaType;
     
    }
}

public enum MediaType
{
    Movie,
    Series
}



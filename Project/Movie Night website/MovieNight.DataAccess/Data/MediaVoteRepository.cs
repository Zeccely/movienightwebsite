using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie_Night_Website.DataAccess.Data
{
    public class MediaVoteRepository
    {
        private string connectionString;

        public MediaVoteRepository(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("LaptopConnection");
        }

        public int GetMediaVotes() 
        {
            string query = " Select Liked from UserVotes where Media_Id = @MediaId";
            return 0;

        }

        public void CastVote(int userID, int mediaID, bool vote)
        {
            string query = "Insert into UserVote (User_Id, Media_Id, Liked) Values (@UserID, @MediaID, @Vote ";
        }

        public int TallyVotes()
        {
            return 0; // count here or should I just count on the get media votes?
        }
    }
}

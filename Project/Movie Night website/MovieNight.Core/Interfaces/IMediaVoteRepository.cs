using Movie_Night_website.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie_Night_Website.Domain.Interfaces
{
    public interface IMediaVoteRepository
    {
        void CastVote(int userId, int mediaId, bool vote); //add vote from user to this media

        int GetPositiveVotes(int mediaId); 

        int GetNegativeVotes(int mediaId);

        void UpdateFinalVerdict(int mediaId, bool? verdict);

        void ResetFinalVerdict(int mediaId);

        bool UserVoteCheck(int userId, int mediaId); 


    }
}

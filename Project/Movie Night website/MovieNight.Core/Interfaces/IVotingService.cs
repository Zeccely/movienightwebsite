using Movie_Night_website.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie_Night_Website.Domain.Interfaces
{
    public interface IVotingService
    {
        void CastVote();

        void CastVeto();

        int GetVotes(Media media);

        int GetVetoes(Media media);

        void EvaluateVotes(Media media);

        void UserVoteCheck(User user, Media media);


    }
}

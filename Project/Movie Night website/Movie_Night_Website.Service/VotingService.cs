using Movie_Night_website.Models;
using Movie_Night_Website.Domain.Interfaces;

namespace Movie_Night_website.Services
{
    public class VotingService : IVotingService
    {
        private IMediaRepository _mediaRepository;

        public VotingService(IMediaRepository mediaRepository)
        {
            _mediaRepository = mediaRepository;
        }
        public void CastVote()
        {

        }

        public void CastVeto()
        {

        }

        public int GetVotes(Media media)
        {
            return 0;
        }

        public int GetVetoes(Media media)
        {
            return 0;
        }

        public void EvaluateVotes(Media media) 
        {

        }

        public void UserVoteCheck(User user, Media media) 
        {

        }
    }
}

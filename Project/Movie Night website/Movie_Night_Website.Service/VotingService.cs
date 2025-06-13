using Movie_Night_website.Models;
using Movie_Night_Website.Domain.Interfaces;

namespace Movie_Night_website.Services
{
    public class VotingService : IMediaVoteRepository
    {
        private IMediaRepository _mediaRepository;

        public VotingService(IMediaRepository mediaRepository)
        {
            _mediaRepository = mediaRepository;
        }
        public void CastVote()
        {

        }

        public void EvaluateVotes(Media media) 
        {

        }

        public void UserVoteCheck(User user, Media media) 
        {

        }
    }
}

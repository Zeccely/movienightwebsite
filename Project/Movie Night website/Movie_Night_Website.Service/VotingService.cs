using Movie_Night_website.Models;
using Movie_Night_Website.Domain.Interfaces;

namespace Movie_Night_website.Services
{
    public class VotingService 
    {
        private IMediaVoteRepository _mediaVoteRepository;
        private readonly IMediaRepository _mediaRepository;

        public VotingService(IMediaVoteRepository mediaVoteRepository, IMediaRepository mediaRepository)
        {
            _mediaVoteRepository = mediaVoteRepository;
            _mediaRepository = mediaRepository;
        }
        public void CastVote(int userId, int mediaId, bool vote)
        {
            _mediaVoteRepository.CastVote(userId, mediaId, vote);
            EvaluateVotes(mediaId);
        }

        public void EvaluateVotes(int mediaId) //unit test this
        {
            int positiveVotes = _mediaVoteRepository.GetPositiveVotes(mediaId);
            int negativeVotes = _mediaVoteRepository.GetNegativeVotes(mediaId);
            int totalVotes = positiveVotes + negativeVotes;

            if (totalVotes <= 3) 
            {
                return;
            };

            if (positiveVotes > negativeVotes)
            {
                _mediaVoteRepository.SetFinalVerdict(mediaId, true);
                
            }
            else if (negativeVotes > positiveVotes)
            {
                _mediaVoteRepository.SetFinalVerdict(mediaId, false);
            }
            return;
        }

        public List<Media> DisplayMedia() 
        {
            List<Media> mediaList = _mediaRepository.GetAllMedia();
            return mediaList;
        }

        public bool HasUserVoted(int userId, int mediaId)
        {
            return _mediaVoteRepository.UserVoteCheck(userId, mediaId);
        }
    }
}

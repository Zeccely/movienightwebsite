using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie_Night_Website.Domain.Interfaces
{
    public interface IMovieNightRepository
    {

        void CreateMovieNight(int movieId);

        void AddUsersToMovieNight(List<int> userIds, int mediaId);

        void RemoveUserFromMovieNight(int userId, int movieNightId);


    }
}

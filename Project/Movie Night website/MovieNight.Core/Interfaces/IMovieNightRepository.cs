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

        void AddUserToMovieNight(int userId, int movieNightId);

        void RemoveUserFromMovieNight(int userId, int movieNightId);


    }
}

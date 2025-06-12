using MoviesAPI.Http;

namespace MoviesAPI.Service
{
    public interface IMovieService
    {
        Task<List<MovieResponse>> GetAllMovies();
        Task<MovieResponse?> GetMovieById(int id);
        Task<MovieResponse> CreateMovie(MovieRequest request);
        Task<bool> DeleteMovie(int id);
    }
}

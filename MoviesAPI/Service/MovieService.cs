using MoviesAPI.Http;

namespace MoviesAPI.Service
{
    public class MovieService : IMovieService
    {
        private readonly List<MovieResponse> _movies = new()
        {
            new MovieResponse { Id = 1, Title = "The Shawshank Redemption", Genre = "Drama", Year = 1994 },
            new MovieResponse { Id = 2, Title = "The Godfather", Genre = "Crime", Year = 1972 },
            new MovieResponse { Id = 3, Title = "The Dark Knight", Genre = "Action", Year = 2008 },
            new MovieResponse { Id = 4, Title = "Pulp Fiction", Genre = "Crime", Year = 1994 },
            new MovieResponse { Id = 5, Title = "Forrest Gump", Genre = "Drama", Year = 1994 },
            new MovieResponse { Id = 6, Title = "Inception", Genre = "Sci-Fi", Year = 2010 },
            new MovieResponse { Id = 7, Title = "Fight Club", Genre = "Drama", Year = 1999 },
            new MovieResponse { Id = 8, Title = "The Matrix", Genre = "Sci-Fi", Year = 1999 },
            new MovieResponse { Id = 9, Title = "Interstellar", Genre = "Sci-Fi", Year = 2014 },
            new MovieResponse { Id = 10, Title = "Gladiator", Genre = "Action", Year = 2000 }
        };
        private static int _nextId = 11;

        public Task<List<MovieResponse>> GetAllMovies() =>
          Task.FromResult(_movies);

        public Task<MovieResponse?> GetMovieById(int id) =>
          Task.FromResult(_movies.FirstOrDefault(m => m.Id == id));

        public Task<MovieResponse> CreateMovie(MovieRequest request)
        {
            var movie = new MovieResponse
            {
                Id = _nextId++,
                Title = request.Title,
                Genre = request.Genre,
                Year = request.Year,
                Slug = request.Title.ToLower().Replace(" ", "-")
            };

            _movies.Add(movie);
            return Task.FromResult(movie);
        }


        public Task<bool> DeleteMovie(int id)
        {
            var movie = _movies.FirstOrDefault(m => m.Id == id);
            if (movie is null) return Task.FromResult(false);

            _movies.Remove(movie);
            return Task.FromResult(true);
        }
    }
}

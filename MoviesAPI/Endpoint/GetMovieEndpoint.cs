using FastEndpoints;
using MoviesAPI.Http;
using MoviesAPI.Service;

namespace MoviesAPI.Endpoint
{
    public class GetAllMoviesEndpoint : EndpointWithoutRequest<List<MovieResponse>>
    {
        private readonly IMovieService _service;

        public GetAllMoviesEndpoint(IMovieService service) => _service = service;

        public override void Configure()
        {
            Get("/movies");
            AllowAnonymous();
        }

        public override async Task HandleAsync(CancellationToken ct)
        {
            var movies = await _service.GetAllMovies();
            await SendOkAsync(movies, ct);
        }
    }
}

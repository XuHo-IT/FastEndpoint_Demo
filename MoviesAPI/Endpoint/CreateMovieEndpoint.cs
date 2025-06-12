using FastEndpoints;
using MoviesAPI.Http;
using MoviesAPI.Service;

namespace MoviesAPI.Endpoint
{
    public class CreateMovieEndpoint : Endpoint<MovieRequest, MovieResponse>
    {
        private readonly IMovieService _service;

        public CreateMovieEndpoint(IMovieService service) => _service = service;

        public override void Configure()
        {
            Post("/movies");
            AllowAnonymous();
        }

        public override async Task HandleAsync(MovieRequest req, CancellationToken ct)
        {
            var movie = await _service.CreateMovie(req);
            await SendCreatedAtAsync<GetMovieByIdEndpoint>(new { id = movie.Id }, movie, cancellation: ct);
        }
    }
}

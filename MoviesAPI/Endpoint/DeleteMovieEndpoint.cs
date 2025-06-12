using FastEndpoints;
using MoviesAPI.Service;

namespace MoviesAPI.Endpoint
{
    public class DeleteMovieEndpoint : Endpoint<int>
    {
        private readonly IMovieService _service;

        public DeleteMovieEndpoint(IMovieService service) => _service = service;

        public override void Configure()
        {
            Delete("/movies/{id}");
            AllowAnonymous();
        }

        public override async Task HandleAsync(int id, CancellationToken ct)
        {
            var success = await _service.DeleteMovie(id);
            if (!success)
                await SendNotFoundAsync(ct);
            else
                await SendOkAsync(ct);
        }
    }
}

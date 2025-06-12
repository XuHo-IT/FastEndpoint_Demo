using FastEndpoints;
using MoviesAPI.Http;
using MoviesAPI.Service;

public class GetMovieByIdEndpoint : Endpoint<GetMovieByIdRequest, MovieResponse>
{
    private readonly IMovieService _service;

    public GetMovieByIdEndpoint(IMovieService service) => _service = service;

    public override void Configure()
    {
        Get("/movies/{id}");
        AllowAnonymous();
    }

    public override async Task HandleAsync(GetMovieByIdRequest req, CancellationToken ct)
    {
        var movie = await _service.GetMovieById(req.Id);
        if (movie is null)
            await SendNotFoundAsync(ct);
        else
            await SendOkAsync(movie, ct);
    }
}

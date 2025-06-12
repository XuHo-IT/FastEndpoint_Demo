using Microsoft.AspNetCore.Mvc;

namespace MoviesAPI.Http
{
    public class GetMovieByIdRequest
    {
        [FromRoute]
        public int Id { get; set; }
    }

}

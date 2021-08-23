using Microsoft.AspNetCore.Mvc;
using StackOverflow.Application.Features.Posts.Queries;
using System.Threading.Tasks;

namespace StackOverflow.WebApi.Controllers.v1
{
    public class PostController : BaseApiController
    {
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] GetPostsParameter filter)
        {
            var response = await Mediator.Send(new GetPostsQuery() { PageSize = filter.PageSize, PageNumber = filter.PageNumber });
            return Ok(response);
        }
    }
}

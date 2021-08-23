using AutoMapper;
using MediatR;
using StackOverflow.Application.DTOs.Post;
using StackOverflow.Application.Filters;
using StackOverflow.Application.Interfaces.Repositories;
using StackOverflow.Application.Wrappers;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace StackOverflow.Application.Features.Posts.Queries
{
    public record GetPostsParameter : RequestParameter
    {

    }

    public class GetPostsQuery : IRequest<PagedResponse<IEnumerable<PostDto>>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }

    public class GetPostsQueryHandler : IRequestHandler<GetPostsQuery, PagedResponse<IEnumerable<PostDto>>>
    {
        private readonly IPostRepository _postRepository;

        public GetPostsQueryHandler(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        public async Task<PagedResponse<IEnumerable<PostDto>>> Handle(GetPostsQuery request, CancellationToken cancellationToken)
        {
            int skip = (request.PageNumber - 1) * request.PageSize;
            int take = request.PageSize;
            var postPage = await _postRepository.GetPosts(skip, take);

            return new PagedResponse<IEnumerable<PostDto>>(postPage, request.PageNumber, request.PageSize);
        }
    }
}

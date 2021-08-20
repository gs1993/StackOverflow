using MediatR;
using StackOverflow.Application.Filters;
using System;
using System.Collections.Generic;
using System.Text;

namespace StackOverflow.Application.Features.Products.Queries.GetPosts
{
    public class GetPostsParameter : RequestParameter
    {

    }

    public class GetPostsQuery : IRequest<PagedResponse<IEnumerable<GetAllProductsViewModel>>>
    {
    }
}

using StackOverflow.Application.DTOs.Post;
using StackOverflow.Application.Interfaces.Utils;
using StackOverflow.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StackOverflow.Application.Interfaces.Repositories
{
    public interface IPostRepository : IGenericRepository<Post>
    {
        public Task<IEnumerable<PostDto>> GetPosts(int skip, int take, int maxTitleLength);
        public Task<long> FastApproximateCount();
    }
}

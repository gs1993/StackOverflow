using Microsoft.EntityFrameworkCore;
using StackOverflow.Application.DTOs.Post;
using StackOverflow.Application.Interfaces.Repositories;
using StackOverflow.Domain.Entities;
using StackOverflow.Infrastructure.Persistence.Contexts;
using StackOverflow.Infrastructure.Persistence.Repository;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StackOverflow.Infrastructure.Persistence.Repositories
{
    public class PostRepository : GenericRepositoryAsync<Post>, IPostRepository
    {
        public PostRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }


        public async Task<IEnumerable<PostDto>> GetPosts(int skip, int take)
        {
            return await _dbContext.Posts
                .AsNoTracking()
                .Skip(skip)
                .Take(take)
                .OrderBy(p => p.Id)
                .Select(p => new PostDto
                {
                    Id = p.Id,
                    Title = p.Title,
                    Body = p.Body,
                    OwnerUserName = "Jeff Atwood",
                    IsClosed = p.ClosedDate.HasValue,
                    ClosedDate = p.ClosedDate,
                    CreationDate = p.CreationDate,
                    AnswerCount = p.AnswerCount ?? 0,
                    CommentCount = p.CommentCount ?? 0,
                    ViewCount = p.ViewCount,
                    PostType = "Question",
                    Score = p.Score
                }).ToListAsync();
        }

        public async Task<long> FastApproximateCount()
        {
            using (var command = _dbContext.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = @"
SELECT
   Total_Rows= SUM(st.row_count)
FROM
   sys.dm_db_partition_stats st
WHERE
    object_name(object_id) = 'Posts'";
                await _dbContext.Database.OpenConnectionAsync();
                using (var result = await command.ExecuteReaderAsync())
                {
                    if (result.Read())
                        return result.GetInt64(0);
                }
            }

            return 0;
        }
    }
}

using System;

namespace StackOverflow.Application.DTOs.Post
{
    public record PostDto
    {
        public long Id { get; init; }
        public string Title { get; init; }
        public string OwnerUserName { get; init; }
        public string PostType { get; init; }
        public bool IsClosed { get; init; }
        public DateTime CreationDate { get; init; }
        public DateTime? ClosedDate { get; init; }
        public int Score { get; init; }
        public int CommentCount { get; init; }
        public int AnswerCount { get; init; }
        public int ViewCount { get; init; }
    }
}

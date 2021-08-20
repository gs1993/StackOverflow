using CSharpFunctionalExtensions;
using System;

namespace StackOverflow.Domain.Entities
{
    public class Post : Entity
    {
        public int? AcceptedAnswerId { get; private set; }
        public int? AnswerCount { get; private set; }
        public string Body { get; private set; }
        public DateTime? ClosedDate { get; private set; }
        public int? CommentCount { get; private set; }
        public DateTime? CommunityOwnedDate { get; private set; }
        public DateTime CreationDate { get; private set; }
        public int? FavoriteCount { get; private set; }
        public DateTime LastActivityDate { get; private set; }
        public DateTime? LastEditDate { get; private set; }
        public string LastEditorDisplayName { get; private set; }
        public int? LastEditorUserId { get; private set; }
        public int? OwnerUserId { get; private set; }
        public int? ParentId { get; private set; }
        public int PostTypeId { get; private set; }
        public int Score { get; private set; }
        public string Tags { get; private set; }
        public string Title { get; private set; }
        public int ViewCount { get; private set; }
    }
}

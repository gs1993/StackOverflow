using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;

namespace StackOverflow.Domain.Entities
{
    public class User : Entity<int>
    {
        public string AboutMe { get; set; }
        public int? Age { get; set; }
        public DateTime CreationDate { get; set; }
        public string DisplayName { get; set; }
        public DateTime LastAccessDate { get; set; }
        public string Location { get; set; }
        public int Reputation { get; set; }
        public int Views { get; set; }
        public string WebsiteUrl { get; set; }

        public IEnumerable<Post> Posts { get; private set; }
    }
}

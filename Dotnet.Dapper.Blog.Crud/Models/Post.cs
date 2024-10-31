﻿using Dapper.Contrib.Extensions;
using Dotnet.Dapper.Blog.Crud.Models;

namespace Dotnet.Dapper.Blog.Crud.Models
{
    [Table("[Post]")]
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Summary { get; set; }
        public string Body { get; set; }
        public string Slug { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime LastUpdateDate { get; set; }

        public int AuthorId { get; set; }
        [Write(false)]
        public User Author { get; set; }

        public int CategoryId { get; set; }
        [Write(false)]
        public Category Category { get; set; }

        [Write(false)]
        public List<Tag> Tags { get; set; }

        public Post()
        {
            Tags = new List<Tag>();
        }
    }
}
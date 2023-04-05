using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogPostApp.AppCode
{
    public sealed partial class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int AuthorId { get; set; }
        public DateTime PublishedAt { get; set; }

        public Post()
        {
            Id = new Random().Next(100, 999) + Database.posts.Count;
        }

        public Post(string title, string description, int authorId):this()
        {
            Title = title;
            Description = description;
            AuthorId = authorId;
            PublishedAt = DateTime.Now;
        }

        public Post(int id, string title, string description, int authorId)
        {
            Id = id;
            Title = title;
            Description = description;
            AuthorId = authorId;
            PublishedAt = DateTime.Now;
        }

    }
}

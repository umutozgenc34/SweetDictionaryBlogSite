﻿
using Core.Entities;
using System.Reflection.Metadata;

namespace SweetDictionaryBlogSite.Models.Entities;

public sealed class Post : Entity<Guid>
{
    public string Title { get; set; }
    public string Content { get; set; }
    public string AuthorId { get; set; }
    public User Author { get; set; }
    public int CategoryId { get; set; }
    public Category Category { get; set; }
    public List<Comment> Comments { get; set; }
}

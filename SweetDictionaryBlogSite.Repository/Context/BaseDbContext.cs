

using Microsoft.EntityFrameworkCore;
using SweetDictionaryBlogSite.Models.Entities;

namespace SweetDictionaryBlogSite.Repository.Context;

public class BaseDbContext : DbContext
{
    public BaseDbContext(DbContextOptions opt): base(opt)
    {
        
    }

    public DbSet<Post> Posts { get; set; }
}



using Microsoft.EntityFrameworkCore;
using SweetDictionaryBlogSite.Models.Entities;
using SweetDictionaryBlogSite.Repository.Configurations;
using System.Reflection;

namespace SweetDictionaryBlogSite.Repository.Context;

public class BaseDbContext : DbContext
{
    public BaseDbContext(DbContextOptions opt): base(opt)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Post> Posts { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Comment> Comments { get; set; }
}

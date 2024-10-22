

using Core.Repository;
using SweetDictionaryBlogSite.Models.Entities;
using SweetDictionaryBlogSite.Repository.Context;
using SweetDictionaryBlogSite.Repository.Repositories.Abstracts;

namespace SweetDictionaryBlogSite.Repository.Repositories.Concretes;

public class EfPostRepository : EfRepositoryBase<BaseDbContext, Post, Guid>, IPostRepository
{
    public EfPostRepository(BaseDbContext context) : base(context)
    {
    }

    
}

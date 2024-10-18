

using Core.Repository;
using SweetDictionaryBlogSite.Models.Entities;

namespace SweetDictionaryBlogSite.Repository.Repositories.Abstracts;

public interface IPostRepository : IRepository<Post,Guid>
{
    List<Post> GetAllByCategoryId(int categoryId);
    List<Post> GetAllByAuthorId (long  authorId);
    List<Post> GetAllByTitleContains(string text);

}

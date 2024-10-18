

using Core.Exceptions;
using SweetDictionaryBlogSite.Repository.Repositories.Abstracts;

namespace SweetDictionaryBlogSite.Service.Rules;

public class PostBusinessRules(IPostRepository _postRepository)
{
    public void PostIsPresent(Guid id)
    {
        var post = _postRepository.GetById(id);
        if (post is null)
        {
            throw new NotFoundException($"İlgili Id ye göre post bulunamadı : {id}");
        }
    }
}

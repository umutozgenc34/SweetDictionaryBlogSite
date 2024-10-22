

using Core.Exceptions;
using SweetDictionaryBlogSite.Repository.Repositories.Abstracts;
using SweetDictionaryBlogSite.Service.Constants;

namespace SweetDictionaryBlogSite.Service.Rules;

public class PostBusinessRules(IPostRepository _postRepository)
{
    public void PostIsPresent(Guid id)
    {
        var post = _postRepository.GetById(id);
        if (post is null)
        {
            throw new NotFoundException(Messages.PostIsNotPresentMessage(id));
        }
    }
}

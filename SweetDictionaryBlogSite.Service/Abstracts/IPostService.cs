

using Core.Entities;
using SweetDictionaryBlogSite.Models.Entities;
using SweetDictionaryBlogSite.Models.Posts;

namespace SweetDictionaryBlogSite.Service.Abstracts;

public interface IPostService
{
    ReturnModel<PostResponseDto> Add(CreatePostRequestDto dto);
    ReturnModel<List<PostResponseDto>> GetAll();

    ReturnModel<PostResponseDto> GetById(Guid id);
}

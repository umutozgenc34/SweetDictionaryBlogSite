

using Core.Entities;
using SweetDictionaryBlogSite.Models.Entities;
using SweetDictionaryBlogSite.Models.Posts;

namespace SweetDictionaryBlogSite.Service.Abstracts;

public interface IPostService
{
    ReturnModel<PostResponseDto> Add(CreatePostRequestDto dto);
    ReturnModel<List<PostResponseDto>> GetAll();

    ReturnModel<PostResponseDto> GetById(Guid id);
    ReturnModel<PostResponseDto> Update(UpdatePostRequestDto dto);
    ReturnModel<string> Delete(Guid id);
    ReturnModel<List<PostResponseDto>> GetAllByCategoryId(int categoryId);
    ReturnModel<List<PostResponseDto>> GetAllByAuthorId(string authorId);
    ReturnModel<List<PostResponseDto>> GetAllByTitleContains(string text);
}

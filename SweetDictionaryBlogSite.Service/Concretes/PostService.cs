

using AutoMapper;
using Core.Entities;
using Core.Exceptions;
using SweetDictionaryBlogSite.Models.Entities;
using SweetDictionaryBlogSite.Models.Posts;
using SweetDictionaryBlogSite.Repository.Repositories.Abstracts;
using SweetDictionaryBlogSite.Service.Abstracts;
using SweetDictionaryBlogSite.Service.Rules;

namespace SweetDictionaryBlogSite.Service.Concretes;

public sealed class PostService : IPostService
{
    private readonly IPostRepository _postRepository;
    private readonly IMapper _mapper;
    private readonly PostBusinessRules _businessRules;

    public PostService(IPostRepository postRepository, IMapper mapper, PostBusinessRules businessRules)
    {
        _postRepository = postRepository;
        _mapper = mapper;
        _businessRules = businessRules;
    }

    public ReturnModel<PostResponseDto> Add(CreatePostRequestDto dto)
    {
        Post createdPost = _mapper.Map<Post>(dto);
        createdPost.Id = Guid.NewGuid();

        Post post = _postRepository.Add(createdPost);
        PostResponseDto response = _mapper.Map<PostResponseDto>(post);

        return new ReturnModel<PostResponseDto>
        {
            Data = response,
            Message = "Post Eklendi",
            Status = 200,
            Success = true
        };
    }

    public ReturnModel<string> Delete(Guid id)
    {
        _businessRules.PostIsPresent(id);

        Post? post = _postRepository.GetById(id);
        Post deletedPost = _postRepository.Delete(post);

        return new ReturnModel<string>
        {
            Data = $"Post Başlığı : {deletedPost.Title}",
            Message = "Post silindi",
            Status = 204,
            Success = true
        };
    }

    public ReturnModel<List<PostResponseDto>> GetAll()
    {
        var posts = _postRepository.GetAll();
        List<PostResponseDto> responses = _mapper.Map<List<PostResponseDto>>(posts);
        return new ReturnModel<List<PostResponseDto>>
        {
            Data = responses,
            Message = string.Empty,
            Status = 200,
            Success = true

        };

    }

    public ReturnModel<List<PostResponseDto>> GetAllByAuthorId(long authorId)
    {
        List<Post> posts = _postRepository.GetAllByAuthorId(authorId);
        List<PostResponseDto> responses = _mapper.Map<List<PostResponseDto>>(posts);

        return new ReturnModel<List<PostResponseDto>>
        {
            Data = responses,
            Message = $"Yazar Idsine göre Postlar Listelendi : Yazar Id: {authorId}",
            Status = 200,
            Success = true
        };
    }

    public ReturnModel<List<PostResponseDto>> GetAllByCategoryId(int categoryId)
    {
        List<Post> posts = _postRepository.GetAllByCategoryId(categoryId);
        List<PostResponseDto> responses = _mapper.Map<List<PostResponseDto>>(posts);

        return new ReturnModel<List<PostResponseDto>>
        {
            Data = responses,
            Message = $"CategoryIdsine göre Postlar Listelendi : Yazar Id: {categoryId}",
            Status = 200,
            Success = true
        };

    }

    public ReturnModel<List<PostResponseDto>> GetAllByTitleContains(string text)
    {
        List<Post> posts = _postRepository.GetAllByTitleContains(text);
        List<PostResponseDto> responses = _mapper.Map<List<PostResponseDto>>(posts);

        return new ReturnModel<List<PostResponseDto>>
        {
            Data = responses,
            Message = string.Empty,
            Status = 200,
            Success = true
        };
    }

    public ReturnModel<PostResponseDto> GetById(Guid id)
    {
        try
        {
            _businessRules.PostIsPresent(id);

            var post = _postRepository.GetById(id);
            PostResponseDto response = _mapper.Map<PostResponseDto>(post);
            return new ReturnModel<PostResponseDto>
            {
                Data = response,
                Message = "İlgili post gösterildi",
                Status = 200,
                Success = true
            };
        }
        catch (Exception ex)
        {

            return ExceptionHandler<PostResponseDto>.HandleException(ex);

        }

    }

    public ReturnModel<PostResponseDto> Update(UpdatePostRequestDto dto)
    {
        try
        {
            _businessRules.PostIsPresent(dto.Id);
            Post post = _mapper.Map<Post>(dto);
            Post updatedPost = _postRepository.Update(post);

            PostResponseDto response = _mapper.Map<PostResponseDto>(updatedPost);
            return new ReturnModel<PostResponseDto>
            {
                Data = response,
                Message = "Post Güncellendi",
                Status = 200,
                Success = true
            };

        }
        catch (Exception ex)
        {
            return ExceptionHandler<PostResponseDto>.HandleException(ex);
            
        }
       
    }


}

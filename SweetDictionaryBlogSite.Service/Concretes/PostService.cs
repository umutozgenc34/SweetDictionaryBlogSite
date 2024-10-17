

using AutoMapper;
using Core.Entities;
using SweetDictionaryBlogSite.Models.Entities;
using SweetDictionaryBlogSite.Models.Posts;
using SweetDictionaryBlogSite.Repository.Repositories.Abstracts;
using SweetDictionaryBlogSite.Service.Abstracts;

namespace SweetDictionaryBlogSite.Service.Concretes;

public sealed class PostService : IPostService
{
    private readonly IPostRepository _postRepository;

    private readonly IMapper _mapper;

    public PostService(IPostRepository postRepository, IMapper mapper)
    {
        _postRepository = postRepository;
        _mapper = mapper;
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

    public ReturnModel<PostResponseDto> GetById(Guid id)
    {
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
}

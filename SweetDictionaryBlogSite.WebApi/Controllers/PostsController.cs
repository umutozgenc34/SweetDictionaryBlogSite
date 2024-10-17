using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SweetDictionaryBlogSite.Models.Posts;
using SweetDictionaryBlogSite.Service.Abstracts;

namespace SweetDictionaryBlogSite.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PostsController(IPostService postService) : ControllerBase
{
    private readonly IPostService _postService;

    [HttpGet("getall")]
    public IActionResult GetAll()
    {
        var result = _postService.GetAll();
        return Ok(result);
    }

    [HttpPost("add")]
    public IActionResult Add([FromBody] CreatePostRequestDto dto)
    {
        var result = _postService.Add(dto);
        return Ok(result);
    }

    [HttpGet("getbyid/{id:guid}")]
    public IActionResult GetById([FromRoute] Guid id)
    {
        var result = _postService.GetById(id);
        return Ok(result);
    }
    
}

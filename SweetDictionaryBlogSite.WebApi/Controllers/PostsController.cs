using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SweetDictionaryBlogSite.Models.Posts;
using SweetDictionaryBlogSite.Service.Abstracts;

namespace SweetDictionaryBlogSite.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PostsController(IPostService _postService) : ControllerBase
{


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

    [HttpPut("Update")]
    public IActionResult Update([FromBody] UpdatePostRequestDto dto)
    {
        var result = _postService.Update(dto);
        return Ok(result);
    }
    [HttpGet("getallbycategoryid")]
    public IActionResult GetAllByCategoryId(int id)
    {
        var result = _postService.GetAllByCategoryId(id);
        return Ok(result);
    }
    [HttpGet("getallbyauthorid")]
    public IActionResult GetAllByAuthorId(long id)
    {
        var result = _postService.GetAllByAuthorId(id);
        return Ok(result);
    }
    [HttpGet("getallbytitlecontains")]
    public IActionResult GetAllByTitleContains(string text)
    {
        var result = _postService.GetAllByTitleContains(text);
        return Ok(result);
    }
}

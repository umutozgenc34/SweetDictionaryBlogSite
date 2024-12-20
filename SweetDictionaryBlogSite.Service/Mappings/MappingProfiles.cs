﻿

using AutoMapper;
using SweetDictionaryBlogSite.Models.Entities;
using SweetDictionaryBlogSite.Models.Posts;

namespace SweetDictionaryBlogSite.Service.Mappings;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CreatePostRequestDto,Post>();
        CreateMap<UpdatePostRequestDto, Post>();
        CreateMap<Post, PostResponseDto>();
    }
}

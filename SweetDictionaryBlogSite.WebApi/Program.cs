using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SweetDictionaryBlogSite.Models.Entities;
using SweetDictionaryBlogSite.Repository.Context;
using SweetDictionaryBlogSite.Repository.Repositories.Abstracts;
using SweetDictionaryBlogSite.Repository.Repositories.Concretes;
using SweetDictionaryBlogSite.Service.Abstracts;
using SweetDictionaryBlogSite.Service.Concretes;
using SweetDictionaryBlogSite.Service.Mappings;
using SweetDictionaryBlogSite.Service.Rules;
using SweetDictionaryBlogSite.WebApi.Middlewares;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddScoped<IPostService,PostService>();
builder.Services.AddScoped<IPostRepository,EfPostRepository>();

builder.Services.AddScoped<IUserService,UserService>();

builder.Services.AddScoped<PostBusinessRules>();
builder.Services.AddDbContext<BaseDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("SqlCon")));
builder.Services.AddAutoMapper(typeof(MappingProfiles));

builder.Services.AddExceptionHandler<GlobalExceptionHandler>();

builder.Services.AddIdentity<User,IdentityRole>(opt =>
{
    opt.User.RequireUniqueEmail = true;
    opt.Password.RequireNonAlphanumeric = false;

}).AddEntityFrameworkStores<BaseDbContext>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseExceptionHandler(_ => { });
app.MapControllers();

app.Run();

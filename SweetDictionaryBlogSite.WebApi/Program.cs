using SweetDictionaryBlogSite.Repository.Context;
using SweetDictionaryBlogSite.Repository.Repositories.Abstracts;
using SweetDictionaryBlogSite.Repository.Repositories.Concretes;
using SweetDictionaryBlogSite.Service.Abstracts;
using SweetDictionaryBlogSite.Service.Concretes;
using SweetDictionaryBlogSite.Service.Mappings;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddScoped<IPostService,PostService>();
builder.Services.AddScoped<IPostRepository,EfPostRepository>();
builder.Services.AddDbContext<BaseDbContext>();
builder.Services.AddAutoMapper(typeof(MappingProfiles));
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

app.MapControllers();

app.Run();

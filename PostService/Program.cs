using Microsoft.EntityFrameworkCore;
using PostService.BusinessLogic;
using PostService.DataAccess;
using PostService.Dtos;
using PostService.Mappings;

var builder = WebApplication.CreateBuilder(args);

builder.WebHost.UseUrls("http://localhost:5055");

builder.Services.AddDbContext<PostingDbContext>();
builder.Services.AddScoped<IPostingRepository, PostingRepository>();
builder.Services.AddScoped<IPostingService, PostingService>();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<PostingDbContext>();
    dbContext.Database.EnsureCreated();
}

app.MapGet("/", () => "Hello World!");

app.MapGet("/postings", (IPostingService service) =>
{
    var postings = service.GetAll();
    var dtos = new List<PostingGetDto>();
    foreach (var item in postings)
    {
        dtos.Add(PostingMapper.ToPostingGetDto(item));
    }
    return Results.Ok(dtos);
});

app.MapGet("/postings/{id:int}", (int id, IPostingService service) =>
{
    var posting = service.Find(id);
    if (posting is null)
        return Results.NotFound();

    return Results.Ok(PostingMapper.ToPostingGetDto(posting));
});

app.MapPost("/postings", (PostingPostDto postDto, IPostingService service) =>
{
    var newPosting = PostingMapper.ToPosting(postDto);
    var saved = service.Create(newPosting);
    var resultDto = PostingMapper.ToPostingGetDto(saved);

    return Results.Created($"/postings/{resultDto.Id}", resultDto);
});

app.MapPut("/postings/{id:int}", (int id, PostingPutDto putDto, IPostingService service) =>
{
    putDto.Id = id;
    var model = PostingMapper.ToPosting(putDto);
    var updated = service.Update(model);

    if (updated is null)
        return Results.NotFound();

    return Results.Ok(PostingMapper.ToPostingGetDto(updated));
});

app.MapDelete("/postings/{id:int}", (int id, IPostingService service) =>
{
    int deletedCount = service.Delete(id);
    if (deletedCount == 0)
        return Results.NotFound();

    return Results.NoContent();
});

app.Run();
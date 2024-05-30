using Domain.Repositories;
using Infra.Context;
using Infra.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IPostRepository, PostRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddDbContext<PostContext>(options =>  options.UseSqlite(builder.Configuration.GetConnectionString("Dev")));
var app = builder.Build();
/* if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
} */
app.MapControllers();
app.UseHttpsRedirection();
/* app.MapGet("/weatherforecast", () =>
{}
)
.WithName("GetWeatherForecast")
.WithOpenApi(); */
app.Run();
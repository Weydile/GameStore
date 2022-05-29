using GameStore.API.BLL;
using GameStore.API.Models;
using GameStore.DAL.Abstract;
using GameStore.DAL.Entites;
using GameStore.DAL.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
//Подключаем DAL
builder.Services.AddScoped<IDefaultRepository<Game>, DefaultRepository<Game>>();
builder.Services.AddScoped<IDefaultRepository<Genre>, DefaultRepository<Genre>>();
builder.Services.AddScoped<IDefaultRepository<Studio>, DefaultRepository<Studio>>();
//Подключаем BLL
builder.Services.AddScoped<IService<GameModel>, GamesService>();
builder.Services.AddScoped<IService<GenreModel>, GenresService>();
builder.Services.AddScoped<IService<StudioModel>, StudioService>();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

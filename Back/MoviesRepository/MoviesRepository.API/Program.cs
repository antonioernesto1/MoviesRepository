using Microsoft.EntityFrameworkCore;
using MoviesRepository.Application.Services;
using MoviesRepository.Application.Services.Interfaces;
using MoviesRepository.Data;
using MoviesRepository.Data.Repositories;
using MoviesRepository.Data.Repositories.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(
        builder
        .Configuration
        .GetConnectionString("Default")));

// Injeção de dependência
// Camada de acesso a dados
builder.Services.AddScoped<ISerieRepository, SerieRepository>();
builder.Services.AddScoped<IFilmeRepository, FilmeRepository>();
builder.Services.AddScoped<IAtorRepository, AtorRepository>();
builder.Services.AddScoped<ICategoriaRepository, CategoriaRepository>();
builder.Services.AddScoped<IRepository, Repository>();
//Camada de serviços
builder.Services.AddScoped<IFilmeService, FilmeService>();
builder.Services.AddScoped<ISerieService, SerieService>();
builder.Services.AddScoped<ICategoriaService, CategoriaService>();
builder.Services.AddScoped<IAtorService, AtorService>();

builder.Services.AddCors();

builder.Services.AddControllers()
    .AddNewtonsoftJson(options =>
        options.SerializerSettings.ReferenceLoopHandling =
        Newtonsoft.Json.ReferenceLoopHandling.Ignore);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(x =>
    x.AllowAnyHeader()
    .AllowAnyMethod()
    .AllowAnyOrigin());

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

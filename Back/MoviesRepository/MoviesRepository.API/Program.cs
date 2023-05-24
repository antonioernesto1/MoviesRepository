using Microsoft.EntityFrameworkCore;
using MoviesRepository.Application.Profiles;
using MoviesRepository.Application.Services;
using MoviesRepository.Application.Services.Interfaces;
using MoviesRepository.Data;
using MoviesRepository.Data.Repositories;
using MoviesRepository.Data.Repositories.Interfaces;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("Default");
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

// Inje��o de depend�ncia
// Camada de acesso a dados
builder.Services.AddScoped<ISerieRepository, SerieRepository>();
builder.Services.AddScoped<IFilmeRepository, FilmeRepository>();
builder.Services.AddScoped<IAtorRepository, AtorRepository>();
builder.Services.AddScoped<ICategoriaRepository, CategoriaRepository>();
builder.Services.AddScoped<IRepository, Repository>();
//Camada de servi�os
builder.Services.AddScoped<IFilmeService, FilmeService>();
builder.Services.AddScoped<ISerieService, SerieService>();
builder.Services.AddScoped<ICategoriaService, CategoriaService>();
builder.Services.AddScoped<IAtorService, AtorService>();

//AutoMapper
builder.Services.AddAutoMapper(typeof(FilmeProfile));
builder.Services.AddAutoMapper(typeof(SerieProfile));

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

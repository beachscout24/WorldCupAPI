global using Microsoft.AspNetCore.Mvc;
global using WorldCupAPI.Repositories;
global using Microsoft.EntityFrameworkCore;
global using WorldCupAPI.Data;
global using WorldCupAPI.Models;
global using WorldCupAPI.Services;
global using WorldCupAPI.Dtos;
global using AutoMapper;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddDbContext<DataContext>(options =>
{
	options.UseSqlServer(builder.Configuration.GetConnectionString("Default"));
});

builder.Services.AddScoped<ITeamService, TeamService>();
builder.Services.AddScoped<IWorldCupRepository, WorldCupRepository>();
builder.Services.AddAutoMapper(typeof(Program).Assembly);
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

using Authoriz;
using AutoMapper;
using Data.Context;
using Data.ViewModels;
using Mapper;
using Microsoft.EntityFrameworkCore;
using Services;
using Services.CountryCharacteristicServices;
using Services.CountryServices;
using Services.UserServices;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddDbContext<CountriesContext>(
    b=>b.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IJwtUtils, JwtUtils>();
builder.Services.AddScoped<IUserService, UserService>(); 
builder.Services.AddTransient<ICsvService,CsvService>();
builder.Services.AddTransient<ICountryService<CountryViewModel>,CountryService>();
builder.Services.AddTransient<ICountryCharacteristicService<CountryCharacteristicViewModel>,CountryCharacteristicService>();

var config = new MapperConfiguration(cfg =>
{
    cfg.AddProfile(new MapperProfile());
});
var mapper = config.CreateMapper();
builder.Services.AddSingleton(mapper);
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

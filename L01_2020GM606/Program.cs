using Microsoft.EntityFrameworkCore;
using L01_2020GM606.Models;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
//SE AGREGA ACA LA REFERENCIA DE LA BD DEL CONTEXTO
builder.Services.AddControllers();
builder.Services.AddDbContext<RestauranteDB_Context>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("string_conexion")));

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

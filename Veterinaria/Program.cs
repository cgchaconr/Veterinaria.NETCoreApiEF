using Microsoft.Extensions.Configuration;
using Veterinaria.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using static Veterinaria.Context.VeterinariaContext;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//builder.Services.AddDbContext<VeterinariaContext>(options => options.UseSqlServer(Configuration.GetConnectionString("VeterinariaConnStr")));
var connectionString = builder.Configuration.GetConnectionString("VeterinariaConnStr");
builder.Services.AddDbContext<VeterinariaDBContext>(x => x.UseSqlServer(connectionString));
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

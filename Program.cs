using API.Data;
using API.Interface;
using API.Services;
using Microsoft.EntityFrameworkCore;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<DataContext>(opt =>
{
    DbContextOptionsBuilder dbContextOptionsBuilder = opt.UseSqlite(builder.Configuration.GetConnectionString("defaultConnection"));
}
);


builder.Services.AddCors();
builder.Services.AddScoped<iTokenService, TokenService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseCors(builder => builder.AllowAnyHeader().AllowAnyMethod().WithOrigins("http://localhost:4200"));
app.MapControllers();

app.Run();

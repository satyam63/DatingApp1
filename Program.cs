using API.Data;
using Microsoft.EntityFrameworkCore;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<DataContext>(opt =>
{
    DbContextOptionsBuilder dbContextOptionsBuilder = opt.UseSqlite(builder.Configuration.GetConnectionString("defaultConnection"));
}
);


var app = builder.Build();

// Configure the HTTP request pipeline.
app.MapControllers();

app.Run();

using CleanArchitecture.Application.Services;
using CleanArchitecture.Domain.Interface;
using CleanArchitecture.Infrastucture.Data;
using CleanArchitecture.Infrastucture.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<BlogDbContext>(options =>
options.UseSqlite(builder.Configuration.GetConnectionString("BlogDbContext") ??
throw new InvalidOperationException("Connection string 'BlogDbContext' not found")));

builder.Services.AddTransient<IBlogRepository, BlogRepository>();
builder.Services.AddTransient<IBlogService, BlogService>();

builder.Services.AddControllers();
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

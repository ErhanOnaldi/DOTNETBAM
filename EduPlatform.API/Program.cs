using EduPlatform.API.Data;
using EduPlatform.API.Data.UnitOfWork;
using EduPlatform.API.Extensions;
using EduPlatform.API.Filters;
using EduPlatform.API.Repositories;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllers(options =>
{
    options.Filters.Add<ApiKeyFilter>();  // ← tüm controller'lara
    options.Filters.Add<ApiResponseFilter>();
});

builder.Services.AddScoped<ICourseRepository, CourseRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();  
}
//─────────────────────────Custom Middlewares─────────────────────────
app.UseCustomMiddlewares();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
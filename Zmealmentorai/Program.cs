using Microsoft.OpenApi.Models;
using MediatR;
using System.Reflection;
using Application;
using Persistence.Context;
using Persistence.UnitOfWorks;
using Application.Common.IUnitOfWorks;
using Microsoft.EntityFrameworkCore;
using Application.Services;
using Persistence.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "MealMentor API",
        Version = "v1",
        Description = "MealMentor API Documentation"
    });
});

// Add HttpContextAccessor
builder.Services.AddHttpContextAccessor();

// Add CurrentUserService
builder.Services.AddScoped<ICurrentUserService, CurrentUserService>();

// Add DbContext
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add UnitOfWork
builder.Services.AddScoped<IUnitOfWorks, UnitOfWork>();

// Add MediatR
builder.Services.AddMediatR(cfg => 
{
    cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
    cfg.RegisterServicesFromAssembly(AssemblyReference.Assembly);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "MealMentor API v1");
        c.RoutePrefix = string.Empty; // Swagger'ı kök dizinde göster
    });
}

app.UseRouting();
app.MapControllers();

app.Run();
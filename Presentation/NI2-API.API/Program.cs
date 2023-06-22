using Microsoft.AspNetCore.Hosting;
using NI2_API.Application;
using NI2_API.Infrastructure;
using NI2_API.Persistence;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpContextAccessor();
builder.Services.AddHttpClient();

builder.Services.AddApplicationServices();
builder.Services.AddPersistenceServices();
builder.Services.AddInfrastructureServices();

builder.Services.AddCors(options => options.AddDefaultPolicy(policy =>
policy.WithOrigins(
    "http://localhost:4200", 
    "https://localhost:4200"
    ).AllowAnyHeader().AllowAnyMethod().AllowCredentials()
));

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseStaticFiles();

app.UseHttpLogging();

app.UseCors();

app.UseHttpsRedirection();

app.UseRouting();

//app.UseAuthorization();

app.MapControllers();

app.Run();

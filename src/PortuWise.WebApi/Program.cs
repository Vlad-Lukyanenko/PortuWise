using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PortuWise.Application.Services;
using PortuWise.DataAccess;
using PortuWise.WebApi.Services;
using System;

namespace PortuWise.WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add CORS policy
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("BlazorAppPolicy", policy =>
                {
                    policy.WithOrigins("https://localhost:7099", "http://localhost:5175")
                        .AllowAnyHeader()
                        .AllowAnyMethod()
                        .AllowCredentials();
                });
            });

            builder.Services.AddDbContext<PortuWiseDbContext>(options =>
                options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddScoped<ICategoryService, CategoryService>();
            builder.Services.AddScoped<ILessonService, LessonService>();
            builder.Services.AddScoped<IWordService, WordService>();
            builder.Services.AddScoped<IPhraseService, PhraseService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseCors("BlazorAppPolicy");

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASOCoreLesson3Task2
{
    public class Startup
    {
        IConfiguration configuration;

        public Startup(IHostEnvironment env)
        {
            ConfigurationBuilder builder = new ConfigurationBuilder();
            builder.SetBasePath(env.ContentRootPath);
            builder.AddJsonFile("aboutme.json");
            configuration = builder.Build();
        }

        public void ConfigureServices(IServiceCollection services)
        {

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            var me = new
            {
                Name = configuration.GetSection("aboutMe").GetSection("Name").Value,
                Surname = configuration.GetSection("aboutMe").GetSection("Surname").Value,
                Age = int.Parse(configuration.GetSection("aboutMe").GetSection("Age").Value)
            };

            app.Run(async context =>
            {
                await context.Response.WriteAsync($"{me.Name}, {me.Surname}, {me.Age}");
            });
        }
    }
}

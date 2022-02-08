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

namespace ASPCoreLesson3Task1
{
    public class Startup
    {
        public IConfiguration AppConfiguration { get; set; }

        public Startup(IWebHostEnvironment env)
        {
            ConfigurationBuilder builder = new ConfigurationBuilder();

            builder.SetBasePath(env.ContentRootPath);
            builder.AddJsonFile("Config.json");
            builder.AddIniFile("Config.ini");
            builder.AddXmlFile("Config.xml");
            builder.AddEnvironmentVariables();
            AppConfiguration = builder.Build();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<BiggerCompanyService>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, BiggerCompanyService bcs)
        {
            #region INI CONFIG (TASK1)
            //Company appleINI = new Company() { Name = AppConfiguration["Apple:Name"], Workers = int.Parse(AppConfiguration["Apple:Workers"]) };
            //Company googleINI = new Company() { Name = AppConfiguration["Google:Name"], Workers = int.Parse(AppConfiguration["Google:Workers"]) };
            //Company microsoftINI = new Company() { Name = AppConfiguration["Microsoft:Name"], Workers = int.Parse(AppConfiguration["Microsoft:Workers"]) };
            //List<Company> companies = new List<Company>() { appleINI, googleINI, microsoftINI };
            //app.Run(async context =>
            //{
            //    foreach (var c in companies)
            //        await context.Response.WriteAsync($"{c.Name} has {c.Workers} employees\n");
            //});
            #endregion

            #region JSON (TASK1)
            //Company appleJSON = new Company()
            //{
            //    Name = AppConfiguration["Companies:Apple:Name"],
            //    Workers = int.Parse(AppConfiguration["Companies:Apple:Workers"])
            //};
            //Company googleJSON = new Company()
            //{
            //    Name = AppConfiguration["Companies:Google:Name"],
            //    Workers = int.Parse(AppConfiguration["Companies:Google:Workers"])
            //};
            //Company mirosoftJSON = new Company()
            //{
            //    Name = AppConfiguration["Companies:Microsoft:Name"],
            //    Workers = int.Parse(AppConfiguration["Companies:Microsoft:Workers"])
            //};
            //List<Company> companiesJSON = new List<Company>() { appleJSON, googleJSON, mirosoftJSON };

            //app.Run(async context =>
            //{
            //    foreach (var c in companiesJSON)
            //        await context.Response.WriteAsync($"Company {c.Name} has {c.Workers} workers.\n");
            //});
            #endregion

            #region XMLManual (TASK1)

            //Company appleXML = new Company()
            //{
            //    Name = AppConfiguration["Apple:Name"],
            //    Workers = int.Parse(AppConfiguration["Apple:Workers"])
            //};
            //Company googleXML = new Company()
            //{
            //    Name = AppConfiguration["Google:Name"],
            //    Workers = int.Parse(AppConfiguration["Google:Workers"])
            //};
            //Company mirosoftXML = new Company()
            //{
            //    Name = AppConfiguration["Microsoft:Name"],
            //    Workers = int.Parse(AppConfiguration["Microsoft:Workers"])
            //};
            //List<Company> companiesXML = new List<Company>() { appleXML, googleXML, mirosoftXML };
            //app.Run(async context =>
            //{
            //    foreach (var c in companiesXML)
            //        await context.Response.WriteAsync($"Company {c.Name} has {c.Workers} workers.\n");
            //});
            #endregion

            app.Run(async context =>
            {
                await context.Response.WriteAsync($"BiggestCompany: {bcs.GetBigger(bcs.GetComapnies()).Name}");
            });


        }
    }
}

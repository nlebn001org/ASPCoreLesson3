using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;

namespace ASPCoreLesson3Task1
{
    public class BiggerCompanyService
    {
        IConfiguration appConfiguration;

        public BiggerCompanyService()
        {
            ConfigurationBuilder builder = new ConfigurationBuilder();
            builder.AddJsonFile("Config.json");
            appConfiguration = builder.Build();
        }

        public IEnumerable<Company> GetComapnies()
        {
            IEnumerable<IConfigurationSection> sections = appConfiguration.GetSection("Companies").GetChildren();
            foreach (IConfigurationSection section in sections)
                yield return new Company()
                {
                    Name = section.GetSection("Name").Value.ToString(),
                    Workers = int.Parse(section.GetSection("Workers").Value.ToString())
                };
        }

        public Company GetBigger(IEnumerable<Company> companies)
        {
            return companies.OrderByDescending(w=>w.Workers).FirstOrDefault(); 
        }

    }
}

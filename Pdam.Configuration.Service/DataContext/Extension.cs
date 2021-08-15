using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;

namespace Pdam.Configuration.Service.DataContext
{
    public static class Extension
    {
        public static IApplicationBuilder MigrateDatabase(this IApplicationBuilder builder)
        {
            using var serviceScope = builder.ApplicationServices
                .GetRequiredService<IServiceScopeFactory>()
                .CreateScope();
            using var context = serviceScope.ServiceProvider.GetService<ConfigContext>();
            context?.Database.Migrate();
            return builder;
        }
        
        public static IApplicationBuilder SetupInitData(this IApplicationBuilder builder)
        {
            using var serviceScope = builder.ApplicationServices
                .GetRequiredService<IServiceScopeFactory>()
                .CreateScope();
            using var context = serviceScope.ServiceProvider.GetService<ConfigContext>();
            if (context == null) return builder;
            var value = File.ReadAllText("DataContext\\init-company.json");
            var companies = JsonConvert.DeserializeObject<List<Company>>(value);
            if (companies == null) return builder;
            foreach (var company in from company in companies
                let w = context.Companies.FirstOrDefault(c => c.CompanyCode == company.CompanyCode)
                where w == null
                select company)
            {
                context.Companies.Add(company);
            }

            context.SaveChanges();
            return builder;
        }
    }
}
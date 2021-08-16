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
            InitCompany(builder, context);
            InitBranch(builder, context);
            return builder;
        }

        private static void InitCompany(IApplicationBuilder builder, ConfigContext context)
        {
            var value = File.ReadAllText("DataContext\\init-company.json");
            var companies = JsonConvert.DeserializeObject<List<Company>>(value);
            if (companies == null) return;

            foreach (var company in from company in companies
                let w = context.Companies.FirstOrDefault(c => c.CompanyCode == company.CompanyCode)
                where w == null
                select company)
            {
                context.Companies.Add(company);
            }

            context.SaveChanges();
        }
        
        private static void InitBranch(IApplicationBuilder builder, ConfigContext context)
        {
            var value = File.ReadAllText("DataContext\\init-branch.json");
            var branches = JsonConvert.DeserializeObject<List<Branch>>(value);
            if (branches == null) return;

            foreach (var branch in from branch in branches
                let w = context.Branches.FirstOrDefault(c => c.CompanyCode == branch.CompanyCode && c.BranchCode == branch.BranchCode)
                where w == null
                select branch)
            {
                context.Branches.Add(branch);
            }

            context.SaveChanges();
        }
    }
}
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

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
    }
}
using System;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using Pdam.Common.Shared.Fault;
using Pdam.Configuration.Service.DataContext;
using Pdam.Configuration.Service.Infrastructures;

namespace Pdam.Configuration.Service
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers()
                .AddNewtonsoftJson(o =>
                {
                    o.SerializerSettings.DateFormatString = "yyyy'-'MM'-'dd' 'HH':'mm':'ss";
                    o.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
                });
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddDbContext<ConfigContext>(c =>
                c.UseNpgsql(Environment.GetEnvironmentVariable("PdamConfigurationConnectionString") ?? string.Empty));
            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(TransactionDecorator<,>));
            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationDecorator<,>));
            
            services.Scan(scan => scan.FromEntryAssembly()
                .AddClasses(classes => classes.AssignableTo(typeof(IRequestValidator<>)))
                .AsImplementedInterfaces()
                .WithScopedLifetime()
            );
            
            services.AddAutoMapper(typeof(CompanyProfile));
            services.AddMediatR(typeof(Startup));
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo {Title = "Pdam.Configuration.Service", Version = "v1"});
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.MigrateDatabase();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Pdam.Configuration.Service v1"));
                app.SetupInitData();
            }
           
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
            
            
        }
    }
}
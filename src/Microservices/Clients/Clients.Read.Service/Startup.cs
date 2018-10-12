using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Services.Common.Infrastructure.DIServiceConfigurations;
using Services.Common.Infrastructure.Middlewares;
using Dapper.FluentMap;
using Clients.Read.Service.Infrastructure.ClientQueries;
using Clients.Read.Service.Infrastructure.DapperCustomConfig;

namespace Clients.Read.Service
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
            FluentMapper.Initialize(c =>
            {
                c.AddMap(new AddressCustomMap());
            });
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
            services.AddCustomMvc(null, null, xmlPath);

            services.AddScoped<IClientQueries>(sp => new ClientQueries(Configuration["ConnectionString"]));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseDefaultFiles();

            app.UseCustomSwagger();
            app.UseMvc();
        }
    }
}

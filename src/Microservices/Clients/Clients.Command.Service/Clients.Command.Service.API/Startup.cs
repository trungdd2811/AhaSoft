using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Clients.Command.Service.API.Infrastructure.DIServicesConfiguration;
using Services.Common.Infrastructure.DIServiceConfigurations;
using Services.Common.Infrastructure.Middlewares;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using System;
using MediatR;
using System.Reflection;
using Clients.Command.Service.API.Infrastructure.AutofacModules;
using System.IO;

namespace Clients.Command.Service.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
            services.AddCustomConfiguration(Configuration)
                .AddMediatR(typeof(Startup).GetTypeInfo().Assembly)
                .AddCustomDbContext(Configuration)
                .AddCustomMvc(null, null, xmlPath);


            //configure autofac

            var container = new ContainerBuilder();
            container.Populate(services);

            container.RegisterModule(new ApplicationModule());

            return new AutofacServiceProvider(container.Build());
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

            app.UseAuthentication();

            app.UseCustomSwagger();

            app.UseMvc();
        }
    }
}

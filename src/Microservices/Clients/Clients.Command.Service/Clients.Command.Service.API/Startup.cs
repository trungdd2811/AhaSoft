using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Clients.Command.Service.API.Infrastructure.DIServicesConfiguration;
using Services.Common.Infrastructure.DIServiceConfigurations;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using System;
using MediatR;
using System.Reflection;
using Clients.Command.Service.API.Infrastructure.AutofacModules;

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
            services.AddCustomConfiguration(Configuration)
                .AddMediatR(typeof(Startup).GetTypeInfo().Assembly)
                .AddCustomDbContext(Configuration)
                .AddCustomMvc();


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
            app.UseMvc();
        }
    }
}

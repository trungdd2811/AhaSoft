using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Identity.Read.Service.Infrastructure.Configuration;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Identity.Read.Service.Infrastructure;
using Services.Common.Infrastructure.Middlewares;
using Services.Common.Infrastructure.DIServiceConfigurations;
using System.Reflection;
using System.IO;

namespace Identity.Read.Service
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
            services.AddCors();

            var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);

            // configure strongly typed settings objects
            var appSettingsSection = Configuration.GetSection("IdentitySettings");
            services.Configure<IdentitySettings>(appSettingsSection);

            // configure jwt authentication
            var appSettings = appSettingsSection.Get<IdentitySettings>();

            services.AddCustomMvc(null, null, xmlPath, appSettings.Secret);

            // configure DI for application services
            services.AddScoped<IUsersQueries, UsersQueries>();
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

            app.UseCors();

            app.UseAuthentication();

            app.UseCustomSwagger();

            app.UseMvc();
        }
    }
}

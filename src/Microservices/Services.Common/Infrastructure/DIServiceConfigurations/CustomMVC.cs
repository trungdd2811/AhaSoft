using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.DependencyInjection;
using Services.Common.Infrastructure.MVCFilters;
using Swashbuckle.AspNetCore.Swagger;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace Services.Common.Infrastructure.DIServiceConfigurations
{
    public static class CustomMVC
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="apiVersionOptions">null means applying default options</param>
        /// <param name="swaggerInfo">null means applying default options</param>
        /// <param name="swaggerXMLFilePath">empty means there is no swagger xml file</param>
        /// <returns></returns>
        public static IServiceCollection AddCustomMvc(this IServiceCollection services, Action<ApiVersioningOptions> apiVersionOptions = null,
            Info swaggerInfo = null, string swaggerXMLFilePath = "")
        {
            // Add framework services.
            if (apiVersionOptions == null)
                services.AddApiVersioning();
            else
                services.AddApiVersioning(apiVersionOptions);

            if (swaggerInfo == null)
                swaggerInfo = new Info { Title = "Aha APIs", Version = "v1" };

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", swaggerInfo);

                // Set the comments path for the Swagger JSON and UI.
               if(!string.IsNullOrEmpty(swaggerXMLFilePath))
                    c.IncludeXmlComments(swaggerXMLFilePath);
            });

            services.AddMvc(options =>
            {
                options.Filters.Add(typeof(HttpGlobalExceptionFilter));
            })
            .SetCompatibilityVersion(CompatibilityVersion.Version_2_1)
            .AddControllersAsServices();  //Injecting Controllers themselves thru DI
                                          //For further info see: http://docs.autofac.org/en/latest/integration/aspnetcore.html#controllers-as-services


            //It is not necessary now because all microservices should be called from an API gateway
            //so that they should only accept requests from the specific gateway

            //services.AddCors(options =>
            //{
            //    options.AddPolicy("CorsPolicy",
            //        builder => builder.AllowAnyOrigin()
            //        .AllowAnyMethod()
            //        .AllowAnyHeader()
            //        .AllowCredentials());
            //});

            return services;
        }
    }
}

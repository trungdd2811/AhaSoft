using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Services.Common.Infrastructure.MVCFilters;
using Swashbuckle.AspNetCore.Swagger;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using Services.Common.DomainObjects.Enum;
using System.Security.Claims;

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
            Info swaggerInfo = null, string swaggerXMLFilePath = "", string secretKey ="ahasoft_secret_key")
        {
            // Add framework services.
            if (apiVersionOptions == null)
                services.AddApiVersioning();
            else
                services.AddApiVersioning(apiVersionOptions);

            AddCustomSwagger(services, swaggerInfo, swaggerXMLFilePath);
           
            services.AddMvc(options =>
            {
                options.Filters.Add(typeof(HttpGlobalExceptionFilter));
            })
            .SetCompatibilityVersion(CompatibilityVersion.Version_2_1)
            .AddControllersAsServices();  //Injecting Controllers themselves thru DI
                                          //For further info see: http://docs.autofac.org/en/latest/integration/aspnetcore.html#controllers-as-services


            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials());
            });

            AddJWTAuthentication(services, secretKey);

            return services;
        }

        private static void AddCustomSwagger(IServiceCollection services, Info swaggerInfo, string swaggerXMLFilePath)
        {
            if (swaggerInfo == null)
                swaggerInfo = new Info { Title = "Aha APIs", Version = "v1" };

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", swaggerInfo);

                // Set the comments path for the Swagger JSON and UI.
                if (!string.IsNullOrEmpty(swaggerXMLFilePath))
                    c.IncludeXmlComments(swaggerXMLFilePath);
            });

        }

        private static void AddJWTAuthentication(IServiceCollection services, string secretKey)
        {
            var key = Encoding.ASCII.GetBytes(secretKey);

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

            services.AddAuthorization(o =>
            {
                o.AddPolicy(nameof(Policies.NormalUsers), p => p.RequireClaim(ClaimTypes.Role, nameof(Roles.Manager), nameof(Roles.Staff)));
                o.AddPolicy(nameof(Policies.AdvancedUsers), p => p.RequireClaim(ClaimTypes.Role, nameof(Roles.Manager)));
            });
        }
    }
}

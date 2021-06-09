using Application;
using Application.Common.Interfaces;
using Application.Common.Mappings;
using Application.Handlers.Users.Queries;
using Application.Repositories;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Persistence;
using System;
using System.Security.Claims;
using WebUI.Services;
using System.Text;
using Microsoft.Extensions.Configuration;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using NSwag.Generation.AspNetCore;
using System.Linq;
using WebUI.Filters;

namespace POSWEB
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
            var serviceProvider = services.BuildServiceProvider();
            var env = serviceProvider.GetService<IWebHostEnvironment>();

            services.AddAutoMapper(new Assembly[] { typeof(AutoMapperProfile).GetTypeInfo().Assembly });
            services.AddControllers();
            services.AddScoped(sp => sp.GetRequiredService<IHttpContextAccessor>().HttpContext);
            services.AddMediatR(typeof(Startup).Assembly);
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddMediatR(typeof(GetUsers).GetTypeInfo().Assembly);
            
            services.AddEntityFrameworkSqlServer();

            services.AddMvc(options =>
            {
                options.Filters.Add<CustomExceptionFilter>();
            }).AddNewtonsoftJson();
            /*services.AddControllers().AddNewtonsoftJson(options =>
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            );*/
            services.AddDbContext<IPOSDbContext, POSDbContext>();
            services.AddScoped<IAuthService, AuthService>();

            
            services.AddSingleton<IHttpUserRequest, HttpUserRequest>();
            services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();


            // Configure AppConfig
            var appConfig = Configuration.GetSection("Config");
            services.Configure<AppSetting>(appConfig);
            var appSetting = appConfig.Get<AppSetting>();
            services.AddSingleton(x => appSetting);

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(appSetting.AuthenticationKey)),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = false
                };
                x.Events = new JwtBearerEvents
                {
                    OnTokenValidated = async context =>
                    {
                        var mediator = context.HttpContext.RequestServices.GetService<IMediator>();

                        bool isAuthenticated = await mediator.Send(new HasUserTokenQuery
                        {
                            UserId = Guid.Parse(context.Principal.Identity.Name),
                            Token = Guid.Parse(context.Principal.FindFirstValue(ClaimTypes.Hash))
                        });
                        if (!isAuthenticated)
                        {
                            context.Fail(new UnauthorizedAccessException());
                        }
                    }
                };
            });

            // Configure Repositories
            services.AddScoped<InventoryRepository>();
            services.AddScoped<OrderRepository>();
            services.AddScoped<TransactionRepository>();

            // Reg Swagger
            services.AddSwaggerDocument(config => ConfigureOpenSwagger(config));
            if (env.IsDevelopment())
            {
                services.AddSwaggerDocument(config => ConfigureSecretSwagger(config));
            }
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseForwardedHeaders(new ForwardedHeadersOptions
            {
                ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
            });
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseOpenApi();
            app.UseSwaggerUi3(settings =>
            {
                settings.Path = "/open-api";
                settings.DocumentPath = "/swagger/v1/swagger.json";
                settings.SwaggerRoutes.Clear();
                //settings.SwaggerRoutes.Add(new NSwag.AspNetCore.SwaggerUi3Route("v1", "/swagger/v1/swagger.json"));
                settings.EnableTryItOut = false;
            });

            if (env.IsDevelopment())
            {
                app.UseSwaggerUi3(settings =>
                {
                    settings.Path = "/api";
                    settings.DocumentPath = "/swagger/secret-v1/swagger.json";
                    settings.SwaggerRoutes.Clear();
                });
            }

        }

        private void ConfigureSecretSwagger(AspNetCoreOpenApiDocumentGeneratorSettings config, string documentName = "v1")
        {
            config.IgnoreObsoleteProperties = true;

            config.DocumentName = $"secret-{documentName}";

            config.PostProcess = document =>
            {
                document.Info.Version = documentName;
                document.Info.Title = "POINT OF SALE";
                document.Info.Description = "POS Public API";
                document.Info.TermsOfService = "None";
                document.Info.Contact = new NSwag.OpenApiContact
                {
                    Name = "MPSSOFT",
                    Email = string.Empty,
                    Url = "https://mpssoft.co.id"
                };
                document.SecurityDefinitions.Add("Authorization", new NSwag.OpenApiSecurityScheme
                {
                    In = NSwag.OpenApiSecurityApiKeyLocation.Header,
                    Description = "Please enter into field the word 'Bearer' following by space and JWT",
                    Name = "Authorization",
                    Type = NSwag.OpenApiSecuritySchemeType.ApiKey
                });
                document.Security.Add(new NSwag.OpenApiSecurityRequirement
                {
                    { "Authorization", Enumerable.Empty<string>() }
                });
                //document.Info.License = new NSwag.OpenApiLicense
                //{
                //    Name = "Use under LICX",
                //    Url = "https://example.com/license"
                //};
            };

            //config.OperationProcessors.Add(new CompanyFilterAttribute.OperationFilter());
        }
        private void ConfigureOpenSwagger(AspNetCoreOpenApiDocumentGeneratorSettings config, string documentName = "v1")
        {
            config.IgnoreObsoleteProperties = true;

            config.DocumentName = documentName;

            config.PostProcess = document =>
            {
                document.Info.Version = documentName;
                document.Info.Title = "BIS Accounting";
                document.Info.Description = "BIS Accounting Public API";
                document.Info.TermsOfService = "None";
                document.Info.Contact = new NSwag.OpenApiContact
                {
                    Name = "MPSSOFT",
                    Email = string.Empty,
                    Url = "https://mpssoft.co.id"
                };
                document.SecurityDefinitions.Add("Authorization", new NSwag.OpenApiSecurityScheme
                {
                    In = NSwag.OpenApiSecurityApiKeyLocation.Header,
                    Description = "Please enter into field the word 'Bearer' following by space and JWT",
                    Name = "Authorization",
                    Type = NSwag.OpenApiSecuritySchemeType.ApiKey
                });
                document.SecurityDefinitions.Add("AppToken", new NSwag.OpenApiSecurityScheme
                {
                    In = NSwag.OpenApiSecurityApiKeyLocation.Header,
                    Description = "Please enter into field the word 'Bearer' following by space and JWT",
                    Name = "AppToken",
                    Type = NSwag.OpenApiSecuritySchemeType.ApiKey
                });
                document.Security.Add(new NSwag.OpenApiSecurityRequirement
                {
                    { "Authorization", Enumerable.Empty<string>() },
                    { "AppToken", Enumerable.Empty<string>() }
                });
            };

            //config.OperationProcessors.Add(new CompanyFilterAttribute.OperationFilter());
            /*config.AddOperationFilter(context =>
            {
                bool hasAttribute = context.ControllerType.GetCustomAttributes(true).Any(x => x.GetType() == typeof(SecretApiAttribute))
                    || context.MethodInfo.CustomAttributes.Any(x => x.AttributeType == typeof(SecretApiAttribute));

                return !hasAttribute;
            });*/
        }
    }
}

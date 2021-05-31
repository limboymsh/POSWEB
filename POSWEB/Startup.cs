using System.Reflection;
using System.Text;
using Application;
using Application.Common.Interfaces;
using Application.Handlers.Users.Queries;
using Application.Repositories;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Persistence;
using WebUI.Services;
using WebUI.Services.Interfaces;

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
            services.AddControllers();
            services.AddMediatR(typeof(Startup).Assembly);
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddMediatR(typeof(GetUsers).GetTypeInfo().Assembly);
            services.AddEntityFrameworkSqlServer();
            services.AddDbContext<IPOSDbContext, POSDbContext>();
            services.AddScoped<InventoryCategoryRepository>();
            services.AddSwaggerGen();

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
                    ValidateAudience = false
                };
            });

            services.AddScoped<IJwtAuthenticationManager,JwtAuthenticationManager>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
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

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "POS API v1");
                
            });

        }
    }
}

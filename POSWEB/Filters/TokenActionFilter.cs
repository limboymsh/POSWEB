using Application;
using Application.Common.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace WebUI.Filters
{
    public class TokenActionFilter : IAsyncActionFilter
    {
        private readonly IPOSDbContext dbContext;
        private readonly AppSetting appSetting;
        private readonly IWebHostEnvironment env;

        public TokenActionFilter(IOptions<AppSetting> appSettingOption, IPOSDbContext dbContext, IWebHostEnvironment env)
        {
            this.dbContext = dbContext;
            appSetting = appSettingOption.Value;
            this.env = env;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if (env.IsDevelopment())
            {
                await next();
                return;
            }
            if (FromOwnOrigin(context.HttpContext.Request))
            {
                await next();
                return;
            }
            if(context.ActionDescriptor is ControllerActionDescriptor controllerActionDescriptor)
            {
                bool hasAllowByPassAttribute = controllerActionDescriptor.ControllerTypeInfo.GetCustomAttributes(true).Any(x => x.GetType() == typeof(AllowByPassApiAttribute))
                    || controllerActionDescriptor.MethodInfo.CustomAttributes.Any(x => x.AttributeType == typeof(AllowByPassApiAttribute));

                if (hasAllowByPassAttribute)
                {
                    await next();
                    return;
                }

                bool hasAttribute = controllerActionDescriptor.ControllerTypeInfo.GetCustomAttributes(true).Any(x => x.GetType() == typeof(SecretApiAttribute))
                    || controllerActionDescriptor.MethodInfo.CustomAttributes.Any(x => x.AttributeType == typeof(SecretApiAttribute));

                if (hasAttribute) throw new UnauthorizedAccessException();
                await ValidateTokenOrThrowException(context);
                await next();
            }
            throw new NotImplementedException();
        }

        private async Task ValidateTokenOrThrowException(ActionExecutingContext context)
        {
            if (!context.HttpContext.Request.Headers.ContainsKey("AppToken")) throw new UnauthorizedAccessException();

            string jwtToken = context.HttpContext.Request.Headers["AppToken"];
            if (string.IsNullOrEmpty(jwtToken)) throw new UnauthorizedAccessException();

            jwtToken = jwtToken.Replace("Bearer ", "");

            var key = Encoding.ASCII.GetBytes(appSetting.AuthenticationKey);

            var tokenHandler = new JwtSecurityTokenHandler();

            if (!tokenHandler.CanReadToken(jwtToken)) throw new UnauthorizedAccessException();

            try
            {
                var claimsPrincipal = tokenHandler.ValidateToken(jwtToken, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(appSetting.AuthenticationKey)),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = false
                }, out SecurityToken jwtSecToken);

                string id = claimsPrincipal.Identity.Name;
                string secretToken = claimsPrincipal.Claims.First(x => x.Type == ClaimTypes.Hash).Value;

                /*var app = null;// await dbContext.AppTokens.FirstOrDefaultAsync(x => x.Id == Guid.Parse(id));

                if (app == null) throw new UnauthorizedAccessException();

                if (app.SecretToken != secretToken) throw new UnauthorizedAccessException();*/
            }
            catch (Exception)
            {
                throw new UnauthorizedAccessException();
            }
        }

        private bool FromOwnOrigin(HttpRequest request)
        {
            if (request.Headers.ContainsKey("Origin"))
            {
                return OwnOrigins.Contains(request.Headers["Origin"].ToString());
            }
            return false;
        }
        private string[] OwnOrigins
        {
            get => new string[] { appSetting.ClientUrl, appSetting.AdminUrl };
        }
    }
}

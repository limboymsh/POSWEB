using Application;
using Application.Handlers.Users.Commands.InsertUserToken;
using Application.Handlers.Users.Queries;
using Domain.Entities;
using MediatR;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using WebUI.DTO;

namespace WebUI.Services
{
    public class AuthService : IAuthService
    {
        private readonly IMediator mediator;
        private readonly AppSetting appSetting;

        public AuthService(IMediator mediator, IOptions<AppSetting> appSetting)
        {
            this.mediator = mediator;
            this.appSetting = appSetting.Value;

        }

        public async Task<string> GetAccessTokenAsync(UserCredDTO data)
        {
            try
            {
                var user = await mediator.Send(new GetUserQuery { Email = data.Email, Password = data.Password });

                Guid identifier = Guid.NewGuid();
                string token = GetAccessToken(user, identifier);

                await InsertUserToken(user.Id, identifier);
                return token;
            }
            catch
            {
                throw;
            }
        }

        public string GetAccessToken(User user, Guid identifier)
        {
            // authentication successful so generate jwt token
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(appSetting.AuthenticationKey);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new System.Security.Claims.Claim[]
                {
                    new System.Security.Claims.Claim(ClaimTypes.Name, user.Id.ToString()),
                    new System.Security.Claims.Claim(ClaimTypes.Hash, identifier.ToString()) //Unique Guid to identify token
                }),
                //Expires = dateTime.UtcNow.AddDays(7),
                IssuedAt = DateTime.Now,
                Issuer = "customer",
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        /// <summary>
        /// Save token api data to database
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public async Task InsertUserToken(Guid userId, Guid token)
        {
            await mediator.Send(new InsertUserTokenCommand
            {
                UserId = userId,
                Token = token
            });
        }
    }
}

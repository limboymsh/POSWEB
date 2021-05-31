using Application;
using Application.Handlers.Users;
using MediatR;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using WebUI.Services.Interfaces;
using WebUI.DTO;
using Application.Handlers.Auth;
using Domain.Entities;
using Application.Exceptions;

namespace WebUI.Services
{
    public class JwtAuthenticationManager : IJwtAuthenticationManager
    {
        private readonly IMediator mediator;
        private readonly AppSetting appSetting;

        public JwtAuthenticationManager(IMediator mediator, IOptions<AppSetting> appSettingOptions) {
            this.mediator = mediator;
            appSetting = appSettingOptions.Value;
        }
        public async Task<string> authenticate(UserCredDTO userCred)
        {
            try
            {
                
                if (userCred == null)
                {
                    return null;
                }
                var user = await mediator.Send(new GetUserByEmailAndPassword.GetUsersByEmailAndPasswordQuery { Email = userCred.Email, Pass = userCred.Password });
                Console.WriteLine("''''''''''''''''" + user.ToString());
                //return response == null ? Ok("Not Found") : Ok(response);*/
                string token = createToken(user);
                return token;
                
            } catch(Exception ex)
            {
                var user = await mediator.Send(new GetUserByEmailAndPassword.GetUsersByEmailAndPasswordQuery { Email = userCred.Email, Pass = userCred.Password });
                throw ex;
            }
        }

        public string createToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.ASCII.GetBytes(appSetting.AuthenticationKey);
            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(new Claim[] {
                    new Claim(ClaimTypes.Email, user.Email),
                    new Claim(ClaimTypes.Role, "Cashier")
                }),
                SigningCredentials =
                new SigningCredentials(
                    new SymmetricSecurityKey(tokenKey),
                    SecurityAlgorithms.HmacSha256Signature
                    )
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}

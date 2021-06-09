using Application.Common.Interfaces;
using Application.Extensions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.Extensions.Primitives;
using System.Collections.Generic;
using System.Linq;

namespace WebUI.Services
{
    public class HttpUserRequest : IHttpUserRequest
    {
        private readonly IActionContextAccessor accessor;

        public HttpUserRequest(IActionContextAccessor accessor)
        {
            this.accessor = accessor;
        }

        private HttpContext Context { get => accessor.ActionContext.HttpContext; }

        public string IpAddress
        {
            get
            {
                string ip = Context.Connection.RemoteIpAddress.ToString();

                if (Context.Request.Headers.ContainsKey("CF-Connecting-IP") && !Context.Request.Headers["CF-Connecting-IP"].ToString().IsNullOrEmpty())
                {
                    //Jika pakai cloudflare
                    ip = Context.Request.Headers["CF-Connecting-IP"].ToString();
                }
                return ip;
            }
        }

        public string UserToken { get => Context.Request.Headers["Authorization"].ToString(); }

        public IDictionary<string, StringValues> Headers
        {
            get
            {
                return Context.Request.Headers.ToDictionary(keyValue => keyValue.Key, keyValue => keyValue.Value);
            }
        }

        public string Url { get => Microsoft.AspNetCore.Http.Extensions.UriHelper.GetDisplayUrl(Context.Request); }

        public bool IsAuthenticated { get => Context.User.Identity.IsAuthenticated; }

        public string UserId { get => Context.User.Identity.Name ?? null; }
    }
}

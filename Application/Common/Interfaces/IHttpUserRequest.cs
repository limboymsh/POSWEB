using Microsoft.Extensions.Primitives;
using System.Collections.Generic;

namespace Application.Common.Interfaces
{
    public interface IHttpUserRequest
    {
        IDictionary<string, StringValues> Headers { get; }
        string IpAddress { get; }
        bool IsAuthenticated { get; }
        string Url { get; }
        string UserId { get; }
        string UserToken { get; }
    }
}
using Microsoft.Extensions.Primitives;
using System.Collections.Generic;

namespace WebUI.DTO
{
    public class ClientInfoDto
    {
        public string Url { get; set; }
        public IDictionary<string, StringValues> Headers { get; set; }
        public string IpAddress { get; set; }
        public bool IsAuthenticated { get; set; }
        public string UserId { get; set; }
    }
}

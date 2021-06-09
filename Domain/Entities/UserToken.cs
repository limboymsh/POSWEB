using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class UserToken
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid Token { get; set; }
        public DateTime CreatedAt { get; set; }
        public string IpAddress { get; set; }
    }
}

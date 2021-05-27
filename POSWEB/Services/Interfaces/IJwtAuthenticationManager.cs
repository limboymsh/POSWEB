using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebUI.DTO;

namespace WebUI.Services.Interfaces
{
    public interface IJwtAuthenticationManager
    {
        Task<string> authenticate(UserCredDTO userCred);
        string createToken(User user);
    }
}

using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Common.Interfaces
{
    public interface IAuthorizeCommand
    {
        Company Company { get; set; }
        User User { get; set; }

    }
    
    public interface IAuthorizeUserOnlyCommand
    {
        User User { get; set; }
    }
}

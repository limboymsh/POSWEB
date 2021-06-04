using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Common.Interfaces.Mappings
{
    public interface IMapping
    {
        void CreateMappings(Profile configuration);
    }
}

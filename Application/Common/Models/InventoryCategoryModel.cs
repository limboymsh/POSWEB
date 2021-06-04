using Application.Common.Interfaces.Mappings;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Common.Models
{
    public class InventoryCategoryModel : IMapping
    {
        public Guid Id { get; set; }
        public Guid OutletId { get; set; }
        public string Name { get; set; }
        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<InventoryCategory, InventoryCategoryModel>();
        }
    }
}

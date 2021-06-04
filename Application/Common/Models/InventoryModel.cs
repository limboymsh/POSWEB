using Application.Common.Interfaces.Mappings;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Common.Models
{
    public class InventoryModel : IMapping
    {
        public Guid Id { get; set; }
        public Guid OutletId { get; set; }
        public string Name { get; set; }
        public Guid? PromoId { get; set; }
        public Guid? DiscountId { get; set; }
        public int Stock { get; set; }
        public bool IsActive { get; set; }
        public bool IsServices { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public Guid UpdateBy { get; set; }
        public DateTime UpdatedOn { get; set; }

        public InventoryCategoryModel InventoryCategory { get; set; }
        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<Inventory, InventoryModel>();
        }
    }
}

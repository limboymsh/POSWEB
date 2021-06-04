using Application.Common.Interfaces.Mappings;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Common.Models
{
    public class OrderDetailModel: IMapping
    {
        public Guid Id { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPrice { get; set; }
        public InventoryModel Inventory { get; set; }

        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<OrderDetail, OrderDetailModel>();
        }
    }
}

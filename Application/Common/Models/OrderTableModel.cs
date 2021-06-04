using Application.Common.Interfaces.Mappings;
using AutoMapper;
using Domain.Entities;
using System;

namespace Application.Common.Models
{
    public class OrderTableModel : IMapping
    {
        public Guid Id { get; set; }
        public byte Status { get; set; }

        
        public virtual Table Table { get; set; }

        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<OrderTable, OrderTableModel>();
        }
    }
}

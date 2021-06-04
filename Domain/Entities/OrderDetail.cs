using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Domain.Entities
{
    public partial class OrderDetail
    {
        public Guid Id { get; set; }
        public Guid OrderId { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPrice { get; set; }
        public Guid InventoryId { get; set; }
        public Inventory Inventory { get; set; }
       
    }
}

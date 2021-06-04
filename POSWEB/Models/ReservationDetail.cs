using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace WebUI.Models
{
    public partial class ReservationDetail
    {
        public Guid Id { get; set; }
        public Guid ReservationId { get; set; }
        public Guid InventoryId { get; set; }
        public Guid InventoryCategoryId { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public Guid? DiscountId { get; set; }
        public decimal TotalPrice { get; set; }
        public Guid? PromoId { get; set; }
    }
}

using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Domain.Entities
{
    public partial class MinimumChargeDetail
    {
        public Guid Id { get; set; }
        public Guid? MinimumChargeId { get; set; }
        public Guid? InventoryId { get; set; }
        public Guid? RoomId { get; set; }
        public decimal? Value { get; set; }
        public int? Quantity { get; set; }
        public Guid? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public Guid? UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
}

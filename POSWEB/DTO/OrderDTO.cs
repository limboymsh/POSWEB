using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebUI.DTO
{
    public class OrderDTO
    {
        public Guid? Id { get; set; }
        public string OrderType { get; set; }
        public Guid? ReservationId { get; set; }
        public Guid? OtherTransactionId { get; set; }
        public Guid? TableId { get; set; }
        public Guid? RoomId { get; set; }
        public Guid? MemberId { get; set; }
        public byte? PaymentStatus { get; set; }
        public byte? Status { get; set; }
        public Guid? Code { get; set; }
        public decimal? Price { get; set; }
        public bool? IsDeduction { get; set; }
        public decimal? TotalPrice { get; set; }
        public DateTime? IssueDate { get; set; }
        public string Address { get; set; }
        public string Note { get; set; }
        public Guid? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public Guid? UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
}

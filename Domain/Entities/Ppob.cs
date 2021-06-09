using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Domain.Entities
{
    public partial class Ppob
    {
        public Guid Id { get; set; }
        public Guid? BankId { get; set; }
        public Guid? OtherTransactionTypeId { get; set; }
        public string Name { get; set; }
        public string AccountNumber { get; set; }
        public string BankCode { get; set; }
        public Guid? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public Guid? UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
}

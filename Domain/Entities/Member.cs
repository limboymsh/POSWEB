using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Domain.Entities
{
    public partial class Member
    {
        public Guid Id { get; set; }
        public Guid? BisMemberId { get; set; }
        public Guid? CompanyId { get; set; }
        public Guid? OutletId { get; set; }
        public DateTime? IssueDate { get; set; }
        public bool? IsActive { get; set; }
        public string Address { get; set; }
        public int? CityId { get; set; }
        public int? ProvinceId { get; set; }
        public int? DistrictId { get; set; }
        public Guid? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public Guid? UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
}

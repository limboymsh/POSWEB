using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Domain.Entities
{
    public partial class SubRoom
    {
        public string Id { get; set; }
        public string CompanyId { get; set; }
        public string OutletId { get; set; }
        public string SubRoomName { get; set; }
        public string PeopleCount { get; set; }
        public string RoomId { get; set; }
        public string Row { get; set; }
        public string Column { get; set; }
        public string RowSpan { get; set; }
        public string Colspan { get; set; }
        public string SubRoomStatusId { get; set; }
        public string IsActive { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public string UpdatedOn { get; set; }
    }
}

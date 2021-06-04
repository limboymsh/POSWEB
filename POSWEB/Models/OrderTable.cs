﻿using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace WebUI.Models
{
    public partial class OrderTable
    {
        public Guid Id { get; set; }
        public Guid OrderId { get; set; }
        public Guid RoomId { get; set; }
        public Guid TableId { get; set; }
        public byte Status { get; set; }
    }
}

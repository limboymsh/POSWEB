using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Enums
{
    public enum EOrderType : byte
    {
        DineIn= 1,
        TakeAway = 2,
        Deliver = 3,
        Reservation = 4
    }
}

using System.ComponentModel;

namespace Domain.Enums
{
    public enum OrderType : byte
    {
        [Description("Makan Ditempat")]
        DineIn = 1,
        [Description("Bawa Pulang")]
        TakeAway = 2,
        [Description("Pesan Antar")]
        Deliver = 3,
        [Description("Reservasi")]
        Reservation = 4
    }
}

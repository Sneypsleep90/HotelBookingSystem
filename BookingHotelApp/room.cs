using System;

namespace BookingApp
{
    [Serializable]
    public class Room
    {
        public int Id { get; set; }
        public int HotelId { get; set; }
        public string RoomNumber { get; set; }
    }
}
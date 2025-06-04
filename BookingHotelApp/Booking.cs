using System;

namespace BookingApp
{
    [Serializable]
    public class Booking
    {
        public int Id { get; set; }
        public string ClientName { get; set; }
        public DateTime Date { get; set; }
        public string Status { get; set; }
        public int HotelId { get; set; }
        public int RoomId { get; set; } // New property to associate with a room
    }
}
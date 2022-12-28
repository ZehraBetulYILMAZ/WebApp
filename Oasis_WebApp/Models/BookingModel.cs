using System;

namespace Oasis_WebApp.Models
{
    public class BookingModel
    {
        public string TcKimlikNo { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string eMailAddress { get; set; }
        public string Password { get; set; }
        public string ReservationType { get; set; } // TİPİNİ DEĞİŞTİRMEYE ÇALIŞ
        public DateTime ArrivalDate { get; set; }
        public DateTime DepartureDate { get; set; }

    }
}

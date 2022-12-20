using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
   public class Reservation: BaseEntity
    {
        public DateTime ReservationDate { get; set; }
        public bool Cancel { get; set; }
        public DateTime PostponementDate { get; set; } //erteleme
        public decimal BaseCost { get; set; }
        public decimal kalmaFiyat { get; set; } //??
        public DateTime ArrivalDate { get; set; } //gelme
        public DateTime DepartureDate { get; set; } //ayrılma
        public Room room { get; set; }
        public int RoomNumber { get; set; }
        public int CustomerId { get; set; } //null izni
        public Customer customer { get; set; } //belki tüm bilgiler gerekir diye böyle yaptım, düzeltilebilir

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Room: BaseEntity
    {
        public int RoomNumber { get; set; }
        public bool Empty { get; set; }
        public decimal BaseCost { get; set; }
        public List<Reservation> Reservations { get; set; } //oda farklı tarihlerde boş olacağı için: One To Many??
    }
}

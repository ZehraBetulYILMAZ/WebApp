using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
   public class Report : BaseEntity
    {
        public string CustomerName { get; set; } //tüm bilgileri çekmek daha iyi olmaz mı
        public int RoomNumber { get; set; }
        public DateTime ArrivalDate { get; set; } //gelme
        public DateTime DepartureDate { get; set; } //ayrılma
    }
}

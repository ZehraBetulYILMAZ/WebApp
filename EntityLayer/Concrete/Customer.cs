using EntityLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
   public class Customer: Person
    {
        public string TcKimlikNo{ get; set; }
        public string PhoneNumber { get; set; }
        public string eMailAddress{ get; set; }
        public string Address { get; set; }
        public List<Invoice> Invoices { get; set; }
        public List<CreditCard> CreditCards { get; set; }
        public List<Reservation> Reservations { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get ; set ; }
    }
}

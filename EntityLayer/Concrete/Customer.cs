using EntityLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
   public class Customer: Person, IAuditEntity
    {
        public string TcKimlikNo{ get; set; }
        public string PhoneNumber { get; set; }
        public string eMailAddress{ get; set; }
        public string Address { get; set; }
        public List<Invoice> Invoices { get; set; }
        public List<CreditCard> CreditCards { get; set; }
        public List<Reservation> Reservations { get; set; }
        public int CreatedObjectId { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public DateTime? CreatedDate { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int UpdatedObjectId { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public DateTime? UpdatedDate { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}

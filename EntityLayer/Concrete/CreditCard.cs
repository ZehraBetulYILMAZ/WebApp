using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
   public class CreditCard: BaseEntity
    {
        public string CardNumber { get; set; }
        public DateTime ExpirationDate { get; set; }
        public int SecurityCode { get; set; }
        public int CustomerId { get; set; } //null izni
        public Customer customer { get; set; } //belki tüm bilgiler gerekir diye böyle yaptım, düzeltilebilir
    }
}

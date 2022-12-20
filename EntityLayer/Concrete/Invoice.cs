using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
  public  class Invoice: BaseEntity
    {
        public DateTime PrintDate { get; set; }
        public int CustomerId { get; set; } //null izni
        public Customer customer { get; set; }
    }
}

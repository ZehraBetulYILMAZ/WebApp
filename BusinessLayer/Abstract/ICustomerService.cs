using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Abstract
{
   public interface ICustomerService
    {
        int AddCustomer(Customer customer);
        int DeleteCustomer(Customer customer);
        int UpdateCustomer(Customer customer);
        List<Customer> GetAllCustomers();
        Customer GetCustomerById(int id);

    }
}

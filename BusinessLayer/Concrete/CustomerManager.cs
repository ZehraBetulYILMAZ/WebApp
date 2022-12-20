using BusinessLogicLayer.Abstract;
using DataAccessLayer.Repositories;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Concrete
{
    public class CustomerManager : ICustomerService
    {
        //mvc'deki controller gibi
        GenericRepositories<Customer> efCustomerReporistories;
        public CustomerManager()
        {
            efCustomerReporistories = new GenericRepositories<Customer>();
        }
       
        public void AddCustomer(Customer customer)
        {
            efCustomerReporistories.Insert(customer);
        }

        public void DeleteCustomer(Customer customer)
        {
            if(customer.Id!=0) //null check
            {
                efCustomerReporistories.Delete(customer);
            }
        }

        public List<Customer> GetAllCustomers()
        {
            return efCustomerReporistories.GetListAll();
        }

        public Customer GetCustomerById(int id)
        {
            return efCustomerReporistories.GetById(id); //exeption at
        }

        public void UpdateCustomer(Customer customer)
        {
            if (customer.Id != 0) //null check
            {
                efCustomerReporistories.Update(customer);
            }
        }
    }
}

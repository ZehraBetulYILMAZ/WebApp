using BusinessLogicLayer.Abstract;
using DataAccessLayer.Concrete;
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
        //Context context
        //mvc'deki controller gibi
        GenericRepositories<Customer> efCustomerReporistories;
        public CustomerManager()
        {
            efCustomerReporistories = new GenericRepositories<Customer>();
        }
       
        public int AddCustomer(Customer customer)
        {
            try
            {
                efCustomerReporistories.Insert(customer);
                return 1;
            }
            catch 
            {

                return - 1;
            }
            
        }

        public int DeleteCustomer(Customer customer)
        {
            try
            {
                if (customer.Id != 0) //null check
                {
                    efCustomerReporistories.Delete(customer);
                }
                return 1;
            }
            catch 
            {

                return -1;
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

        public int UpdateCustomer(Customer customer)
        {
            try
            {
                if (customer.Id != 0) //null check
                {
                    efCustomerReporistories.Update(customer);
                }
                return 1;
            }
            catch 
            {

                return -1;
            }
           
        }
    }
}

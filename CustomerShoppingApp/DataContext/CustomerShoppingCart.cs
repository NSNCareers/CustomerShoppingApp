using System;
using System.Threading.Tasks;
using CustomerShoppingApp.Models;

namespace CustomerShoppingApp.DataContext
{
    public class CustomerShoppingCart : ICustomerShoppingCart
    {
        public CustomerShoppingCart()
        {
        }

        public Task<Customer> CreateNewCustomer(Customer customer)
        {
            throw new NotImplementedException();
        }

        public Task<Customer> DeletCustomer(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Customer> GetAddress(int id, string fistName)
        {
            throw new NotImplementedException();
        }

        public Task<Customer> GetAllCustomers()
        {
            throw new NotImplementedException();
        }

        public Task<Customer> GetCustomer(int id, string fistName)
        {
            throw new NotImplementedException();
        }

        public Task<Customer> GetItems(int id, string fistName)
        {
            throw new NotImplementedException();
        }

        public Task<Customer> UpdateExistingCustomer(int id)
        {
            throw new NotImplementedException();
        }
    }
}

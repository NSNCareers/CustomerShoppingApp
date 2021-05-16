using System;
using System.Threading.Tasks;
using CustomerShoppingApp.Models;

namespace CustomerShoppingApp.DataContext
{
    public interface ICustomerShoppingCart
    {
        Task<Customer> GetCustomer(int id,string fistName);
        Task<Customer> DeletCustomer(int id);
        Task<Customer> GetAllCustomers();
        Task<Customer> CreateNewCustomer(Customer customer);
        Task<Customer> GetAddress(int id, string fistName);
        Task<Customer> GetItems(int id, string fistName);
        Task<Customer> UpdateExistingCustomer(int id);
    }
}

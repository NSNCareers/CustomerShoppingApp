using CustomerShoppingApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CustomerShoppingApp.DataContext
{
    public interface ICustomerShoppingCart
    {
        Task<IActionResult> GetCustomerWithID(int id);
        Task<IActionResult> DeletCustomer(int id);
        Task<IActionResult> GetAllCustomers();
        Task<IActionResult> CreateNewCustomer(Customer customer);
        Task<IActionResult> UpdateExistingCustomer(Customer customer);
        Task<IActionResult> ChangeState(int id);
        Task<IActionResult> GetActiveCustomers();
        Task<IActionResult> GetInActiveCustomers();
        Task<IActionResult> GetCustomersItems(int id, string firstName);
        Task<IActionResult> GetCustomersAddress(int id, string firstName);
        Task<IActionResult> GetCustomersBankdetails(int id, string firstName);

    }
}

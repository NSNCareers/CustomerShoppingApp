using CustomerShoppingApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CustomerShoppingApp.DataContext
{
    public interface ICustomerShoppingCart
    {
        Task<IActionResult> GetCustomerWithID(int id);
        Task<IActionResult> DeletCustomer(Customer customer);
        Task<IActionResult> GetAllCustomers();
        Task<IActionResult> CreateNewCustomer(Customer customer);
        Task<IActionResult> UpdateExistingCustomer(Customer customer);
        Task<IActionResult> ChangeState(int id);
        Task<IActionResult> GetActiveCustomers();
    }
}

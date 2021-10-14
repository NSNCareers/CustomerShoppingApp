using CustomerShoppingApp.DataContext;
using CustomerShoppingApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace CustomerShoppingApp.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class CustomerNoAuthController : ControllerBase
    {
        private readonly ICustomerShoppingCart _customerShoppingCart;

        public CustomerNoAuthController(ICustomerShoppingCart customerShoppingCart)
        {
            _customerShoppingCart = customerShoppingCart;
        }

        [HttpGet("GetCustomerUsingId")]
        public async Task<IActionResult>  GetCustomerUsingId([Required]int id)
        {
            var result = await _customerShoppingCart.GetCustomerWithID(id);

            return result;
        }

        [HttpGet("GetAllCustomers")]
        public async Task<IActionResult> GetAllCustomers()
        {
            var result = await _customerShoppingCart.GetAllCustomers();

            return result;
        }

        [HttpGet("GetAllActiveCustomers")]
        public async Task<IActionResult> GetAllActiveCustomers()
        {
            var result = await _customerShoppingCart.GetActiveCustomers();

            return result;
        }

        [HttpGet("GetAllInActiveCustomers")]
        public async Task<IActionResult> GetAllInActiveCustomers()
        {
            var result = await _customerShoppingCart.GetInActiveCustomers();

            return result;
        }

        [HttpPost("CreateNewCustomer")]
        public async Task<IActionResult> CreateCustomer([FromBody] Customer customer)
        {
            var result = await _customerShoppingCart.CreateNewCustomer(customer);

            return result;
        }

        [HttpPut("UpdateCustomer")]
        public async Task<IActionResult> UpdateCustomer([FromBody] Customer customer)
        {
            var result = await _customerShoppingCart.UpdateExistingCustomer(customer);

            return result;
        }

        [HttpDelete("DeleteExistingCustomer")]
        public async Task<IActionResult> DeleteCustomer([Required]int id)
        {
            var result = await _customerShoppingCart.DeletCustomer(id);

            return result;
        }

        [HttpPost("ChangeCustomerState")]
        public async Task<IActionResult> ChangeCustomerState([Required] int id)
        {
            var result = await _customerShoppingCart.ChangeState(id);

            return result;
        }

        [HttpGet("GetCustomersItemsWithId/{id}")]
        public async Task<IActionResult> GetCustomersItemsWithId([Required] int id)
        {
            var result = await _customerShoppingCart.GetCustomersItems(id);

            return result;
        }

        [HttpGet("GetCustomersAddressWithId/{id}")]
        public async Task<IActionResult> GetCustomersAddressWithId([Required] int id)
        {
            var result = await _customerShoppingCart.GetCustomersAddress(id);

            return result;
        }

        [HttpGet("GetCustomersBankDetailsWithId")]
        public async Task<IActionResult> GetCustomersBankDetailsWithId([Required] int id)
        {
            var result = await _customerShoppingCart.GetCustomersBankdetails(id);

            return result;
        }
    }
}

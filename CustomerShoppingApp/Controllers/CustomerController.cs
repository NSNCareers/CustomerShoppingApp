using CustomerShoppingApp.Context;
using CustomerShoppingApp.DataContext;
using CustomerShoppingApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace CustomerShoppingApp.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerShoppingCart _customerShoppingCart;

        public CustomerController(ICustomerShoppingCart customerShoppingCart)
        {
            _customerShoppingCart = customerShoppingCart;
        }

        [HttpGet("GetCustomerWithId/{id}")]
        public async Task<IActionResult>  GetCustomerWithId([Required]int id)
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

        [HttpGet("GetCustomersItemsWithIdAndName/{id}")]
        public async Task<IActionResult> GetCustomersItemsWithIdAndName([Required] int id,[Required] string firstName)
        {
            var result = await _customerShoppingCart.GetCustomersItems(id,firstName);

            return result;
        }

        [HttpGet("GetCustomersAddressWithIdAndName/{id}")]
        public async Task<IActionResult> GetCustomersAddressWithIdAndName([Required] int id, [Required] string firstName)
        {
            var result = await _customerShoppingCart.GetCustomersAddress(id, firstName);

            return result;
        }

        [HttpGet("GetCustomersBankdetailsWithIdAndName/{id}")]
        public async Task<IActionResult> GetCustomersBankdetailsWithIdAndName([Required] int id, [Required] string firstName)
        {
            var result = await _customerShoppingCart.GetCustomersBankdetails(id, firstName);

            return result;
        }
    }
}

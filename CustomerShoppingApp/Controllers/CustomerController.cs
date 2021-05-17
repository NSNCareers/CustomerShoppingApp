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
        public async Task<IActionResult> GetActiveCustomers()
        {
            var result = await _customerShoppingCart.GetActiveCustomers();

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
        public async Task<IActionResult> DeleteCustomer([Required]int ID)
        {
            var customer = new Customer { id = ID };
            var result = await _customerShoppingCart.DeletCustomer(customer);

            return result;
        }

        [HttpPost("ChangeCustomerState")]
        public async Task<IActionResult> ChangeCustomerState([Required] int id)
        {
            var result = await _customerShoppingCart.ChangeState(id);

            return result;
        }
    }
}

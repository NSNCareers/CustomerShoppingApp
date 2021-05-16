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
        public async Task<IActionResult>  GetCustomer([Required]int id, string name)
        {

            return Ok();
        }

        [HttpGet("GetAllCustomers")]
        public async Task<IActionResult> GetAllCustomers()
        {
            return Ok();
        }

        [HttpGet("GetAllActiveCustomers")]
        public async Task<IActionResult> GetCustomerShoppingCart()
        {
            return Ok();
        }

        [HttpGet("GetALlItems")]
        public async Task<IActionResult> GetAllItems(int id,string firstName)
        {
            return Ok();
        }

        [HttpGet("GetAllAddresses")]
        public async Task<IActionResult> GetCustomerAddress(int id, string firstName)
        {
            return Ok();
        }

        [HttpPost("CreateNewCustomer")]
        public async Task<IActionResult> CreateCustomer([Required] Customer customer)
        {
            return Created("",customer);
        }

        [HttpPut("UpdateCustomer")]
        public async Task<IActionResult> UpdateCustomer([Required] Customer customer)
        {
            return Accepted(customer);
        }

        [HttpDelete("DeleteExistingCustomer")]
        public async Task<IActionResult> DeleteCustomer([Required]int id)
        {
            return Ok();
        }
    }
}

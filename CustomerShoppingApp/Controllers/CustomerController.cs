using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace CustomerShoppingApp.Controllers
{
    [ApiController]
    [Route("api/Customer")]
    public class CustomerController : ControllerBase
    {
        [HttpGet("{id}")]
        public async Task<IActionResult>  GetCustomer([Required]int id, string name)
        {
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCustomers()
        {
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetCustomerShoppingCart(int customerName)
        {
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllItems()
        {
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetCustomerAddress()
        {
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> CreateCustomer()
        {
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCustomer()
        {
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteCustomer()
        {
            return Ok();
        }
    }
}

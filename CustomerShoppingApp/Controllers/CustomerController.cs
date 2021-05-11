using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
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
    }
}

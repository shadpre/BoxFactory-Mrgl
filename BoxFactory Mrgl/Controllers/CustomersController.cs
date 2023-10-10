using BoxFactory_Mrgl.DAL;
using BoxFactory_Mrgl.DAL.Interfaces;
using BoxFactory_Mrgl.Models;
using BoxFactory_Mrgl.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BoxFactory_Mrgl.Controllers
{
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private IDBFacade _dbFacade = new DBFacade();

        [HttpPost]
        [Route("/api/Customer")]
        public IActionResult Create([FromBody] CustomerModel customer)
        {
            ICustomerModel model = _dbFacade.CreateCustomer(customer);
            if (model == null) { return BadRequest(); }
            return Created("", model);
        }

        [HttpGet]
        [Route("/api/Customer")]
        public IActionResult ReadAll()
        {
            return Ok(_dbFacade.ReadCustomers());
        }

        [HttpGet]
        [Route("/api/Customer/{CustomerId}")]
        public IActionResult Read([FromRoute] int CustomerId)
        {
            var result = _dbFacade.ReadCustomer(CustomerId);
            if (result == null) { NotFound("Customer Not Found"); }
            return Ok(result);
        }

        [HttpPut]
        [Route("/api/Customer/{CustomerId}")]
        public IActionResult Update([FromBody] CustomerModel customer, [FromRoute] int CustomerId)
        {
            if (customer.CustomerId == CustomerId)
            {
                var result = _dbFacade.UpdateCustomer(customer);
                if (result == null) { NotFound("Customer Not Found"); }
                return Ok(result);
            }
            return BadRequest("Something went wrong");
        }

        [HttpDelete]
        [Route("/api/Customer/{CustomerId}")]
        public IActionResult Delete([FromRoute] int CustomerId) { throw new NotImplementedException(); }
    }
}

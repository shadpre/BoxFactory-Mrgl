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

    }
}

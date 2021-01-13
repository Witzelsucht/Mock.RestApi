using Microsoft.AspNetCore.Mvc;
using Mock.RestApi.IServices;
using Mock.RestApi.Models;

namespace Mock.RestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerService customerService;

        public CustomersController(ICustomerService customerService)
        {
            this.customerService = customerService;
        }

        [HttpGet]
        public ActionResult Get()
        {
            var customers = customerService.Get();
            return Ok(customers);
        }

        [HttpGet("{id:int}", Name = "GetCustomerById")]
        public ActionResult GetById(int id)
        {
            if (!customerService.IsExist(id))
            {
                return NotFound();
            }

            var customer = customerService.Get(id);
            return Ok(customer);
        }

        [HttpPost]
        public ActionResult Add([FromBody] Customer customer)
        {
            customerService.Add(customer);
            if (!customerService.IsExist(customer.Id))
            {
                return NotFound();
            }

            return CreatedAtRoute("GetCustomerById", new { id = customer.Id }, customer);
        }

        [HttpPut("{id:int}")]
        public ActionResult Update(int id, [FromBody] Customer customer)
        {
            if (id != customer.Id)
            {
                return BadRequest();
            }

            if (!customerService.IsExist(id))
            {
                return NotFound();
            }

            customerService.Update(customer);
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
            if (!customerService.IsExist(id))
            {
                return NotFound();
            }

            customerService.Delete(id);
            return NoContent();
        }
    }
}

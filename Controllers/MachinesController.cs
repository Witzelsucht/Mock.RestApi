using Microsoft.AspNetCore.Mvc;
using Mock.RestApi.IServices;
using Mock.RestApi.Models;
using System.Linq;

namespace Mock.RestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MachinesController : ControllerBase
    {
        private readonly IMachineService machineService;

        public MachinesController(IMachineService machineService)
        {
            this.machineService = machineService;
        }

        [HttpGet]
        public ActionResult Get()
        {
            var machines = machineService.Get();
            return Ok(machines);
        }

        [HttpGet("{id:int}", Name = "GetMachineById")]
        public ActionResult<Machine> GetById(int id)
        {
            if (!machineService.IsExist(id))
            {
                return NotFound();
            }

            var machine = machineService.Get(id);
            return Ok(machine);
        }

        [HttpGet("~/api/customers/{customerId}/machines")]
        public ActionResult GetByCustomer(int customerId)
        {
            var machines = machineService.GetByCustomerId(customerId);
            if (!machines.Any())
            {
                return NotFound();
            }

            return Ok(machines);
        }
        [HttpPost]
        public ActionResult Add([FromBody] Machine machine)
        {
            machineService.Add(machine);
            if (!machineService.IsExist(machine.Id))
            {
                return NotFound();
            }

            return CreatedAtRoute("GetMachineById", new { id = machine.Id }, machine);
        }
        [HttpPut("{id:int}")]
        public ActionResult Update(int id, [FromBody] Machine machine)
        {
            if (id != machine.Id)
            {
                return BadRequest();
            }

            if (!machineService.IsExist(id))
            {
                return NotFound();
            }

            machineService.Update(machine);
            return NoContent();
        }
        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
            if (!machineService.IsExist(id))
            {
                return NotFound();
            }

            machineService.Delete(id);
            return NoContent();
        }
    }
}

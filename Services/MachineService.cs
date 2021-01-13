using Mock.RestApi.IServices;
using Mock.RestApi.Models;
using System.Collections.Generic;
using System.Linq;

namespace Mock.RestApi.Services
{
    public class MachineService : EntityService<Machine>, IMachineService
    {
        public MachineService(ICollection<Machine> list) : base(list)
        {

        }
        public IEnumerable<Machine> GetByCustomerId(int customerId)
        {
            return entities.Where(e => e.Customer.Id == customerId);
        }
    }
}

using Mock.RestApi.Models;
using System.Collections.Generic;

namespace Mock.RestApi.IServices
{
    public interface IMachineService : IEntityService<Machine>
    {
        IEnumerable<Machine> GetByCustomerId(int customerId);
    }
}

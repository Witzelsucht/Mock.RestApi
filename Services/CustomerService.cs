using Mock.RestApi.IServices;
using Mock.RestApi.Models;
using System.Collections.Generic;

namespace Mock.RestApi.Services
{
    public class CustomerService : EntityService<Customer>, ICustomerService
    {
        public CustomerService(ICollection<Customer> customers) : base(customers)
        {
        }
    }
}

using Bogus;
using Mock.RestApi.Models;

namespace Mock.RestApi.Fakers
{
    public class CustomerFaker : Faker<Customer>
    {
        public CustomerFaker()
        {
            UseSeed(1);
            RuleFor(p => p.Id, f => f.IndexFaker);
            RuleFor(p => p.Name, f => f.Company.CompanyName());
            RuleFor(p => p.Address, f => f.Address.City());
            RuleFor(p => p.Country, f => f.Address.Country());
        }
    }
}

using Bogus;
using Mock.RestApi.Models;

namespace Mock.RestApi.Fakers
{
    public class MachineFaker : Faker<Machine>
    {
        public MachineFaker(params Customer[] customers)
        {
            RuleFor(p => p.Id, f => f.IndexFaker + 1);
            RuleFor(p => p.Name, f => f.Commerce.ProductName());
            RuleFor(p => p.MachineType, f => f.PickRandom<MachineType>());
            RuleFor(p => p.HardwareKey, f => $"{f.Random.AlphaNumeric(5)}-{f.Random.AlphaNumeric(5)}-{f.Random.AlphaNumeric(5)}-{f.Random.AlphaNumeric(5)}-{f.Random.AlphaNumeric(5)}".ToUpper());
            RuleFor(p => p.LicenseKey, f => $"{f.Random.AlphaNumeric(5)}-{f.Random.AlphaNumeric(5)}-{f.Random.AlphaNumeric(5)}-{f.Random.AlphaNumeric(5)}-{f.Random.AlphaNumeric(5)}".ToUpper());
            RuleFor(p => p.Customer, f => f.PickRandom(customers));
        }
    }
}

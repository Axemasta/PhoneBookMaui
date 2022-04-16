using Bogus;
using PhoneBookApp.Abstractions;
using PhoneBookApp.Models;

namespace PhoneBookApp.Repositories
{
    public class MockContactItemRepository : IContactItemRepository
    {
        private Lazy<List<ContactItem>> _contacts;

        public MockContactItemRepository()
        {
            _contacts = new Lazy<List<ContactItem>>(ContactBuilder, System.Threading.LazyThreadSafetyMode.ExecutionAndPublication);
        }

        private List<ContactItem> ContactBuilder()
        {
            var address = new Faker<Address>()
                .RuleFor(c => c.HouseName, f => f.Address.BuildingNumber())
                .RuleFor(c => c.Line1, f => f.Address.SecondaryAddress())
                .RuleFor(c => c.Line2, f => f.Address.StreetName())
                .RuleFor(c => c.City, f => f.Address.City())
                .RuleFor(c => c.County, f => f.Address.County())
                .RuleFor(c => c.Country, f => f.Address.Country());

            var faker = new Faker<ContactItem>()
                .RuleFor(c => c.FirstName, f => f.Name.FirstName())
                .RuleFor(c => c.LastName, f => f.Name.LastName())
                .RuleFor(c => c.PhoneNumber, f => f.Phone.PhoneNumber())
                .RuleFor(c => c.Email, f => f.Internet.Email())
                .RuleFor(c => c.Address, address);

            return faker.GenerateBetween(1, 10);
        }

        public List<ContactItem> GetContacts()
        {
            return _contacts.Value;
        }
    }
}

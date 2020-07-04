using Bogus;
using Zoopla.Selenium.Framework.Interfaces;

namespace Zoopla.Selenium.Framework.Utilities.Person
{
    public class Person : IPerson
    {
        public string Password => _user.Password;

        public string EmailAddress() =>
            _user.FirstName + "." + _user.LastName
            + "+blacklist@" + _user.DomainName;

        private readonly User _user;
         private Person()
        {
            var customUser = new Faker<User>()
                .RuleFor(user => user.FirstName, (f, u) => f.Name.FirstName())
                .RuleFor(user => user.LastName, (f, u) => f.Name.LastName())
                .RuleFor(user => user.DomainName, (f, u) => f.Internet.DomainName())
                .RuleFor(user => user.Password, (f, u) => f.Internet.Password(8));

             _user = customUser.Generate();
        }
    }
}

using Bogus;
using Bogus.DataSets;
using Feature.Client;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Features.Tests._04___Human_Datas
{
    [CollectionDefinition(nameof(ClientBogusCollection))]
    public class ClientBogusCollection : ICollectionFixture<ClientTestBogusFixture> { }

    public class ClientTestBogusFixture : IDisposable
    {
        public Client GenerateValidClient()
        {
            return GenerateClients(1, true).FirstOrDefault();
        }

        public IEnumerable<Client> GetVariedClients()
        {

        }

        public IEnumerable<Client> GenerateClients(int quantity, bool active)
        {
            var gender = new Faker().PickRandom<Name.Gender>();

            var clients = new Faker<Client>("pt_BR")
                .CustomInstantiator(f => new Client(
                    Guid.NewGuid(),
                    f.Name.FirstName(gender),
                    f.Name.LastName(gender),
                    f.Date.Past(80, DateTime.Now.AddYears(-18)),
                    DateTime.Now,
                    "",
                    active))
                .RuleFor(c => c.Email, (f, c) =>
                    f.Internet.Email(c.Name.ToLower(), c.Surname.ToLower()));

            return clients.Generate(quantity);
        }

        public Client GenerateInvalidClient()
        {
            var gender = new Faker().PickRandom<Name.Gender>();

            var client = new Faker<Client>("pt_BR")
                .CustomInstantiator(f => new Client(
                    Guid.NewGuid(),
                    f.Name.FirstName(gender),
                    f.Name.LastName(gender),
                    f.Date.Past(1, DateTime.Now.AddYears(1)),
                    DateTime.Now,
                    "",
                    false));

            return client;
        }
        public void Dispose() { }
    }
}

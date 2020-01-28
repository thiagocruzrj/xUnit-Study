using Feature.Client;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Features.Tests._02___Fixtures
{
    [CollectionDefinition(nameof(ClientCollection))]
    public class ClientCollection : ICollectionFixture<ClientFixtureTests> { }

    public class ClientFixtureTests : IDisposable
    {
        public Client GenerateValidClient()
        {
            var client = new Client(
                Guid.NewGuid(),
                "Thiago",
                "Cruz",
                DateTime.Now.AddYears(-25),
                DateTime.Now,
                "thiago@thi.com.br",
                true);

            return client;
        }

        public Client GenerateInvalidClient()
        {
            var client = new Client(
                Guid.NewGuid(),
                "",
                "",
                DateTime.Now,
                DateTime.Now,
                "thiago@thi.com.br",
                true);

            return client;
        }


        public void Dispose()
        {
        }
    }
}

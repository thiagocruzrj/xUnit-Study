﻿using Bogus;
using Bogus.DataSets;
using Feature.Client;
using Moq.AutoMock;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Features.Tests._06___AutoMock
{
    [CollectionDefinition(nameof(ClientAutoMockerCollection))]
    public class ClientAutoMockerCollection : ICollectionFixture<ClientServiceAutoMockerFixture> { }

    public class ClientServiceAutoMockerFixture : IDisposable
    {
        public ClientService ClientService;
        public AutoMocker Mocker;

        public Client GenerateValidClient()
        {
            return GenerateClients(1, true).FirstOrDefault();
        }

        public IEnumerable<Client> GetSomeClients()
        {
            var clients = new List<Client>();

            clients.AddRange(GenerateClients(50, true).ToList());
            clients.AddRange(GenerateClients(50, false).ToList());

            return clients;
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

        public ClientService GetClientService()
        {
            Mocker = new AutoMocker();
            ClientService = Mocker.CreateInstance<ClientService>();

            return ClientService;
        }

        public void Dispose() { }
    }
}
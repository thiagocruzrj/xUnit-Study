using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Feature.Client
{
    public class ClientService : IClientService
    {
        private readonly IClientRepository _clienteRepository;
        private readonly IMediator _mediator;

        public ClientService(IClientRepository clienteRepository, IMediator mediator)
        {
            _clienteRepository = clienteRepository;
            _mediator = mediator;
        }

        public IEnumerable<Client> GetAllActives()
        {
            return _clienteRepository.GetAll().Where(c => c.Active);
        }

        public void Add(Client client)
        {
            if (!client.IsValid())
                return;

            _clienteRepository.Add(client);
            _mediator.Publish(new ClientEmailNotification("admin@me.com", client.Email, "Hi", "Welcome"));
        }

        public void Update(Client client)
        {
            if (!client.IsValid())
                return;

            _clienteRepository.Update(client);
            _mediator.Publish(new ClientEmailNotification("admin@me.com", client.Email, "Changes", "Take a look"));
        }

        public void Remove(Client client)
        {
            _clienteRepository.Remove(client.Id);
            _mediator.Publish(new ClientEmailNotification("admin@me.com", client.Email, "Bye", "Have a good trip"));
        }

        public void Deactive(Client client)
        {
            if (!client.IsValid())
                return;

            client.Deactive();
            _clienteRepository.Update(client);
            _mediator.Publish(new ClientEmailNotification("admin@me.com", client.Email, "Bye", "See you soon"));
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}

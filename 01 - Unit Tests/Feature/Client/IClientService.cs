using System;
using System.Collections.Generic;
using System.Text;

namespace Feature.Client
{
    public interface IClientService : IDisposable
    {
        IEnumerable<Client> GetAllActives();
        void Add(Client client);
        void Update(Client client);
        void Remove(Client client);
        void Deactive(Client client);
    }
}

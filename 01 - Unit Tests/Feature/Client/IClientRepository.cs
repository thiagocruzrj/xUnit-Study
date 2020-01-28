using Feature.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Feature.Client
{
    public interface IClientRepository : IRepository<Client>
    {
        Client GetByEmail(string email);
    }
}

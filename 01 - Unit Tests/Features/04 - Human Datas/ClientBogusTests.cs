using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Features.Tests._04___Human_Datas
{
    [Collection(nameof(ClientBogusCollection))]
    public class ClientBogusTests
    {
        private readonly ClientTestBogusFixture _clientTestsFixture;

        public ClientBogusTests(ClientTestBogusFixture clientTestsFixture)
        {
            _clientTestsFixture = clientTestsFixture;
        }
    }
}

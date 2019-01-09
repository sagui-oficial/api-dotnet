using Sagui.Service.RequestResponse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sagui.Test.Mocks
{
    public class MockPlanoOperadora
    {
        public RequestPlanoOperadora CriarMockPlanoOperadora()
        {
            RequestPlanoOperadora planoOperadora = new RequestPlanoOperadora();

            return planoOperadora;
        }
    }
}

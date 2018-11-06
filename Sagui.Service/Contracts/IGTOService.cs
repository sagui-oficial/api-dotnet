using Sagui.Service.RequestResponse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sagui.Service.Contracts
{
    public interface IGTOService
    {
        ResponseGTO Cadastrar(RequestGTO requestGTO);

        ResponseGTO ListGTOs(RequestGTO requestGTO = null);
    }
}

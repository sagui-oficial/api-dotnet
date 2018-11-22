using System.Collections.Generic;

namespace Sagui.Service.Contracts
{
    public interface IGTOService
    {
        Model.GTO Cadastrar(Model.GTO GTO);

        List<Model.GTO> ListGTOs(Model.GTO GTO = null);
    }
}

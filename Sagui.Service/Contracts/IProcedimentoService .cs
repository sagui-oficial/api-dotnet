using System.Collections.Generic;

namespace Sagui.Service.Contracts
{
    public interface IProcedimentoService
    {
        Model.Procedimentos Cadastrar(Model.Procedimentos Procedimento);

        List<Model.Procedimentos> ListProcedimentos(Model.Procedimentos Procedimento = null);
    }
}

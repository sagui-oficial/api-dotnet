using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sagui.Service.Contracts.Base
{
    public interface ICRUDBase<TResponse, TModel> where TResponse : class where TModel : class
    {
        TResponse Cadastrar(TModel model);

        TResponse Atualizar(TModel model);

        TResponse Deletar(TModel model);

        List<TResponse> Listar();
                
    }
}

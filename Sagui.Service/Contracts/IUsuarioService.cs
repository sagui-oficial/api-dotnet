using System.Collections.Generic;

namespace Sagui.Service.Contracts
{
    public interface IUsuarioService
    {
        Model.Usuario Cadastrar(Model.Usuario Usuario);

        List<Model.Usuario> ListUsuarios(Model.Usuario Usuario = null);
    }
}

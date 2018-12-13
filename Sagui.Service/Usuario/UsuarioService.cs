using Sagui.Service.Contracts;
using System.Collections.Generic;

namespace Sagui.Service.GTO
{
    public class UsuarioService : IUsuarioService
    {
        public Model.Usuario Cadastrar(Model.Usuario Usuario)
        {
            using (var usuarioBusiness = new Business.Usuario.UsuarioBusiness())
            {
                var _return = usuarioBusiness.Cadastrar(Usuario);
                usuarioBusiness.Dispose();
                return _return;
            }
        }

        public List<Model.Usuario> ListUsuarios(Model.Usuario requestUsuario = null)
        {
            using (var usuarioBusiness = new Business.Usuario.UsuarioBusiness())
            {
                var _return = usuarioBusiness.ListUsuarios(requestUsuario);
                usuarioBusiness.Dispose();
                return _return;
            }
        }
    }
}
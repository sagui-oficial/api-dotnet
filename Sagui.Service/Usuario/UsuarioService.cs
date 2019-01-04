using Sagui.Service.Contracts;
using System.Collections.Generic;

namespace Sagui.Service.Usuario
{
    public class UsuarioService : IUsuarioService<Model.Usuario, Model.Usuario>
    {
        public Model.Usuario Atualizar(Model.Usuario model)
        {
            throw new System.NotImplementedException();
        }

        public Model.Usuario Cadastrar(Model.Usuario Usuario)
        {
            using (var usuarioBusiness = new Business.Usuario.UsuarioBusiness())
            {
                var _return = usuarioBusiness.Cadastrar(Usuario);
                usuarioBusiness.Dispose();
                return _return;
            }
        }

        public Model.Usuario Deletar(Model.Usuario model)
        {
            throw new System.NotImplementedException();
        }

        public List<Model.Usuario> Listar()
        {
            using (var usuarioBusiness = new Business.Usuario.UsuarioBusiness())
            {
                var _return = usuarioBusiness.ListUsuarios();
                usuarioBusiness.Dispose();
                return _return;
            }
        }
    }
}
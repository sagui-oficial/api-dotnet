using Sagui.Service.Contracts;
using System.Collections.Generic;

namespace Sagui.Service.Usuario
{
    public class UsuarioServiceEspecialista : IUsuarioService<Model.Dentinsta, Model.Dentinsta>
    {
        public Model.Dentinsta Atualizar(Model.Dentinsta model)
        {
            throw new System.NotImplementedException();
        }

        public Model.Dentinsta Cadastrar(Model.Dentinsta Usuario)
        {
            using (var usuarioBusiness = new Business.Usuario.UsuarioBusiness())
            {
                var _return = usuarioBusiness.Cadastrar(Usuario);
                usuarioBusiness.Dispose();
                return _return;
            }
        }

        public Model.Dentinsta Deletar(Model.Dentinsta model)
        {
            throw new System.NotImplementedException();
        }

        public List<Model.Dentinsta> Listar()
        {
            using (var usuarioBusiness = new Business.Usuario.UsuarioBusiness())
            {
                var _return = usuarioBusiness.ListUsuariosDentista();
                usuarioBusiness.Dispose();
                return _return;
            }
        }
    }
}
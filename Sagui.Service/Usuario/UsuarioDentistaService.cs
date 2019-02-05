using Sagui.Model;
using Sagui.Service.Contracts;
using System.Collections.Generic;

namespace Sagui.Service.Usuario
{
    public class UsuarioDentistaService : IUsuarioService<Model.Dentinsta, Model.Dentinsta>
    {
        public Dentinsta Atualizar(Dentinsta model)
        {
            throw new System.NotImplementedException();
        }

        public Dentinsta Cadastrar(Dentinsta Usuario)
        {
            using (var usuarioBusiness = new Business.Usuario.UsuarioDentistaBusiness())
            {
                var _return = usuarioBusiness.Cadastrar(Usuario);
                usuarioBusiness.Dispose();
                return _return;
            }
        }

        public Dentinsta Deletar(Dentinsta model)
        {
            throw new System.NotImplementedException();
        }

        public List<Dentinsta> Listar()
        {
            using (var usuarioBusiness = new Business.Usuario.UsuarioDentistaBusiness())
            {
                var _return = usuarioBusiness.ListUsuarios();
                usuarioBusiness.Dispose();
                return _return;
            }
        }
    }
}
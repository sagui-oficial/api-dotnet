using Sagui.Model;
using Sagui.Service.Contracts;
using System.Collections.Generic;

namespace Sagui.Service.Usuario
{
    public class UsuarioDentistaService : IUsuarioService<Model.Dentinsta, Model.Dentinsta>
    {
        public Dentinsta Atualizar(Dentinsta Usuario)
        {
            using (var usuarioBusiness = new Business.Usuario.UsuarioDentistaBusiness())
            {
                var _return = usuarioBusiness.Cadastrar(Usuario);
                usuarioBusiness.Dispose();
                return _return;
            }
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

        public Dentinsta Deletar(Dentinsta Usuario)
        {
            using (var usuarioBusiness = new Business.Usuario.UsuarioDentistaBusiness())
            {
                var _return = usuarioBusiness.Deletar(Usuario);
                usuarioBusiness.Dispose();
                return _return;
            }
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

        public Dentinsta Obter(Dentinsta Usuario)
        {
            using (var usuarioBusiness = new Business.Usuario.UsuarioDentistaBusiness())
            {
                var _return = usuarioBusiness.Obter(Usuario);
                usuarioBusiness.Dispose();
                return _return;
            }
        }
    }
}
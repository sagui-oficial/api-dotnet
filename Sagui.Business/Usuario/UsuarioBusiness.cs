using System.Collections.Generic;
using Sagui.Business.Base;
using Sagui.Data.Lookup.GTO;
using Sagui.Data.Persister.GTO;

namespace Sagui.Business.Usuario
{

    public class UsuarioBusiness : BusinessBase
    {
        public List<Model.Usuario> ListUsuarios(Model.Usuario usuario)
        {
            UsuarioLookup usuarioLookup = new UsuarioLookup();
            var listUsuarios = usuarioLookup.ListUsuario(usuario);

            return listUsuarios;
        }

        public Model.Usuario Cadastrar(Model.Usuario usuario)
        {
            UsuarioPersister usuarioPersister = new UsuarioPersister();
            usuarioPersister.SaveUsuario(usuario, out Data.DataInfrastructure dataInfrastructure);

            Model.Usuario responseUsuario = new Model.Usuario();
            responseUsuario = usuario;

            dataInfrastructure.Dispose();

            return responseUsuario;
        }
    }
}
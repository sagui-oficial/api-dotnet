using System.Collections.Generic;
using Sagui.Business.Base;
using Sagui.Data.Lookup.GTO;
using Sagui.Data.Persister.GTO;

namespace Sagui.Business.Usuario
{

    public class UsuarioDentistaBusiness : BusinessBase
    {
        public List<Model.Dentinsta> ListUsuarios()
        {
            UsuarioDentistaLookup usuarioLookup = new UsuarioDentistaLookup();
            var listUsuarios = usuarioLookup.ListUsuarioDentista();

            return listUsuarios;
        }

        public Model.Dentinsta Cadastrar(Model.Dentinsta usuario)
        {
            UsuarioPersister usuarioPersister = new UsuarioPersister();
            usuarioPersister.SaveUsuario(usuario, out Data.DataInfrastructure dataInfrastructure);

            Model.Dentinsta responseUsuario = new Model.Dentinsta();
            responseUsuario = usuario;

            dataInfrastructure.Dispose();

            return responseUsuario;
        }
    }
}
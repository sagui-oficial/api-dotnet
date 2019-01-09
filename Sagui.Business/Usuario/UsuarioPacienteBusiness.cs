using System.Collections.Generic;
using Sagui.Business.Base;
using Sagui.Data.Lookup.GTO;
using Sagui.Data.Persister.GTO;
using Sagui.Data.Persister.Usuario;

namespace Sagui.Business.Usuario
{

    public class UsuarioPacienteBusiness : BusinessBase
    {
        public List<Model.Paciente> ListUsuarios()
        {
            UsuarioPacienteLookup usuarioLookup = new UsuarioPacienteLookup();
            var listUsuarios = usuarioLookup.ListUsuarioPaciente();

            return listUsuarios;
        }

        public Model.Paciente Cadastrar(Model.Paciente usuarioPaciente)
        {
            UsuarioPersister usuarioPersister = new UsuarioPersister();
            usuarioPersister.SaveUsuario(usuarioPaciente, out Data.DataInfrastructure dataInfrastructure);

            Model.Paciente responseUsuario = new Model.Paciente();
            responseUsuario = usuarioPaciente;

            dataInfrastructure.Dispose();

            return responseUsuario;
        }
    }
}
using System.Collections.Generic;
using Sagui.Business.Base;
using Sagui.Data.Lookup.GTO;
using Sagui.Data.Persister.GTO;
using Sagui.Data.Persister.PlanoOperadora;
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
            Model.Paciente responseUsuario = default(Model.Paciente);

            if (usuarioPaciente.Id != 0)
            {
                Data.DataInfrastructure _dataInfrastructure = dataInfrastructure;

                foreach (Model.PlanoOperadoraPaciente planoOperadoraPaciente in usuarioPaciente.ListaPlanoOperadoraPaciente)
                {
                    PlanoOperadoraPacientePersister planoOperadoraPacientePersister = new PlanoOperadoraPacientePersister();
                    var _persisted = planoOperadoraPacientePersister.SavePlanoOperadoraPaciente(planoOperadoraPaciente.PlanoOperadora.Id, usuarioPaciente.Id, planoOperadoraPaciente.NumeroPlano, _dataInfrastructure, out dataInfrastructure);

                    if (!_persisted)
                    {
                        dataInfrastructure.transaction.Rollback();
                        return null;
                    }
                    else
                    {
                        dataInfrastructure.transaction.Commit();
                        responseUsuario = usuarioPaciente;
                    }
                }
            }

            dataInfrastructure.Dispose();

            return responseUsuario;
        }
    }
}
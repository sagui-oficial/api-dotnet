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

            if (usuarioPaciente.Id > 0)
            {
                dataInfrastructure.transaction.Commit();
                responseUsuario = usuarioPaciente;
            }

            dataInfrastructure.Dispose();

            return responseUsuario;
        }

        public Model.Paciente Atualizar(Model.Paciente usuarioFuncionario)
        {
            UsuarioPersister usuarioPersister = new UsuarioPersister();
            usuarioPersister.AtualizarUsuario(usuarioFuncionario, out Data.DataInfrastructure dataInfrastructure);

            Model.Paciente responseUsuario = default(Model.Paciente);

            if (usuarioFuncionario.Id > 0)
            {
                dataInfrastructure.transaction.Commit();
                responseUsuario = usuarioFuncionario;
            }

            dataInfrastructure.Dispose();

            return responseUsuario;
        }

        public Model.Paciente Deletar(Model.Paciente usuarioFuncionario)
        {
            UsuarioPersister usuarioPersister = new UsuarioPersister();
            usuarioPersister.DeletarUsuario(usuarioFuncionario, out Data.DataInfrastructure dataInfrastructure);

            Model.Paciente responseUsuario = default(Model.Paciente);

            if (usuarioFuncionario.PublicID != null)
            {
                dataInfrastructure.transaction.Commit();
                responseUsuario = usuarioFuncionario;
            }

            dataInfrastructure.Dispose();

            return responseUsuario;
        }


        public Model.Paciente ObterPaciente(Model.Paciente Paciente)
        {
            UsuarioPacienteLookup pacienteLookup = new UsuarioPacienteLookup();
            var paciente = pacienteLookup.ObterUsuarioPaciente(Paciente);

            return paciente;
        }
    }
}
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
            Model.Paciente responseUsuario = usuarioPersister.SaveUsuario(usuarioPaciente);

            if (responseUsuario != null)
            {
                usuarioPersister.CommitCommand(true);
            }
            else
            {
                usuarioPersister.CommitCommand(false);
            }

            return responseUsuario;
        }

        public Model.Paciente Atualizar(Model.Paciente usuarioFuncionario)
        {
            UsuarioPersister usuarioPersister = new UsuarioPersister();
            Model.Paciente responseUsuario = usuarioPersister.AtualizarUsuario(usuarioFuncionario);

            if (responseUsuario != null)
            {
                usuarioPersister.CommitCommand(true);
            }
            else
            {
                usuarioPersister.CommitCommand(false);
            }

            return responseUsuario;
        }

        public Model.Paciente Deletar(Model.Paciente usuarioFuncionario)
        {
            UsuarioPersister usuarioPersister = new UsuarioPersister();
            Model.UsuarioBase responseUsuario = usuarioPersister.DeletarUsuario(usuarioFuncionario);

            if (responseUsuario != null)
            {
                usuarioPersister.CommitCommand(true);
            }
            else
            {
                usuarioPersister.CommitCommand(false);
            }

            return (Model.Paciente)responseUsuario;
        }


        public Model.Paciente ObterPaciente(Model.Paciente Paciente)
        {
            UsuarioPacienteLookup pacienteLookup = new UsuarioPacienteLookup();
            var paciente = pacienteLookup.ObterUsuarioPaciente(Paciente);

            return paciente;
        }

        //public List<Model.PlanoOperadoraPaciente> ListarPlanoOperadoraPaciente(Model.Paciente Paciente)
        //{
        //    UsuarioPacienteLookup usuarioLookup = new UsuarioPacienteLookup();
        //    var listUsuarios = usuarioLookup.ListarPlanoOperadoraPaciente(Paciente);

        //    return listUsuarios;
        //}
    }
}
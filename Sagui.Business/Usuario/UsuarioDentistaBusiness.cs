using System.Collections.Generic;
using Sagui.Business.Base;
using Sagui.Data.Lookup.GTO;
using Sagui.Data.Persister.GTO;
using Sagui.Data.Persister.Usuario;

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

        public Model.Dentinsta Obter(Model.Dentinsta usuario)
        {
            UsuarioDentistaLookup pacienteLookup = new UsuarioDentistaLookup();
            var paciente = pacienteLookup.ObterUsuarioDentista(usuario);

            return paciente;
        }
        
        public Model.Dentinsta Cadastrar(Model.Dentinsta usuarioDentista)
        {
            UsuarioPersister usuarioPersister = new UsuarioPersister();
            Model.Dentinsta responseUsuario = usuarioPersister.SaveUsuario(usuarioDentista);

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

        public Model.Dentinsta Atualizar(Model.Dentinsta usuarioDentista)
        {
            UsuarioPersister usuarioPersister = new UsuarioPersister();
            Model.Dentinsta responseUsuario = usuarioPersister.AtualizarUsuario(usuarioDentista);

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

        public Model.Dentinsta Deletar(Model.Dentinsta usuarioFuncionario)
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

            return (Model.Dentinsta)responseUsuario;
        }
    }
}
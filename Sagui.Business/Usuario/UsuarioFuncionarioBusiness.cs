using System.Collections.Generic;
using Sagui.Business.Base;
using Sagui.Data.Lookup.GTO;
using Sagui.Data.Lookup.Usuario;
using Sagui.Data.Persister.GTO;
using Sagui.Data.Persister.Usuario;

namespace Sagui.Business.Usuario
{

    public class UsuarioFuncionarioBusiness : BusinessBase
    {
        public List<Model.Funcionario> ListUsuariosFuncionario()
        {
            UsuarioFuncionarioLookup usuarioLookup = new UsuarioFuncionarioLookup();
            var listUsuarios = usuarioLookup.ListUsuarioFuncionario();

            return listUsuarios;
        }

        public Model.Funcionario Cadastrar(Model.Funcionario usuarioFuncionario)
        {
            UsuarioPersister usuarioPersister = new UsuarioPersister();
            Model.Funcionario responseUsuario = usuarioPersister.SaveUsuario(usuarioFuncionario);

            if(responseUsuario != null)
            {
                usuarioPersister.CommitCommand(true);
            }
            else
            {
                usuarioPersister.CommitCommand(false);
            }

            return responseUsuario;
        }

        public Model.Funcionario Atualizar(Model.Funcionario usuarioFuncionario)
        {
            UsuarioPersister usuarioPersister = new UsuarioPersister();
            Model.Funcionario responseUsuario = usuarioPersister.AtualizarUsuario(usuarioFuncionario);

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

        public Model.Funcionario Deletar(Model.Funcionario usuarioFuncionario)
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

            return (Model.Funcionario)responseUsuario;
        }

        public Model.Funcionario Obter(Model.Funcionario usuarioFuncionario)
        {
            UsuarioFuncionarioLookup usuarioLookup = new UsuarioFuncionarioLookup();
            var listUsuarios = usuarioLookup.Obter(usuarioFuncionario);

            return listUsuarios;
        }
    }
}
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

        public Model.Dentinsta Cadastrar(Model.Dentinsta usuario)
        {
            UsuarioPersister usuarioPersister = new UsuarioPersister();
            usuarioPersister.AtualizarUsuario(usuario, out Data.DataInfrastructure dataInfrastructure);

            Model.Dentinsta responseUsuario = default(Model.Dentinsta);

            if (usuario.Id > 0)
            {
                dataInfrastructure.transaction.Commit();
                responseUsuario = usuario;
            }

            dataInfrastructure.Dispose();

            return responseUsuario;
        }

        public Model.Dentinsta Atualizar(Model.Dentinsta usuarioFuncionario)
        {
            UsuarioPersister usuarioPersister = new UsuarioPersister();
            usuarioPersister.AtualizarUsuario(usuarioFuncionario, out Data.DataInfrastructure dataInfrastructure);

            Model.Dentinsta responseUsuario = default(Model.Dentinsta);

            if (usuarioFuncionario.Id > 0)
            {
                dataInfrastructure.transaction.Commit();
                responseUsuario = usuarioFuncionario;
            }

            dataInfrastructure.Dispose();

            return responseUsuario;
        }

        public Model.Dentinsta Deletar(Model.Dentinsta usuarioFuncionario)
        {
            UsuarioPersister usuarioPersister = new UsuarioPersister();
            usuarioPersister.DeletarUsuario(usuarioFuncionario, out Data.DataInfrastructure dataInfrastructure);

            Model.Dentinsta responseUsuario = default(Model.Dentinsta);

            if (usuarioFuncionario.PublicID != null)
            {
                dataInfrastructure.transaction.Commit();
                responseUsuario = usuarioFuncionario;
            }

            dataInfrastructure.Dispose();

            return responseUsuario;
        }
    }
}
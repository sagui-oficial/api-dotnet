using System.Collections.Generic;
using Sagui.Business.Base;
using Sagui.Data.Lookup.GTO;
using Sagui.Data.Persister.GTO;

namespace Sagui.Business.Usuario
{

    public class UsuarioBusiness : BusinessBase
    {
        public List<Model.Dentinsta> ListUsuariosDentista()
        {
            UsuarioLookup usuarioLookup = new UsuarioLookup();
            var listUsuarios = usuarioLookup.ListUsuarioDentista();

            return listUsuarios;
        }

        public List<Model.Funcionario> ListUsuariosFuncionario()
        {
            UsuarioLookup usuarioLookup = new UsuarioLookup();
            var listUsuarios = usuarioLookup.ListUsuarioFuncionario();

            return listUsuarios;
        }

        public Model.Funcionario Cadastrar(Model.Funcionario usuarioFuncionario)
        {
            UsuarioPersister usuarioPersister = new UsuarioPersister();
            usuarioPersister.SaveUsuario(usuarioFuncionario, out Data.DataInfrastructure dataInfrastructure);

            Model.Funcionario responseUsuario = new Model.Funcionario();
            responseUsuario = usuarioFuncionario;

            dataInfrastructure.Dispose();

            return responseUsuario;
        }

        public Model.Dentinsta Cadastrar(Model.Dentinsta usuarioDentista)
        {
            UsuarioPersister usuarioPersister = new UsuarioPersister();
            usuarioPersister.SaveUsuario(usuarioDentista, out Data.DataInfrastructure dataInfrastructure);

            Model.Dentinsta responseUsuario = new Model.Dentinsta();
            responseUsuario = usuarioDentista;

            dataInfrastructure.Dispose();

            return responseUsuario;
        }
    }
}
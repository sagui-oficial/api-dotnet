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
            usuarioPersister.SaveUsuario(usuarioFuncionario, out Data.DataInfrastructure dataInfrastructure);

            Model.Funcionario responseUsuario = default(Model.Funcionario);

            if(usuarioFuncionario.Id > 0)
            {
                dataInfrastructure.transaction.Commit();
                responseUsuario = usuarioFuncionario;
            }

            dataInfrastructure.Dispose();

            return responseUsuario;
        }
    }
}
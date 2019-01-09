using Sagui.Service.Contracts;
using System.Collections.Generic;

namespace Sagui.Service.Usuario
{
    public class UsuarioFuncionarioService : IUsuarioService<Model.Funcionario, Model.Funcionario>
    {
        public Model.Funcionario Atualizar(Model.Funcionario model)
        {
            throw new System.NotImplementedException();
        }

        public Model.Funcionario Cadastrar(Model.Funcionario Usuario)
        {
            using (var usuarioBusiness = new Business.Usuario.UsuarioFuncionarioBusiness())
            {
                var _return = usuarioBusiness.Cadastrar(Usuario);
                usuarioBusiness.Dispose();
                return _return;
            }
        }

        public Model.Funcionario Deletar(Model.Funcionario model)
        {
            throw new System.NotImplementedException();
        }

        public List<Model.Funcionario> Listar()
        {
            using (var usuarioBusiness = new Business.Usuario.UsuarioFuncionarioBusiness())
            {
                var _return = usuarioBusiness.ListUsuariosFuncionario();
                usuarioBusiness.Dispose();
                return _return;
            }
        }
    }
}
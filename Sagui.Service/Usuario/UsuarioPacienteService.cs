using Sagui.Service.Contracts;
using System.Collections.Generic;

namespace Sagui.Service.Usuario
{
    public class UsuarioPacienteService : IUsuarioService<Model.Paciente, Model.Paciente>
    {
        public Model.Paciente Atualizar(Model.Paciente model)
        {
            throw new System.NotImplementedException();
        }

        public Model.Paciente Cadastrar(Model.Paciente Usuario)
        {
            using (var usuarioBusiness = new Business.Usuario.UsuarioPacienteBusiness())
            {
                var _return = usuarioBusiness.Cadastrar(Usuario);
                usuarioBusiness.Dispose();
                return _return;
            }
        }

        public Model.Paciente Deletar(Model.Paciente model)
        {
            throw new System.NotImplementedException();
        }

        public List<Model.Paciente> Listar()
        {
            using (var usuarioBusiness = new Business.Usuario.UsuarioPacienteBusiness())
            {
                var _return = usuarioBusiness.ListUsuarios();
                usuarioBusiness.Dispose();
                return _return;
            }
        }
    }
}
using Sagui.Model;
using Sagui.Model.ValueObject;
using Sagui.Service.RequestResponse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sagui.Test.Mocks
{
    public static class MockUsuario
    {
        public static RequestUsuarioFuncionario CriarMockUsuarioFuncionario()
        {
            RequestUsuarioFuncionario UsuarioFuncionario = new RequestUsuarioFuncionario();
            UsuarioFuncionario.Nome = "Maria";
            UsuarioFuncionario.Funcao = "Secretaria";
            UsuarioFuncionario.Anotacoes = "Faz tudo";
            UsuarioFuncionario.CPF = "30030030030";
            UsuarioFuncionario.Email = "aaa@aaa.com.br";
            UsuarioFuncionario.Telefone = "11912345678";
            UsuarioFuncionario.TipoUsuario = TipoUsuario.Tipo.Funcionario.GetHashCode();
            UsuarioFuncionario.PublicID = new Guid("a97480cc-7e17-11e9-b2de-705a0f6970c5");

            return UsuarioFuncionario;
        }

        public static RequestUsuarioDentista CriarMockUsuarioDentista()
        {
            RequestUsuarioDentista UsuarioDentista = new RequestUsuarioDentista();
            UsuarioDentista.Nome = "Maria";
            UsuarioDentista.Funcao = "Secretaria";
            UsuarioDentista.Anotacoes = "Faz tudo";
            UsuarioDentista.CPF = "30030030030";
            UsuarioDentista.Email = "aaa@aaa.com.br";
            UsuarioDentista.CRO = "CRO0001111";
            UsuarioDentista.Telefone = "11912345678";
            UsuarioDentista.TipoUsuario = TipoUsuario.Tipo.Dentista.GetHashCode();
            UsuarioDentista.PublicID = new Guid("a97480cc-7e17-11e9-b2de-705a0f6970c5");

            return UsuarioDentista;
        }


        public static RequestUsuarioPaciente CriarMockUsuarioPaciente()
        {
            RequestUsuarioPaciente UsuarioPaciente = new RequestUsuarioPaciente();
            UsuarioPaciente.Nome = "Maria";
            UsuarioPaciente.Funcao = "Secretaria";
            UsuarioPaciente.Anotacoes = "Faz tudo";
            UsuarioPaciente.CPF = "30030030030";
            UsuarioPaciente.Email = "aaa@aaa.com.br";
            UsuarioPaciente.Telefone = "11912345678";
            UsuarioPaciente.TipoUsuario = TipoUsuario.Tipo.Paciente.GetHashCode();
            UsuarioPaciente.PublicID = new Guid("a97480cc-7e17-11e9-b2de-705a0f6970c5");
            UsuarioPaciente.PlanoOperadoraId = 1;
            UsuarioPaciente.NumeroPlano = "123456789";

            //PlanoOperadoraPaciente planoOperadoraPaciente = new PlanoOperadoraPaciente();
            //planoOperadoraPaciente.PlanoOperadoraId = 1;
            //planoOperadoraPaciente.NumeroPlano = "123456789";
            //planoOperadoraPaciente.PacienteId = 1;
            

            //UsuarioPaciente.ListaPlanoOperadoraPaciente = new List<PlanoOperadoraPaciente>();
            //UsuarioPaciente.ListaPlanoOperadoraPaciente.Add(planoOperadoraPaciente);

            return UsuarioPaciente;
        }

    }
}

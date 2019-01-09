using Sagui.Model;
using Sagui.Service.RequestResponse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sagui.Test.Mocks
{
    public class MockUsuario
    {
        public RequestUsuarioFuncionario CriarMockUsuarioFuncionario()
        {
            RequestUsuarioFuncionario UsuarioFuncionario = new RequestUsuarioFuncionario();
            UsuarioFuncionario.Id = 1;
            UsuarioFuncionario.Nome = "Maria";
            UsuarioFuncionario.Funcao = "Secretaria";
            UsuarioFuncionario.Anotacoes = "Faz tudo";
            UsuarioFuncionario.CPF = "30030030030";
            UsuarioFuncionario.Email = "aaa@aaa.com.br";

            return UsuarioFuncionario;
        }

        public RequestUsuarioDentista CriarMockUsuarioDentista()
        {
            RequestUsuarioDentista UsuarioDentista = new RequestUsuarioDentista();
            UsuarioDentista.Id = 1;
            UsuarioDentista.Nome = "Maria";
            UsuarioDentista.Funcao = "Secretaria";
            UsuarioDentista.Anotacoes = "Faz tudo";
            UsuarioDentista.CPF = "30030030030";
            UsuarioDentista.Email = "aaa@aaa.com.br";
            UsuarioDentista.CRO = "CRO0001111";

            return UsuarioDentista;
        }


        public RequestUsuarioPaciente CriarMockUsuarioPaciente()
        {
            RequestUsuarioPaciente UsuarioPaciente = new RequestUsuarioPaciente();
            UsuarioPaciente.Id = 1;
            UsuarioPaciente.Nome = "Maria";
            UsuarioPaciente.Funcao = "Secretaria";
            UsuarioPaciente.Anotacoes = "Faz tudo";
            UsuarioPaciente.CPF = "30030030030";
            UsuarioPaciente.Email = "aaa@aaa.com.br";
            UsuarioPaciente.PlanoOperadora = new PlanoOperadora
            {
                CNPJ = "0000000000000",
                NomeFantasia = "Plano",
                Id = 1,
                RazaoSocial = "Plano SA"
            };
            UsuarioPaciente.NumeroPlano = "123456789";

            return UsuarioPaciente;
        }
    }
}

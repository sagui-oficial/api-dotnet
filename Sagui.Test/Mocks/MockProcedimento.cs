using Sagui.Service.RequestResponse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sagui.Test.Mocks
{
    public class MockProcedimento
    {
        public static RequestProcedimento CriarMockProcedimento()
        {
            RequestProcedimento Procedimento = new RequestProcedimento();
            Procedimento.Id = 1;
            Procedimento.Codigo = "1";
            Procedimento.Anotacoes = "AAAAAA";
            Procedimento.Exigencias = "AAAAAA";
            Procedimento.NomeProcedimento = "Procedimento de Teste";
            Procedimento.ValorProcedimento = 150.00;

            return Procedimento;
        }

        public static RequestProcedimento CriarMockProcedimentoB()
        {
            RequestProcedimento Procedimento = new RequestProcedimento();
            Procedimento.Id = 2;
            Procedimento.Codigo = "1";
            Procedimento.Anotacoes = "AAAAAA";
            Procedimento.Exigencias = "AAAAAA";
            Procedimento.NomeProcedimento = "Procedimento de Teste";
            Procedimento.ValorProcedimento = 175.00;

            return Procedimento;
        }

        public static RequestProcedimento AtualizarMockProcedimento()
        {
            RequestProcedimento Procedimento = new RequestProcedimento();
            Procedimento.Id = 1;
            Procedimento.Codigo = "1";
            Procedimento.Anotacoes = "ZZZZZZZ";
            Procedimento.Exigencias = "ZZZZZZZZ";
            Procedimento.NomeProcedimento = "Procedimento de Teste UPDATE";
            Procedimento.ValorProcedimento = 1.00;
            Procedimento.PublicID = new Guid("a9872e2a-7e17-11e9-b2e0-705a0f6970c5");

            return Procedimento;
        }

        public static RequestProcedimento ObterMockProcedimento()
        {
            RequestProcedimento Procedimento = new RequestProcedimento();
            Procedimento.Id = 1;
            Procedimento.Codigo = "1";
            Procedimento.Anotacoes = "AAAAAA";
            Procedimento.Exigencias = "AAAAAA";
            Procedimento.NomeProcedimento = "Procedimento de Teste";
            Procedimento.ValorProcedimento = 1.00;
            Procedimento.PublicID = new Guid("a9872e2a-7e17-11e9-b2e0-705a0f6970c5");

            return Procedimento;
        }

        public static RequestProcedimento DeletarMockProcedimento()
        {
            RequestProcedimento Procedimento = new RequestProcedimento();
            Procedimento.Id = 1;
            Procedimento.Codigo = "1";
            Procedimento.Anotacoes = "AAAAAA";
            Procedimento.Exigencias = "AAAAAA";
            Procedimento.NomeProcedimento = "Procedimento de Teste";
            Procedimento.ValorProcedimento = 1.00;
            Procedimento.PublicID = new Guid("2f324660-78d5-11e9-be91-705a0f6970c5");

            return Procedimento;
        }

    }
}

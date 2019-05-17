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
        public RequestProcedimento CriarMockProcedimento()
        {
            RequestProcedimento Procedimento = new RequestProcedimento();
            Procedimento.IdProcedimento = 1;
            Procedimento.Codigo = 1;
            Procedimento.Anotacoes = "AAAAAA";
            Procedimento.Exigencias = "AAAAAA";
            Procedimento.NomeProcedimento = "Procedimento de Teste";
            Procedimento.ValorProcedimento = 1.00;

            return Procedimento;
        }

        public RequestProcedimento AtualizarMockProcedimento()
        {
            RequestProcedimento Procedimento = new RequestProcedimento();
            Procedimento.IdProcedimento = 1;
            Procedimento.Codigo = 1;
            Procedimento.Anotacoes = "ZZZZZZZ";
            Procedimento.Exigencias = "ZZZZZZZZ";
            Procedimento.NomeProcedimento = "Procedimento de Teste UPDATE";
            Procedimento.ValorProcedimento = 1.00;
            Procedimento.PublicID = new Guid("18ecb2ec-78c0-11e9-9000-705a0f6970c5");

            return Procedimento;
        }

        public RequestProcedimento ObterMockProcedimento()
        {
            RequestProcedimento Procedimento = new RequestProcedimento();
            Procedimento.IdProcedimento = 1;
            Procedimento.Codigo = 1;
            Procedimento.Anotacoes = "AAAAAA";
            Procedimento.Exigencias = "AAAAAA";
            Procedimento.NomeProcedimento = "Procedimento de Teste";
            Procedimento.ValorProcedimento = 1.00;
            Procedimento.PublicID = new Guid("18ecb2ec-78c0-11e9-9000-705a0f6970c5");

            return Procedimento;
        }

        public RequestProcedimento DeletarMockProcedimento()
        {
            RequestProcedimento Procedimento = new RequestProcedimento();
            Procedimento.IdProcedimento = 1;
            Procedimento.Codigo = 1;
            Procedimento.Anotacoes = "AAAAAA";
            Procedimento.Exigencias = "AAAAAA";
            Procedimento.NomeProcedimento = "Procedimento de Teste";
            Procedimento.ValorProcedimento = 1.00;
            Procedimento.PublicID = new Guid("18ecb2ec-78c0-11e9-9000-705a0f6970c5");

            return Procedimento;
        }

    }
}

using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Sagui.Application.Infra;
using Sagui.Model;
using Sagui.Service.Procedimento;
using Sagui.Service.RequestResponse;
using Sagui.Service.RequestResponse.Handlers;

namespace Sagui.Application.Controllers
{
    [Route("backoffice/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class ProcedimentoController : Controller
    {

        //GET: api/Procedimento/5
        [HttpGet("{uuid}", Name = "ObterProcedimento")]
        public async Task<IActionResult> ObterGTO(Guid uuid)
        {

            RequestProcedimento requestProcedimento = new RequestProcedimento
            {
                PublicID = uuid
            };

            ProcedimentoService procedimentoService = new ProcedimentoService();

            ObterProcedimentoRequestHandler ObterProcedimentoRequestHandler = new ObterProcedimentoRequestHandler(procedimentoService);

            return await this.HandleRequest(ObterProcedimentoRequestHandler, requestProcedimento);

        }


        [HttpGet("", Name = "ListarProcedimento")]
        public async Task<IActionResult> GetAsync([FromQuery] PagingParameterModel paging )
        {
            RequestProcedimento requestProcedimento = new RequestProcedimento();

            requestProcedimento.PagingParameter = paging;

            ProcedimentoService procedimentoService = new ProcedimentoService();

            ListarProcedimentoRequestHandler listarProcedimentoRequestHandler = new ListarProcedimentoRequestHandler(procedimentoService);

            return await this.HandleRequest(listarProcedimentoRequestHandler, requestProcedimento);

        }

        [HttpGet("Procedimento_Operadora", Name = "Procedimento_Operadora")]
        public async Task<IActionResult> ListarProcedimento_Operadora([FromBody]  RequestPlanoOperadora requestPlanoOperadora)
        {

            ProcedimentoService procedimentoService = new ProcedimentoService();

            ListarProcedimento_PlanoOperadoraRequestHandler listarProcedimentoRequestHandler = new ListarProcedimento_PlanoOperadoraRequestHandler(procedimentoService);

            return await this.HandleRequest(listarProcedimentoRequestHandler, requestPlanoOperadora);

        }



        [HttpPost("", Name = "CriarProcedimento")]
        public async Task<IActionResult> CriarProcedimento([FromBody]  RequestProcedimento requestProcedimento)
        {
            ProcedimentoService ProcedimentoService = new ProcedimentoService();
            requestProcedimento.ValorProcedimento = 1;

            CriarProcedimentoRequestHandler criarProcedimentoRequestHandler = new CriarProcedimentoRequestHandler(ProcedimentoService);

            return await this.HandleRequest(criarProcedimentoRequestHandler, requestProcedimento);

        }

        [HttpPatch("", Name = "AtualizarProcedimento")]
        public async Task<IActionResult> AtualizarProcedimento([FromBody]  RequestProcedimento requestProcedimento)
        {
            ProcedimentoService ProcedimentoService = new ProcedimentoService();
            requestProcedimento.ValorProcedimento = 1;

            AtualizarProcedimentoRequestHandler criarProcedimentoRequestHandler = new AtualizarProcedimentoRequestHandler(ProcedimentoService);

            return await this.HandleRequest(criarProcedimentoRequestHandler, requestProcedimento);

        }

        [HttpPatch("{uuid}", Name = "DeletarProcedimento")]
        public async Task<IActionResult> DeletarProcedimento(Guid uuid)
        {

            RequestProcedimento requestProcedimento = new RequestProcedimento
            {
                PublicID = uuid
            };
            ProcedimentoService ProcedimentoService = new ProcedimentoService();

            DeletarProcedimentoRequestHandler deletarProcedimentoRequestHandler = new DeletarProcedimentoRequestHandler(ProcedimentoService);

            return await this.HandleRequest(deletarProcedimentoRequestHandler, requestProcedimento);

        }


       
    }
}
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Sagui.Application.Infra;
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
        [HttpGet("{gtopublicid}/ObterProcedimento", Name = "ObterProcedimento")]
        public async Task<IActionResult> ObterGTO(Guid gtopublicid)
        {

            RequestProcedimento requestProcedimento = new RequestProcedimento
            {
                PublicID = gtopublicid
            };

            ProcedimentoService procedimentoService = new ProcedimentoService();

            ObterProcedimentoRequestHandler ObterProcedimentoRequestHandler = new ObterProcedimentoRequestHandler(procedimentoService);

              return await this.HandleRequest(ObterProcedimentoRequestHandler, requestProcedimento);

        }

        
        [HttpGet("ListarProcedimento", Name = "ListarProcedimento")]
        public async Task<IActionResult> GetAsync(int status)
        {
            RequestProcedimento requestProcedimento = default(RequestProcedimento);
            //if (status != 0)
            //{
            //    requestProcedimento.Status = status;
            //}

            ProcedimentoService procedimentoService = new ProcedimentoService();

            ListarProcedimentoRequestHandler listarProcedimentoRequestHandler = new ListarProcedimentoRequestHandler(procedimentoService);
            
            return await this.HandleRequest(listarProcedimentoRequestHandler, requestProcedimento);
            
        }

       
       
        [HttpPost("CriarProcedimento", Name = "CriarProcedimento")]
        public async Task<IActionResult> CriarProcedimento([FromBody]  RequestProcedimento requestProcedimento)
        {
            ProcedimentoService ProcedimentoService = new ProcedimentoService();

            CriarProcedimentoRequestHandler criarProcedimentoRequestHandler = new CriarProcedimentoRequestHandler(ProcedimentoService);

            return await this.HandleRequest(criarProcedimentoRequestHandler, requestProcedimento);

        }

        [HttpPost("AtualizarProcedimento", Name = "AtualizarProcedimento")]
        public async Task<IActionResult> AtualizarProcedimento([FromBody]  RequestProcedimento requestProcedimento)
        {
            ProcedimentoService ProcedimentoService = new ProcedimentoService();

            AtualizarProcedimentoRequestHandler criarProcedimentoRequestHandler = new AtualizarProcedimentoRequestHandler(ProcedimentoService);

            return await this.HandleRequest(criarProcedimentoRequestHandler, requestProcedimento);

        }

        [HttpPatch("{gtopublicid}/DeletarProcedimento", Name = "DeletarProcedimento")]
        public async Task<IActionResult> DeletarProcedimento(Guid gtopublicid)
        {

            RequestProcedimento requestProcedimento = new RequestProcedimento
            {
                PublicID = gtopublicid
            };
            ProcedimentoService ProcedimentoService = new ProcedimentoService();

            AtualizarProcedimentoRequestHandler criarProcedimentoRequestHandler = new AtualizarProcedimentoRequestHandler(ProcedimentoService);

            return await this.HandleRequest(criarProcedimentoRequestHandler, requestProcedimento);

        }

    }
}
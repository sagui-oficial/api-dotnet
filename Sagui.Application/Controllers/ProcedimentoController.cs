using System;
using System.Collections.Generic;
using System.Linq;
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
      //  GET: api/Procedimento
       [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            RequestProcedimento requestProcedimento = default(RequestProcedimento);

            ProcedimentoService ProcedimentoService = new ProcedimentoService();

            ListarProcedimentoRequestHandler listarProcedimentoRequestHandler = new ListarProcedimentoRequestHandler(ProcedimentoService);
            
            return await this.HandleRequest(listarProcedimentoRequestHandler, requestProcedimento);
            
        }

        // GET: api/Procedimento/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Procedimento
        [HttpPost]
        public void Post([FromBody] string value)
        {
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

        [HttpPost("DeletarProcedimento", Name = "DeletarProcedimento")]
        public async Task<IActionResult> DeletarProcedimento([FromBody]  RequestProcedimento requestProcedimento)
        {
            ProcedimentoService ProcedimentoService = new ProcedimentoService();

            AtualizarProcedimentoRequestHandler criarProcedimentoRequestHandler = new AtualizarProcedimentoRequestHandler(ProcedimentoService);

            return await this.HandleRequest(criarProcedimentoRequestHandler, requestProcedimento);

        }

    }
}
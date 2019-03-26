using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sagui.Application.Infra;
using Sagui.Service.Arquivo;
using Sagui.Service.Contracts;
using Sagui.Service.GTO;
using Sagui.Service.Procedimento;
using Sagui.Service.RequestResponse;
using Sagui.Service.RequestResponse.Handlers;

namespace Sagui.Application.Controllers
{
    [Route("backoffice/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class GTOController : Controller
    {
        // GET: api/GTO
        [HttpGet("{gtopublicid}/ObterGTO", Name = "ObterGTO")]
        public async Task<IActionResult> ObterGTO(Guid gtopublicid)
        {

            RequestGTO requestGTO = new RequestGTO
            {
                PublicID = gtopublicid
            };

            GTOService gTOService = new GTOService();

            ObterGTORequestHandler ObterGTORequestHandler = new ObterGTORequestHandler(gTOService);

            return await this.HandleRequest(ObterGTORequestHandler, requestGTO);

        }

        [HttpGet("ListarGTO", Name = "ListarGTO")]
        public async Task<IActionResult> ListarGTO()
        {
            RequestGTO requestGTO = default(RequestGTO);

            GTOService gTOService = new GTOService();
            ArquivoService arquivoService = new ArquivoService();
            ProcedimentoService procedimentoService = new ProcedimentoService();

            ListarGTORequestHandler listarGTORequestHandler = new ListarGTORequestHandler(gTOService, arquivoService, procedimentoService);

            return await this.HandleRequest(listarGTORequestHandler, requestGTO);

        }

        [HttpPost("CriarGTO", Name = "CriarGTO")]
        public async Task<IActionResult> CriarGTO([FromBody]  RequestGTO requestGTO)
        {
            GTOService gTOService = new GTOService();

            CriarGTORequestHandler GTORequestHandler = new CriarGTORequestHandler(gTOService);

            return await this.HandleRequest(GTORequestHandler, requestGTO);

        }

        [HttpPatch("AtualizarGTO", Name = "AtualizarGTO")]
        public async Task<IActionResult> AtualizarGTO([FromBody]  RequestGTO requestGTO)
        {
            GTOService gTOService = new GTOService();

            AtualizarGTORequestHandler GTORequestHandler = new AtualizarGTORequestHandler(gTOService);

            return await this.HandleRequest(GTORequestHandler, requestGTO);

        }

        [HttpPatch("{gtopublicid}/DeletarGTO", Name = "DeletarGTO")]
        public async Task<IActionResult> DeletarGTO(Guid gtopublicid)
        {
            RequestGTO requestGTO = new RequestGTO
            {
                PublicID = gtopublicid
            };
            GTOService gTOService = new GTOService();

            DeletarGTORequestHandler GTORequestHandler = new DeletarGTORequestHandler(gTOService);

            return await this.HandleRequest(GTORequestHandler, requestGTO);

        }


    }
}

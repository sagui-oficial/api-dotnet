using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Sagui.Application.Infra;
using Sagui.Service.Arquivo;
using Sagui.Service.GTO;
using Sagui.Service.Lote;
using Sagui.Service.Procedimento;
using Sagui.Service.RequestResponse;
using Sagui.Service.RequestResponse.Handlers;

namespace Sagui.Application.Controllers
{
    [Route("backoffice/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class LoteController : Controller
    {
        // GET: api/Lote
        [HttpGet("{uuid}", Name = "ObterLote")]
        public async Task<IActionResult> ObterLote(Guid uuid)
        {

            RequestLote requestLote = new RequestLote
            {
                PublicID = uuid
            };

            LoteService LoteService = new LoteService();
            GTOService GTOoService = new GTOService();
            

            ObterLoteRequestHandler ObterLoteRequestHandler = new ObterLoteRequestHandler(LoteService, GTOoService);

            return await this.HandleRequest(ObterLoteRequestHandler, requestLote);

        }

        [HttpGet("", Name = "ListarLote")]
        public async Task<IActionResult> ListarLote()
        {
            RequestLote requestLote = default(RequestLote);
            LoteService LoteService = new LoteService();
            
            ListarLoteRequestHandler listarLoteRequestHandler = new ListarLoteRequestHandler(LoteService);

            return await this.HandleRequest(listarLoteRequestHandler, requestLote);

        }

        [HttpPost("", Name = "CriarLote")]
        public async Task<IActionResult> CriarLote([FromBody]  RequestLote requestLote)
        {
            LoteService LoteService = new LoteService();

            CriarLoteRequestHandler LoteRequestHandler = new CriarLoteRequestHandler(LoteService);

            return await this.HandleRequest(LoteRequestHandler, requestLote);

        }

        [HttpPatch("", Name = "AtualizarLote")]
        public async Task<IActionResult> AtualizarLote([FromBody]  RequestLote requestLote)
        {
            LoteService LoteService = new LoteService();

            AtualizarLoteRequestHandler LoteRequestHandler = new AtualizarLoteRequestHandler(LoteService);

            return await this.HandleRequest(LoteRequestHandler, requestLote);

        }

        [HttpPatch("{uuid}", Name = "DeletarLote")]
        public async Task<IActionResult> DeletarLote(Guid uuid)
        {
            RequestLote requestLote = new RequestLote
            {
                PublicID = uuid
            };
            LoteService LoteService = new LoteService();

            DeletarLoteRequestHandler LoteRequestHandler = new DeletarLoteRequestHandler(LoteService);

            return await this.HandleRequest(LoteRequestHandler, requestLote);

        }


    }
}

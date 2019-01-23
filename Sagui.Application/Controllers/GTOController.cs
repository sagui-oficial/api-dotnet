using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sagui.Application.Infra;
using Sagui.Service.Contracts;
using Sagui.Service.GTO;
using Sagui.Service.RequestResponse;
using Sagui.Service.RequestResponse.Handlers;

namespace Sagui.Application.Controllers
{
    [Route("backoffice/[controller]")]
    [Produces ("application/json")]
    [ApiController]
    public class GTOController : Controller
    {
        // GET: api/GTO
        [HttpGet]
        public IEnumerable<string> Get()
        {
            GTOService gTOService = new GTOService();

            CriarGTORequestHandler criarGTORequestHandler = new CriarGTORequestHandler(gTOService);
            ListarGTORequestHandler listarGTORequestHandler = new ListarGTORequestHandler(gTOService);

            RequestGTO requestGTO = default(RequestGTO);

            return this.HandleRequest(listarGTORequestHandler, requestGTO);
        }

        // GET: api/GTO/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/GTO
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        
        [HttpPost("CriarGTO", Name = "CriarGTO")]
        public async Task<IActionResult> CriarGTO([FromBody]  RequestGTO requestGTO)
        {
            GTOService gTOService = new GTOService();

            CriarGTORequestHandler criarGTORequestHandler = new CriarGTORequestHandler(gTOService);

            return await this.HandleRequest(criarGTORequestHandler, requestGTO);

        }

        [HttpPost("AtualizarGTO", Name = "AtualizarGTO")]
        public async Task<IActionResult> AtualizarGTO([FromBody]  RequestGTO requestGTO)
        {
            GTOService gTOService = new GTOService();

            AtualizarGTORequestHandler criarGTORequestHandler = new AtualizarGTORequestHandler(gTOService);

            return await this.HandleRequest(criarGTORequestHandler, requestGTO);

        }

        [HttpPost("DeletarGTO", Name = "DeletarGTO")]
        public async Task<IActionResult> DeletarGTO([FromBody]  RequestGTO requestGTO)
        {
            GTOService gTOService = new GTOService();

            AtualizarGTORequestHandler criarGTORequestHandler = new AtualizarGTORequestHandler(gTOService);

            return await this.HandleRequest(criarGTORequestHandler, requestGTO);

        }

      
    }
}

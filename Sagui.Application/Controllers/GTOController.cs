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
        public async Task<IActionResult> GetAsync()
        {
            RequestGTO requestGTO = default(RequestGTO);

            GTOService gTOService = new GTOService();

            ListarGTORequestHandler listarGTORequestHandler = new ListarGTORequestHandler(gTOService);

            return await this.HandleRequest(listarGTORequestHandler, requestGTO);

            }

        // GET: api/GTO/5
        //[HttpGet("{id}", Name = "Get")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

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

        [HttpPut("AtualizarGTO", Name = "AtualizarGTO")]
        public async Task<IActionResult> AtualizarGTO([FromBody]  RequestGTO requestGTO)
        {
            GTOService gTOService = new GTOService();

            AtualizarGTORequestHandler criarGTORequestHandler = new AtualizarGTORequestHandler(gTOService);

            return await this.HandleRequest(criarGTORequestHandler, requestGTO);

        }

        [HttpPut("DeletarGTO", Name = "DeletarGTO")]
        public async Task<IActionResult> DeletarGTO([FromBody]  RequestGTO requestGTO)
        {
            GTOService gTOService = new GTOService();

            AtualizarGTORequestHandler criarGTORequestHandler = new AtualizarGTORequestHandler(gTOService);

            return await this.HandleRequest(criarGTORequestHandler, requestGTO);

        }

      
    }
}

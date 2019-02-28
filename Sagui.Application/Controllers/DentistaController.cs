using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sagui.Application.Infra;
using Sagui.Service.Contracts;
using Sagui.Service.RequestResponse;
using Sagui.Service.RequestResponse.Handlers;
using Sagui.Service.Usuario;

namespace Sagui.Application.Controllers
{
    [Route("backoffice/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class DentistaController : Controller
    {
        // GET: api/GTO
        [HttpGet("{userPublicId}/ObterDentista", Name = "ObterDentista")]
        public async Task<IActionResult> ObterDentista(Guid userPublicId)
        {

            RequestUsuarioDentista requestUsuarioDentista = new RequestUsuarioDentista
            {
                PublicID = userPublicId
            };

            UsuarioDentistaService DentistaService = new UsuarioDentistaService();

            ObterUsuarioDentistaRequestHandler ObterUsuarioDentistaRequestHandler = new ObterUsuarioDentistaRequestHandler(DentistaService);

            return await this.HandleRequest(ObterUsuarioDentistaRequestHandler, requestUsuarioDentista);

        }

        [HttpGet("ListarDentista", Name = "ListarDentista")]
        public async Task<IActionResult> ListarDentista()
        {
            RequestUsuarioDentista requestUsuarioDentista = default(RequestUsuarioDentista);

            UsuarioDentistaService DentistaService = new UsuarioDentistaService();

            ListarUsuarioDentistaRequestHandler listarUsuarioDentistaRequestHandler = new ListarUsuarioDentistaRequestHandler(DentistaService);

            return await this.HandleRequest(listarUsuarioDentistaRequestHandler, requestUsuarioDentista);

        }

        [HttpPost("CriarDentista", Name = "CriarDentista")]
        public async Task<IActionResult> CriarDentista([FromBody]  RequestUsuarioDentista requestUsuarioDentista)
        {
            UsuarioDentistaService DentistaService = new UsuarioDentistaService();

            CriarUsuarioDentistaRequestHandler UsuarioDentistaRequestHandler = new CriarUsuarioDentistaRequestHandler(DentistaService);

            return await this.HandleRequest(UsuarioDentistaRequestHandler, requestUsuarioDentista);

        }

        [HttpPut("AtualizarDentista", Name = "AtualizarDentista")]
        public async Task<IActionResult> AtualizarDentista([FromBody]  RequestUsuarioDentista requestUsuarioDentista)
        {
            UsuarioDentistaService DentistaService = new UsuarioDentistaService();

            AtualizarUsuarioDentistaRequestHandler AtualizarUsuarioDentistaRequestHandler = new AtualizarUsuarioDentistaRequestHandler(DentistaService);

            return await this.HandleRequest(AtualizarUsuarioDentistaRequestHandler, requestUsuarioDentista);

        }

        [HttpPut("{userPublicId}/DeletarDentista", Name = "DeletarDentista")]
        public async Task<IActionResult> DeletarDentista(Guid userPublicId)
        {
            RequestUsuarioDentista requestUsuarioDentista = new RequestUsuarioDentista
            {
                PublicID = userPublicId
            };

            UsuarioDentistaService DentistaService = new UsuarioDentistaService();

            DeletarUsuarioDentistaRequestHandler DeletarUsuarioDentistaRequestHandler = new DeletarUsuarioDentistaRequestHandler(DentistaService);

            return await this.HandleRequest(DeletarUsuarioDentistaRequestHandler, requestUsuarioDentista);

        }


    }
}

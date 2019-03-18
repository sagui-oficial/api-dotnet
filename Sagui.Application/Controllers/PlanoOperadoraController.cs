using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Sagui.Application.Infra;
using Sagui.Service.PlanoOperadora;
using Sagui.Service.RequestResponse;
using Sagui.Service.RequestResponse.Handlers;

namespace Sagui.Application.Controllers
{
    [Route("backoffice/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class PlanoOperadoraController : Controller
    {

        
        [HttpGet("ListarPlanoOperadora", Name = "ListarPlanoOperadora")]
        public async Task<IActionResult> GetAsync()
        {
            RequestPlanoOperadora requestPlanoOperadora = default(RequestPlanoOperadora);

            PlanoOperadoraService planoOperadoraService = new PlanoOperadoraService();

            ListarPlanoOperadoraRequestHandler listarPlanoOperadoraRequestHandler = new ListarPlanoOperadoraRequestHandler(planoOperadoraService);
            
            return await this.HandleRequest(listarPlanoOperadoraRequestHandler, requestPlanoOperadora);
            
        }

       
       
        [HttpPost("CriarPlanoOperadora", Name = "CriarPlanoOperadora")]
        public async Task<IActionResult> CriarPlanoOperadora([FromBody]  RequestPlanoOperadora requestPlanoOperadora)
        {
            PlanoOperadoraService PlanoOperadoraService = new PlanoOperadoraService();

            CriarPlanoOperadoraRequestHandler criarPlanoOperadoraRequestHandler = new CriarPlanoOperadoraRequestHandler(PlanoOperadoraService);

            return await this.HandleRequest(criarPlanoOperadoraRequestHandler, requestPlanoOperadora);

        }

        [HttpPost("AtualizarPlanoOperadora", Name = "AtualizarPlanoOperadora")]
        public async Task<IActionResult> AtualizarPlanoOperadora([FromBody]  RequestPlanoOperadora requestPlanoOperadora)
        {
            PlanoOperadoraService PlanoOperadoraService = new PlanoOperadoraService();

            AtualizarPlanoOperadoraRequestHandler criarPlanoOperadoraRequestHandler = new AtualizarPlanoOperadoraRequestHandler(PlanoOperadoraService);

            return await this.HandleRequest(criarPlanoOperadoraRequestHandler, requestPlanoOperadora);

        }

        [HttpPut("{gtopublicid}/DeletarPlanoOperadora", Name = "DeletarPlanoOperadora")]
        public async Task<IActionResult> DeletarPlanoOperadora(Guid gtopublicid)
        {

            RequestPlanoOperadora requestPlanoOperadora = new RequestPlanoOperadora
            {
                PublicID = gtopublicid
            };
            PlanoOperadoraService PlanoOperadoraService = new PlanoOperadoraService();

            AtualizarPlanoOperadoraRequestHandler criarPlanoOperadoraRequestHandler = new AtualizarPlanoOperadoraRequestHandler(PlanoOperadoraService);

            return await this.HandleRequest(criarPlanoOperadoraRequestHandler, requestPlanoOperadora);

        }

    }
}
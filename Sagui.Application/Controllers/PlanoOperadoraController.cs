using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Sagui.Application.Infra;
using Sagui.Service.PlanoOperadora;
using Sagui.Service.Procedimento;
using Sagui.Service.RequestResponse;
using Sagui.Service.RequestResponse.Handlers;

namespace Sagui.Application.Controllers
{
    [Route("backoffice/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class PlanoOperadoraController : Controller
    {


        //GET: api/Procedimento/5
        [HttpGet("{uuid}", Name = "ObterPlanoOperadora")]
        public async Task<IActionResult> ObterGTO(Guid uuid)
        {

            RequestPlanoOperadora requestPlanoOperadora = new RequestPlanoOperadora
            {
                PublicID = uuid
            };

           PlanoOperadoraService planoOperadoraService = new PlanoOperadoraService();
            ProcedimentoService procedimentoService = new ProcedimentoService();

            ObterPlanoOperadoraRequestHandler ObterProcedimentoRequestHandler = new ObterPlanoOperadoraRequestHandler(planoOperadoraService, procedimentoService);

            return await this.HandleRequest(ObterProcedimentoRequestHandler, requestPlanoOperadora);

        }

        [HttpGet("", Name = "ListarPlanoOperadora")]
        public async Task<IActionResult> GetAsync()
        {
            RequestPlanoOperadora requestPlanoOperadora = default(RequestPlanoOperadora);

            PlanoOperadoraService planoOperadoraService = new PlanoOperadoraService();

            ListarPlanoOperadoraRequestHandler listarPlanoOperadoraRequestHandler = new ListarPlanoOperadoraRequestHandler(planoOperadoraService);
            
            return await this.HandleRequest(listarPlanoOperadoraRequestHandler, requestPlanoOperadora);
            
        }

       
       
        [HttpPost("", Name = "CriarPlanoOperadora")]
        public async Task<IActionResult> CriarPlanoOperadora([FromBody]  RequestPlanoOperadora requestPlanoOperadora)
        {
            PlanoOperadoraService PlanoOperadoraService = new PlanoOperadoraService();

            CriarPlanoOperadoraRequestHandler criarPlanoOperadoraRequestHandler = new CriarPlanoOperadoraRequestHandler(PlanoOperadoraService);

            return await this.HandleRequest(criarPlanoOperadoraRequestHandler, requestPlanoOperadora);

        }

        [HttpPatch("", Name = "AtualizarPlanoOperadora")]
        public async Task<IActionResult> AtualizarPlanoOperadora([FromBody]  RequestPlanoOperadora requestPlanoOperadora)
        {
            PlanoOperadoraService PlanoOperadoraService = new PlanoOperadoraService();

            AtualizarPlanoOperadoraRequestHandler atualizarPlanoOperadoraRequestHandler = new AtualizarPlanoOperadoraRequestHandler(PlanoOperadoraService);

            return await this.HandleRequest(atualizarPlanoOperadoraRequestHandler, requestPlanoOperadora);

        }

        [HttpPatch("{uuid}", Name = "DeletarPlanoOperadora")]
        public async Task<IActionResult> DeletarPlanoOperadora(Guid uuid)
        {

            RequestPlanoOperadora requestPlanoOperadora = new RequestPlanoOperadora
            {
                PublicID = uuid
            };
            PlanoOperadoraService PlanoOperadoraService = new PlanoOperadoraService();

            DeletarPlanoOperadoraRequestHandler deletarPlanoOperadoraRequestHandler = new DeletarPlanoOperadoraRequestHandler(PlanoOperadoraService);

            return await this.HandleRequest(deletarPlanoOperadoraRequestHandler, requestPlanoOperadora);

        }

    }
}
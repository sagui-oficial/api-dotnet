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
    public class PacienteController : Controller
    {
        // GET: api/GTO
        [HttpGet("{userPublicId}/ObterPaciente", Name = "ObterPaciente")]
        public async Task<IActionResult> ObterPaciente(Guid userPublicId)
        {

            RequestUsuarioPaciente requestUsuarioPaciente = new RequestUsuarioPaciente
            {
                PublicID = userPublicId
            };

            UsuarioPacienteService pacienteService = new UsuarioPacienteService();

            ObterUsuarioPacienteRequestHandler ObterUsuarioPacienteRequestHandler = new ObterUsuarioPacienteRequestHandler(pacienteService);

            return await this.HandleRequest(ObterUsuarioPacienteRequestHandler, requestUsuarioPaciente);

        }

        [HttpGet("ListarPaciente", Name = "ListarPaciente")]
        public async Task<IActionResult> ListarPaciente()
        {
            RequestUsuarioPaciente requestUsuarioPaciente = default(RequestUsuarioPaciente);

            UsuarioPacienteService pacienteService = new UsuarioPacienteService();

            ListarUsuarioPacienteRequestHandler listarUsuarioPacienteRequestHandler = new ListarUsuarioPacienteRequestHandler(pacienteService);

            return await this.HandleRequest(listarUsuarioPacienteRequestHandler, requestUsuarioPaciente);

        }

        [HttpPost("CriarPaciente", Name = "CriarPaciente")]
        public async Task<IActionResult> CriarPaciente([FromBody]  RequestUsuarioPaciente requestUsuarioPaciente)
        {
            UsuarioPacienteService pacienteService = new UsuarioPacienteService();

            CriarUsuarioPacienteRequestHandler UsuarioPacienteRequestHandler = new CriarUsuarioPacienteRequestHandler(pacienteService);

            return await this.HandleRequest(UsuarioPacienteRequestHandler, requestUsuarioPaciente);

        }

        [HttpPut("AtualizarPaciente", Name = "AtualizarPaciente")]
        public async Task<IActionResult> AtualizarPaciente([FromBody]  RequestUsuarioPaciente requestUsuarioPaciente)
        {
            UsuarioPacienteService pacienteService = new UsuarioPacienteService();

            AtualizarGTORequestHandler GTORequestHandler = new AtualizarGTORequestHandler(gTOService);

            return await this.HandleRequest(GTORequestHandler, requestGTO);

        }

        [HttpPut("{gtopublicid}/DeletarGTO", Name = "DeletarGTO")]
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

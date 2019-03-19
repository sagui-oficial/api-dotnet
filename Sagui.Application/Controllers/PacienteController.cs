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

        [HttpPatch("AtualizarPaciente", Name = "AtualizarPaciente")]
        public async Task<IActionResult> AtualizarPaciente([FromBody]  RequestUsuarioPaciente requestUsuarioPaciente)
        {
            UsuarioPacienteService pacienteService = new UsuarioPacienteService();

            AtualizarUsuarioPacienteRequestHandler AtualizarUsuarioPacienteRequestHandler = new AtualizarUsuarioPacienteRequestHandler(pacienteService);

            return await this.HandleRequest(AtualizarUsuarioPacienteRequestHandler, requestUsuarioPaciente);

        }

        [HttpPatch("{userPublicId}/DeletarPaciente", Name = "DeletarPaciente")]
        public async Task<IActionResult> DeletarPaciente(Guid userPublicId)
        {
            RequestUsuarioPaciente requestUsuarioPaciente = new RequestUsuarioPaciente
            {
                PublicID = userPublicId
            };

            UsuarioPacienteService pacienteService = new UsuarioPacienteService();

            DeletarUsuarioPacienteRequestHandler DeletarUsuarioPacienteRequestHandler = new DeletarUsuarioPacienteRequestHandler(pacienteService);

            return await this.HandleRequest(DeletarUsuarioPacienteRequestHandler, requestUsuarioPaciente);

        }


    }
}

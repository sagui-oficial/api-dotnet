using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sagui.Application.Infra;
using Sagui.Model.ValueObject;
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
        [HttpGet("{uuid}", Name = "ObterPaciente")]
        public async Task<IActionResult> ObterPaciente(Guid uuid)
        {

            RequestUsuarioPaciente requestUsuarioPaciente = new RequestUsuarioPaciente
            {
                PublicID = uuid
            };

            UsuarioPacienteService pacienteService = new UsuarioPacienteService();

            ObterUsuarioPacienteRequestHandler ObterUsuarioPacienteRequestHandler = new ObterUsuarioPacienteRequestHandler(pacienteService);

            return await this.HandleRequest(ObterUsuarioPacienteRequestHandler, requestUsuarioPaciente);

        }

        [HttpGet("", Name = "ListarPaciente")]
        public async Task<IActionResult> ListarPaciente([FromQuery] PagingParameter paging)
        {
            RequestUsuarioPaciente requestUsuarioPaciente = new RequestUsuarioPaciente();

            requestUsuarioPaciente.paging = paging;

            UsuarioPacienteService pacienteService = new UsuarioPacienteService();

            ListarUsuarioPacienteRequestHandler listarUsuarioPacienteRequestHandler = new ListarUsuarioPacienteRequestHandler(pacienteService);

            return await this.HandleRequest(listarUsuarioPacienteRequestHandler, requestUsuarioPaciente);

        }

        [HttpPost("", Name = "CriarPaciente")]
        public async Task<IActionResult> CriarPaciente([FromBody]  RequestUsuarioPaciente requestUsuarioPaciente)
        {
            UsuarioPacienteService pacienteService = new UsuarioPacienteService();

            CriarUsuarioPacienteRequestHandler UsuarioPacienteRequestHandler = new CriarUsuarioPacienteRequestHandler(pacienteService);

            return await this.HandleRequest(UsuarioPacienteRequestHandler, requestUsuarioPaciente);

        }

        [HttpPatch("", Name = "AtualizarPaciente")]
        public async Task<IActionResult> AtualizarPaciente([FromBody]  RequestUsuarioPaciente requestUsuarioPaciente)
        {
            UsuarioPacienteService pacienteService = new UsuarioPacienteService();

            AtualizarUsuarioPacienteRequestHandler AtualizarUsuarioPacienteRequestHandler = new AtualizarUsuarioPacienteRequestHandler(pacienteService);

            return await this.HandleRequest(AtualizarUsuarioPacienteRequestHandler, requestUsuarioPaciente);

        }

        [HttpPatch("{uuid}", Name = "DeletarPaciente")]
        public async Task<IActionResult> DeletarPaciente(Guid uuid)
        {
            RequestUsuarioPaciente requestUsuarioPaciente = new RequestUsuarioPaciente
            {
                PublicID = uuid
            };

            UsuarioPacienteService pacienteService = new UsuarioPacienteService();

            DeletarUsuarioPacienteRequestHandler DeletarUsuarioPacienteRequestHandler = new DeletarUsuarioPacienteRequestHandler(pacienteService);

            return await this.HandleRequest(DeletarUsuarioPacienteRequestHandler, requestUsuarioPaciente);

        }


    }
}

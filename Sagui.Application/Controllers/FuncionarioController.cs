using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Sagui.Application.Infra;
using Sagui.Service.Usuario;
using Sagui.Service.RequestResponse;
using Sagui.Service.RequestResponse.Handlers;

namespace Sagui.Application.Controllers
{
    [Route("backoffice/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class FuncionarioController : Controller
    {
        [HttpGet("", Name = "ListarFuncionario")]
        public async Task<IActionResult> GetAsync()
        {
            RequestUsuarioFuncionario requestUsuaruio = default(RequestUsuarioFuncionario);

            UsuarioFuncionarioService usuarioService = new UsuarioFuncionarioService();

            ListarUsuarioFuncionarioRequestHandler listarProcedimentoRequestHandler = new ListarUsuarioFuncionarioRequestHandler(usuarioService);

            return await this.HandleRequest(listarProcedimentoRequestHandler, requestUsuaruio);

        }


        [HttpGet("{uuid}", Name = "ObterFuncionario")]
        public async Task<IActionResult> ObterUsuarioFuncionario(Guid uuid)
        {

            RequestUsuarioFuncionario requestUsuaruio = new RequestUsuarioFuncionario
            {
                PublicID = uuid
            };

            UsuarioFuncionarioService usuarioService = new UsuarioFuncionarioService();

            ObterUsuarioFuncionarioRequestHandler ObterProcedimentoRequestHandler = new ObterUsuarioFuncionarioRequestHandler(usuarioService);

            return await this.HandleRequest(ObterProcedimentoRequestHandler, requestUsuaruio);

        }

        [HttpPost("", Name = "CriarFuncionario")]
        public async Task<IActionResult> CriarUsuarioFuncionario([FromBody]  RequestUsuarioFuncionario requestUsuario)
        {
            UsuarioFuncionarioService usuarioService = new UsuarioFuncionarioService();

            CriarUsuarioFuncionarioRequestHandler criarUsuarioRequestHandler = new CriarUsuarioFuncionarioRequestHandler(usuarioService);

            return await this.HandleRequest(criarUsuarioRequestHandler, requestUsuario);

        }

        [HttpPatch("", Name = "AtualizarFuncionario")]
        public async Task<IActionResult> AtualizarUsuarioFuncionario([FromBody]   RequestUsuarioFuncionario requestUsuario)
        {
            UsuarioFuncionarioService usuarioService = new UsuarioFuncionarioService();

            AtualizarUsuarioFuncionarioRequestHandler atualizarProcedimentoRequestHandler = new AtualizarUsuarioFuncionarioRequestHandler(usuarioService);

            return await this.HandleRequest(atualizarProcedimentoRequestHandler, requestUsuario);

        }

        [HttpPatch("{uuid}", Name = "DeletarFuncionario")]
        public async Task<IActionResult> DeletarUsuarioFuncionario(Guid uuid)
        [HttpPatch("{uuid}", Name = "DeletarFuncionario")]
        public async Task<IActionResult> DeletarUsuarioFuncionario(Guid uuid)
        {

            RequestUsuarioFuncionario requestUsuaruio = new RequestUsuarioFuncionario
            {
                PublicID = uuid
            };
            UsuarioFuncionarioService usuarioService = new UsuarioFuncionarioService();

            DeletarUsuarioFuncionarioRequestHandler deletarProcedimentoRequestHandler = new DeletarUsuarioFuncionarioRequestHandler(usuarioService);

            return await this.HandleRequest(deletarProcedimentoRequestHandler, requestUsuaruio);

        }

    }
}
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
    public class UsuarioController : Controller
    {
        [HttpGet("ListarUsuario", Name = "ListarUsuario")]
        public async Task<IActionResult> GetAsync()
        {
            RequestUsuarioFuncionario requestUsuaruio = default(RequestUsuarioFuncionario);

            UsuarioFuncionarioService usuarioService = new UsuarioFuncionarioService();

            ListarUsuarioFuncionarioRequestHandler listarProcedimentoRequestHandler = new ListarUsuarioFuncionarioRequestHandler(usuarioService);

            return await this.HandleRequest(listarProcedimentoRequestHandler, requestUsuaruio);

        }

        //GET: api/Procedimento/5
        //[HttpGet("{publicid}/ObterUsuarioFuncionario", Name = "ObterUsuarioFuncionario")]
        //public async Task<IActionResult> ObterUsuarioFuncionario(Guid publicid)
        //{

        //    RequestUsuarioFuncionario requestUsuaruio = new RequestUsuarioFuncionario
        //    {
        //        PublicID = publicid
        //    };

        //    UsuarioFuncionarioService usuarioService = new UsuarioFuncionarioService();

        //    ObterUsuarioFuncionario ObterProcedimentoRequestHandler = new ObterUsuarioFuncionario(usuarioService);

        //      return await this.HandleRequest(ObterProcedimentoRequestHandler, requestUsuaruio);

        //}
               
        //[HttpPost("CriarUsuarioFuncionario", Name = "CriarUsuarioFuncionario")]
        //public async Task<IActionResult> CriarUsuarioFuncionario([FromBody]  RequestProcedimento requestProcedimento)
        //{
        //    ProcedimentoService ProcedimentoService = new ProcedimentoService();

        //    CriarProcedimentoRequestHandler criarProcedimentoRequestHandler = new CriarProcedimentoRequestHandler(ProcedimentoService);

        //    return await this.HandleRequest(criarProcedimentoRequestHandler, requestProcedimento);

        //}

        //[HttpPost("AtualizarUsuarioFuncionario", Name = "AtualizarUsuarioFuncionario")]
        //public async Task<IActionResult> AtualizarUsuarioFuncionario([FromBody]  RequestProcedimento requestProcedimento)
        //{
        //    ProcedimentoService ProcedimentoService = new ProcedimentoService();

        //    AtualizarProcedimentoRequestHandler criarProcedimentoRequestHandler = new AtualizarProcedimentoRequestHandler(ProcedimentoService);

        //    return await this.HandleRequest(criarProcedimentoRequestHandler, requestProcedimento);

        //}

        //[HttpPut("{publicid}/DeletarUsuarioFuncionario", Name = "DeletarUsuarioFuncionario")]
        //public async Task<IActionResult> DeletarUsuarioFuncionario(Guid publicid)
        //{

        //    RequestProcedimento requestProcedimento = new RequestProcedimento
        //    {
        //        PublicID = gtopublicid
        //    };
        //    ProcedimentoService ProcedimentoService = new ProcedimentoService();

        //    AtualizarProcedimentoRequestHandler criarProcedimentoRequestHandler = new AtualizarProcedimentoRequestHandler(ProcedimentoService);

        //    return await this.HandleRequest(criarProcedimentoRequestHandler, requestProcedimento);

        //}

    }
}
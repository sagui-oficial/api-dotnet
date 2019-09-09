using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Sagui.Application.Infra;
using Sagui.Service.Arquivo;
using Sagui.Service.GTO;
using Sagui.Service.Procedimento;
using Sagui.Service.RequestResponse;
using Sagui.Service.RequestResponse.Handlers;

namespace Sagui.Application.Controllers
{
    [Route("backoffice/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class GTOController : Controller
    {
        // GET: api/GTO
        [HttpGet("{uuid}", Name = "ObterGTO")]
        public async Task<IActionResult> ObterGTO(Guid uuid)
        {

            RequestGTO requestGTO = new RequestGTO
            {
                PublicID = uuid
            };

            GTOService gTOService = new GTOService();
            ArquivoService arquivoService = new ArquivoService();
            ProcedimentoService procedimentoService = new ProcedimentoService();

            ObterGTORequestHandler ObterGTORequestHandler = new ObterGTORequestHandler(gTOService, arquivoService, procedimentoService);

            return await this.HandleRequest(ObterGTORequestHandler, requestGTO);

        }

        [HttpGet("", Name = "ListarGTO")]
        public async Task<IActionResult> ListarGTO()
        {
            RequestGTO requestGTO = default(RequestGTO);

            GTOService gTOService = new GTOService();
            ArquivoService arquivoService = new ArquivoService();
            ProcedimentoService procedimentoService = new ProcedimentoService();

            ListarGTORequestHandler listarGTORequestHandler = new ListarGTORequestHandler(gTOService, arquivoService, procedimentoService);

            return await this.HandleRequest(listarGTORequestHandler, requestGTO);

        }

        [HttpGet("{uuid}/ListarGTOOperadora", Name = "ListarGTOOperadora")]
        public async Task<IActionResult> ListarGTOOperadora(Guid uuid)
        {
            RequestPlanoOperadora requestGTO = new RequestPlanoOperadora
            {
                PublicID = uuid
            };


            GTOService gTOService = new GTOService();
         

            ListarGTO_PlanoOperadoraRequestHandler listarGTORequestHandler = new ListarGTO_PlanoOperadoraRequestHandler(gTOService);

            return await this.HandleRequest(listarGTORequestHandler, requestGTO);

        }

        [HttpPost("", Name = "CriarGTO")]
        public async Task<IActionResult> CriarGTO([FromBody]  RequestGTO requestGTO)
        {
            GTOService gTOService = new GTOService();

            CriarGTORequestHandler GTORequestHandler = new CriarGTORequestHandler(gTOService);

            return await this.HandleRequest(GTORequestHandler, requestGTO);

        }

        [HttpPatch("", Name = "AtualizarGTO")]
        public async Task<IActionResult> AtualizarGTO([FromBody]  RequestGTO requestGTO)
        {
            GTOService gTOService = new GTOService();
                        
            AtualizarGTORequestHandler GTORequestHandler = new AtualizarGTORequestHandler(gTOService);

            return await this.HandleRequest(GTORequestHandler, requestGTO);

        }

        [HttpPatch("{uuid}", Name = "DeletarGTO")]
        public async Task<IActionResult> DeletarGTO(Guid uuid)
        {
            RequestGTO requestGTO = new RequestGTO
            {
                PublicID = uuid
            };
            GTOService gTOService = new GTOService();

            DeletarGTORequestHandler GTORequestHandler = new DeletarGTORequestHandler(gTOService);

            return await this.HandleRequest(GTORequestHandler, requestGTO);

        }

        [HttpPost("UploadFiles")]
        public async Task<IActionResult> UploadFiles()
        {
            var files = Request.Form.Files;
            long size = files.Sum(f => f.Length);

            // full path to file in temp location
            var filePath = Path.GetTempFileName();

            foreach (var formFile in files)
            {
                if (formFile.Length > 0)
                {
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await formFile.CopyToAsync(stream);
                    }
                }
            }

            // process uploaded files
            // Don't rely on or trust the FileName property without validation.

            return Ok(new { count = files.Count, size, filePath });
        }




    }
}

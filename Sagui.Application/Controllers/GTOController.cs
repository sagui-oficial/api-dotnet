using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sagui.Service.Contracts;
using Sagui.Service.GTO;
using Sagui.Service.RequestResponse;
using Sagui.Service.RequestResponse.Handlers;

namespace Sagui.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GTOController : ControllerBase
    {
        // GET: api/GTO
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "AAA", "QQQ" };
        }

        // GET: api/GTO/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/GTO
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        [HttpPost]
        public void Post([FromBody]  RequestGTO requestGTO)
        {
            GTOService gTOService = new GTOService();

            CriarGTORequestHandler criarGTORequestHandler = new CriarGTORequestHandler(gTOService);

            var response = criarGTORequestHandler.Cadastrar(requestGTO);
        }

        // PUT: api/GTO/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

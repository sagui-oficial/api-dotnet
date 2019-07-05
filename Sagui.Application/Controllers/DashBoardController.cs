using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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
    public class DashBoardController : Controller
    {
        
       
        [HttpGet("{Inicio}/{Fim}", Name = "Dashboard")]
        public JObject Dashboard(DateTime Inicio , DateTime Fim)
        {

            string fakeReturn = @"{
                faturamento: 10000.00,
	            guiasGlosadas: 500.00,
	            planosCadastrados: 6,
	            grafico: [
                        { operadora: ""Dental Par"", total: 8260.9, glosadas: 490.8},
                        { operadora: ""Prodent"", total: 6900.67, glosadas: 898.56},
                        { operadora: ""Uniodonto"", total: 9104.55, glosadas: 90.89},
                        { operadora: ""Unimed"", total: 3409.77, glosadas: 129.84},
                        { operadora: ""Prevident"", total: 908.51, glosadas: 10.7},
                        { operadora: ""Interodonto"", total: 4560.09, glosadas: 200.98},
                        { operadora: ""SulAmérica"", total: 2090.88, glosadas: 348.21},
                        { operadora: ""Metlife"", total: 1130.9, glosadas: 330.98}
	            ]
            }";
            JObject o = JObject.Parse(fakeReturn);



            return o;
         //   return json;
        }


    }
}
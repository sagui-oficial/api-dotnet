using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Sagui.Application.Infra;
using Sagui.Model.ViewModel;
using Sagui.Service.Dashboard;
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
        public async Task<IActionResult> Dashboard(DateTime Inicio , DateTime Fim)
        {

            DashboardService dashboardService = new DashboardService();

            ObterDashboardRequestHandler obterDashboardRequestHandler = new ObterDashboardRequestHandler(dashboardService);

            RequestDashboard requestDashboard = new RequestDashboard();
            requestDashboard.Inicio = Inicio;
            requestDashboard.Fim = Fim;

            return await this.HandleRequest(obterDashboardRequestHandler, requestDashboard);

                     
        }


    }
}
using Sagui.Base.Utils;
using Sagui.Service.Arquivo;
using Sagui.Service.Dashboard;
using Sagui.Service.GTO;
using Sagui.Service.Procedimento;
using Sagui.Service.RequestResponse.Base;
using Sagui.Service.RequestResponse.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sagui.Service.RequestResponse.Handlers
{
    public class ObterDashboardRequestHandler : IBaseRequestHandler<RequestDashboard, ResponseDashboard>
    {
        DashboardService DashboardService;
        

        private Business.Validador.GTO.ValidadorGTO validadorGTO { get; set; }

        ResponseDashboard responseDashboard;

        public ObterDashboardRequestHandler(DashboardService _GTOService)
        {
            DashboardService = _GTOService;
            responseDashboard = new ResponseDashboard();
        }

        public async Task<ResponseDashboard> Handle(RequestDashboard request)
        {
            var dashboard = DashboardService.Obter();
                       
         

            if (dashboard != null)
            {
                responseDashboard.Dashboard = dashboard;
                responseDashboard.ExecutionDate = DateTime.Now;
                responseDashboard.ResponseType = ResponseType.Success;

                responseDashboard.Message.Add(new Tuple<dynamic, dynamic, dynamic>(Constantes.ObterComSucesso, nameof(responseDashboard.Dashboard),
                 String.Format(Constantes.MensagemObtidacomSucesso, nameof(responseDashboard.Dashboard))));

                return responseDashboard;
            }
            else
            {
                responseDashboard.Dashboard = dashboard;
                responseDashboard.ExecutionDate = DateTime.Now;
                responseDashboard.ResponseType = ResponseType.Info;


                responseDashboard.Message.Add(new Tuple<dynamic, dynamic, dynamic>(Constantes.ProblemaAoObter, nameof(responseDashboard.Dashboard),
                    String.Format(Constantes.MensagemNaoObtidacomSucesso, nameof(responseDashboard.Dashboard))));

                return responseDashboard;
            }
        }
    }
}

using Microsoft.VisualStudio.TestTools.UnitTesting;

using Sagui.Service.Dashboard;

using Sagui.Service.RequestResponse;
using Sagui.Service.RequestResponse.Handlers;
using Sagui.Service.RequestResponse.ValueObject;
using System.Threading.Tasks;

namespace Sagui.Test.TestGTO
{
    [TestClass]
    public class Dashboard_Test
    {
        [TestMethod]
        public async Task Obter()
        {
            DashboardService dashboardService = new DashboardService();

            ObterDashboardRequestHandler obterDashboardRequestHandler = new ObterDashboardRequestHandler(dashboardService);

            RequestDashboard requestDashboard = default(RequestDashboard);

            var response = await obterDashboardRequestHandler.Handle(requestDashboard);

            Assert.IsTrue(response.ResponseType == ResponseType.Success);
            Assert.IsTrue(response.Dashboard != null);
        }



    }
}

using Sagui.Service.RequestResponse.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sagui.Service.RequestResponse
{
    public class ResponseDashboard : ResponseBase
    {
        public Model.ViewModel.Dashboard Dashboard { get; set; }
        
    }
}

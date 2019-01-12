using Microsoft.AspNetCore.Mvc;
using Sagui.Service.RequestResponse.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Sagui.Application.Infra
{
    internal static class ControllerExtensions
    {
        internal static async Task<IActionResult> HandleRequest(this Controller controller, dynamic requestHandler, dynamic requestValue)
        {
            var response = requestHandler.Handle(requestValue);

            return APIResultHelper.ApiResult(controller.Request, HttpStatusCode.OK, response);
        }
    }
}

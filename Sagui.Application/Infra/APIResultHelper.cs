using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Sagui.Application.Infra
{
    public static class APIResultHelper
    {
        static readonly JsonSerializerSettings customSerializerSettings = null;

        static APIResultHelper()
        {
            customSerializerSettings = new JsonSerializerSettings()
            {
                NullValueHandling = NullValueHandling.Ignore,
                DefaultValueHandling = DefaultValueHandling.Ignore,
                Formatting = Formatting.Indented,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            };
        }

        public static IActionResult ApiResult(HttpRequest request, HttpStatusCode statusCode, object content)
        {
            var supportedResponseTypes = new string[] { "json", "xml" };
            var responseType = "json";

            string requestedContentType = request.Query["type"];

            if (!string.IsNullOrEmpty(requestedContentType) && supportedResponseTypes.Contains(requestedContentType, StringComparer.OrdinalIgnoreCase))
            {
                responseType = requestedContentType;
            }

            if (responseType.Equals("json"))
            {
                var result = new JsonResult(content, customSerializerSettings)
                {
                    StatusCode = (int)statusCode
                };

                return result;
            }
            else
                throw new NotSupportedException("output format not supported");
        }
    }
}

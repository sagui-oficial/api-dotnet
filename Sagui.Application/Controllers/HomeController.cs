using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;

namespace Sagui.Application.Controllers
{
    public class HomeController : Controller
    {
        static readonly string logoContent = null;

        static HomeController() => logoContent = LoadLogo();

        private readonly IApiDescriptionGroupCollectionProvider _apiExplorer;

        public HomeController(IApiDescriptionGroupCollectionProvider apiExplorer)
        {
            _apiExplorer = apiExplorer;
        }

        static string LoadLogo()
        {
            //var logo = System.IO.File.ReadAllText(@"wwwroot\logo.txt");

            //var subHeading = $"Welcome friend - SAGUI at your service";

            //var sb = new StringBuilder(logo);

            //sb.AppendLine();
            //sb.AppendLine();

            //sb.Append(subHeading);

            //return sb.ToString();
            return "";
        }

        [AllowAnonymous]
        public IActionResult Index()
        {
            return Content(logoContent);
        }

        [AllowAnonymous]
        public string Version()
        {
            return $"Version {typeof(HomeController).GetTypeInfo().Assembly.GetName().Version.ToString()}";
        }
    }
}
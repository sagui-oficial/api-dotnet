using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;

namespace Sagui.Application.Controllers
{
    public class LogInController : Controller
    {
        // GET: Cliente
        public ActionResult Index()
        {
            return View();
        }

        public Action Login()
        {
            return null;
        }
    }
}
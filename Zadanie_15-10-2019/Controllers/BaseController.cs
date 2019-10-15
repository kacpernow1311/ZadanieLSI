using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Zadanie_15_10_2019.Controllers
{
    public class BaseController : Controller
    {
        public string ControllerName => ControllerContext.RouteData.Values["controller"] as string;
    }
}
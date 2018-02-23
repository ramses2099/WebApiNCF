using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Mvc;

namespace WebApiNCF.Controllers
{
    [ApiExplorerSettings(IgnoreApi = true)]
    public class UiController : Controller
    {
        
        public ActionResult Index()
        {
            ViewBag.Title = "UI Windows";

            return View();
        }


    }
}

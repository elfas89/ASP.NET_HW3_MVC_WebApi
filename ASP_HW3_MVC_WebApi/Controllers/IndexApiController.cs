using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASP_HW3_MVC_WebApi.Controllers
{
    public class IndexApiController : Controller
    {
        // GET: Api
        public ActionResult IndexApi()
        {
            return View();
        }
    }
}
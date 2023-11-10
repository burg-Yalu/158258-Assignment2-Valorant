using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication4.Controllers
{
    public class ValorantHomeController : Controller
    {
        // GET: ValorantHome
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Agent()
        {
            return View();
        }

    }
}
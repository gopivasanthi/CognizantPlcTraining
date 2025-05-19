using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CognizantPlc.Feature.Navigation.Controllers
{
    public class CtsNavigationController : Controller
    {
        // GET: CtsNavigation
        public ActionResult Header()
        {
            return View();
        }
    }
}
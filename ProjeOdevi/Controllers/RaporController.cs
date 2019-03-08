using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjeOdevi.Controllers
{
    [Authorize(Roles = "Admin,SatisYetkilisi")]
    public class RaporController : Controller
    {
        // GET: Rapor
        public ActionResult SatinAlRapor()
        {
            return View();
        }

        public ActionResult ZimmetRapor()
        {
            return View();
        }
    }
}
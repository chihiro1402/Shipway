using Shipway.Authorize;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Shipway.Controllers
{
    [ShipwayAuthorize]
    public class LumpExhibitionController : Controller
    {
        // GET: LumpExhibition
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult LumpExhibition(int numberShipper, DateTime dateSender)
        {

            return View();
        }
    }
}
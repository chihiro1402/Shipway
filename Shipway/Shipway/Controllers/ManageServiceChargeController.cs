using Shipway.Authorize;
using ShipwayBusiness.CoreProvider;
using ShipwayBusiness.DataAccessLayer;
using ShipwayBusiness.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Shipway.Controllers
{
    [ShipwayAuthorize]
    public class ManageServiceChargeController : Controller
    {
        private IServiceChargeProvider serviceChargeProvider;
        private IRouterProvider routerProvider;
        private IKindServiceProvider kindServiceProvider;
        private IKindTimeReceivedProvider kindTimeReceivedProvider;

        public ManageServiceChargeController()
        {
            serviceChargeProvider = new ServiceChargeProvider();
            routerProvider = new RouterProvider();
            kindServiceProvider = new KindServiceProvider();
            kindTimeReceivedProvider = new KindTimeReceivedProvider();
        }
        // GET: ManageServiceCharge
        public ActionResult Index()
        {
            ViewBag.ListRouter = routerProvider.GetAllRouter();
            ViewBag.ListKindService = kindServiceProvider.GetAllKindService();
            ViewBag.ListKindTimeReceived = kindTimeReceivedProvider.GetAllKindTimeReceived();
            ViewBag.ListServiceCharge = serviceChargeProvider.QueryAllServiceChargeView();
            return View();
        }

        [HttpPost]
        public ActionResult SaveServiceCharge(ServiceCharge serviceCharge)
        {
            if (ModelState.IsValid)
            {
                serviceChargeProvider.InsertServiceCharge(serviceCharge);
                return RedirectToAction("Index", "ManageServiceCharge");
            }
            else
            {
                var errors = ModelState.Select(x => x.Value.Errors)
                           .Where(y => y.Count > 0)
                           .ToList();
            }
            return RedirectToAction("Index", "ManageServiceCharge");
        }

        public ActionResult EditServiceCharge(int id)
        {
            var serviceCharge = serviceChargeProvider.GetServiceChargeById(id);
            ViewBag.ListRouter = routerProvider.GetAllRouter();
            ViewBag.ListKindService = kindServiceProvider.GetAllKindService();
            ViewBag.ListKindTimeReceived = kindTimeReceivedProvider.GetAllKindTimeReceived();
            return PartialView("_EditServiceCharge", serviceCharge);
        }

        [HttpPost]
        public ActionResult EditServiceCharge(ServiceCharge serviceCharge)
        {
            if (ModelState.IsValid)
            {
                var service = serviceChargeProvider.UpdateServiceCharge(serviceCharge);
                return RedirectToAction("Index", "ManageServiceCharge");
            }
            return RedirectToAction("Index", "ManageServiceCharge");
        }

        public ActionResult DeleteServiceCharge(int id)
        {
            var serviceCharge = serviceChargeProvider.GetServiceChargeById(id);
            return PartialView("_DeleteServiceCharge", serviceCharge);
        }

        [HttpPost]
        public ActionResult DeleteServiceCharge(ServiceCharge serviceCharge)
        {
            serviceCharge = serviceChargeProvider.GetServiceChargeById(serviceCharge.ServiceChargeId);
            var success = serviceChargeProvider.DeleteServiceCharge(serviceCharge);
            if (success)
            {
                TempData["Success"] = "Xóa thành công biểu phí";
            }
            else
            {
                TempData["Success"] = "Xóa biểu phí thất bại";
            }
            return RedirectToAction("Index", "ManageServiceCharge");
        }
    }
}
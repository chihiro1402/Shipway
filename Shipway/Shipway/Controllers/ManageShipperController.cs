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
    public class ManageShipperController : Controller
    {
        private IShipperProvider _shipperProvider;
        private IAgencyProvider _agencyProvider;

        public ManageShipperController()
        {
            _shipperProvider = new ShipperProvider();
            _agencyProvider = new AgencyProvider();
        }

        // GET: ManageShipper
        public ActionResult Index()
        {
            ViewBag.Agency = new SelectList( _agencyProvider.GetAllAgency(), "AgencyId","AgencyName");
            ViewBag.ListShipper = _shipperProvider.GetAllShipper();
            return View();
        }

        [HttpPost]
        public ActionResult SaveShipper(Shipper shipper)
        {
            if (ModelState.IsValid)
            {
                shipper.Password = ShipwayBusiness.Helper.Utils.MD5(shipper.Password);
                _shipperProvider.InsertShipper(shipper);
                return RedirectToAction("Index", "ManageShipper");
            }
            return RedirectToAction("Index", "ManageShipper");
        }

        public ActionResult EditShipper(int id)
        {
            var shipper = _shipperProvider.GetShipperById(id);
            ViewBag.Agency = new SelectList(_agencyProvider.GetAllAgency(), "AgencyId", "AgencyName");
            return PartialView("_EditShipper", shipper);
        }

        [HttpPost]
        public ActionResult EditShipper(Shipper shipper)
        {
            if (ModelState.IsValid)
            {
                shipper.Password = ShipwayBusiness.Helper.Utils.MD5(shipper.Password);
                shipper = _shipperProvider.UpdateShipper(shipper);
                return RedirectToAction("Index", "ManageShipper");
            }
            return RedirectToAction("Index", "ManageShipper");
        }

        public ActionResult DeleteShipper(int id)
        {
            var shipper = _shipperProvider.GetShipperById(id);
            return PartialView("_DeleteShipper", shipper);
        }

        [HttpPost]
        public ActionResult DeleteShipper(Shipper shipper)
        {
            bool success = _shipperProvider.DeleteShipper(shipper);

            if (success)
            {
                TempData["Success"] = "Xóa ngườigiao hàng thành công";
                return RedirectToAction("Index", "ManageShipper");
            }
            else
            {
                TempData["Success"] = "Xóa người giao hàng thất bại";
                return RedirectToAction("Index", "ManageShipper");
            }
        }
    }
}
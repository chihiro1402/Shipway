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
    public class ManageAgencyController : Controller
    {
        private IAgencyProvider _agencyProvider;
        public ManageAgencyController()
        {
            _agencyProvider = new AgencyProvider();
        }

        // GET: ManageAgency
        public ActionResult Index()
        {
            ViewBag.ListAgency = _agencyProvider.GetAllAgency();
            return View();
        }

        [HttpPost]
        public ActionResult SaveAgency(Agency agency)
        {
            if (ModelState.IsValid)
            {
                _agencyProvider.InsertAgency(agency);
                return RedirectToAction("Index", "ManageAgency");
            }
            return View("Index", agency);
        }

        public ActionResult DeleteAgency(int id)
        {
            var agency = _agencyProvider.GetAgencyById(id);
            return PartialView("_DeleteAgency", agency);
        }

        [HttpPost]
        public ActionResult DeleteAgency( Agency agency)
        {
            var existAgency = _agencyProvider.GetAgencyById(agency.AgencyId);
            bool success = _agencyProvider.DeleteAgency(existAgency);
            if (success)
            {
                TempData["Success"] = "Xóa thành công đại lý";
                return RedirectToAction("Index", "ManageAgency");
            }
            else
            {
                TempData["Success"] = "Xóa thất bại đại lý";
                return RedirectToAction("Index", "ManageAgency");
            }
        }

        public ActionResult EditAgency(int id)
        {
            var agency = _agencyProvider.GetAgencyById(id);
            return PartialView("_EditAgency", agency);
        }

        [HttpPost]
        public ActionResult EditAgency(Agency agency)
        {
            if (ModelState.IsValid)
            {
                agency = _agencyProvider.UpdateAgency(agency);
                return RedirectToAction("Index", "ManageAgency");
            }
            return RedirectToAction("Index", "ManageAgency");
        }
    }
}
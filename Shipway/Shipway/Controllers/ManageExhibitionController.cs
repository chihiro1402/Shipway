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
    public class ManageExhibitionController : Controller
    {
        private IExhibitionProvider exhibitionProvider;
        private IExhibitionStatusProvider exhibitionStatusProvider;
        private INoteRequiredProvider noteRequiredProvider;
        private IKindServiceProvider kindServiceProvider;

        public ManageExhibitionController()
        {
            exhibitionProvider = new ExhibitionProvider();
            exhibitionStatusProvider = new ExhibitionStatusProvider();
            noteRequiredProvider = new NoteRequiredProvider();
            kindServiceProvider = new KindServiceProvider();
        }
        // GET: ManageExhibition
        public ActionResult Index()
        {
            ViewBag.ListNoteRequired = noteRequiredProvider.GetAllNoteRequired();
            ViewBag.ListKindService = kindServiceProvider.GetAllKindService();
            ViewBag.ExhibitionStatus = exhibitionStatusProvider.GetAllExhibitionStatus();
            ViewBag.ListExhibition = exhibitionProvider.GetAllExhibitionViewModel();

            return View();
        }

        [HttpPost]
        public ActionResult SearchExhibition(Exhibition exhibition)
        {
            ViewBag.ListNoteRequired = noteRequiredProvider.GetAllNoteRequired();
            ViewBag.ListKindService = kindServiceProvider.GetAllKindService();
            ViewBag.ExhibitionStatus = exhibitionStatusProvider.GetAllExhibitionStatus();
            ViewBag.ListExhibition = exhibitionProvider.SearchExhibitionByStatus(exhibition.ExhibitionStatusId);
            return View("Index");
        }

        public ActionResult EditExhibiton(string id)
        {
            var exhibition = exhibitionProvider.GetExhibitionById(id);
            ViewBag.ListNoteRequired = noteRequiredProvider.GetAllNoteRequired();
            ViewBag.ListKindService = kindServiceProvider.GetAllKindService();
            return View(exhibition);
        }

        [HttpPost]
        public ActionResult EditExhibition(Exhibition exhibition)
        {
            if (ModelState.IsValid)
            {
                exhibition.LasrModifiedUserId = ((User)Session["CurrentUser"]).Id;
                exhibition.LastModifiedDate = DateTime.Now;
                var exhibitionNew = exhibitionProvider.UpdateExhibition(exhibition);
            }

            return RedirectToAction("Index", "ManageExhibition");
        }
    }
}
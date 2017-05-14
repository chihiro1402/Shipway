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
    
    public class Permission
    {
        public int PermissionId { get; set; }
        public string Name { get; set; }
    }

    [ShipwayAuthorize]
    public class SuperAdminController : Controller
    {
        // GET: SuperAdmin
        private readonly IUserProvider _userProvider;
        private IAgencyProvider _agencyProvider;
        private List<Permission> listPermission = new List<Permission>
            {
                new Permission() {PermissionId= 1, Name="SuperAdmin"},
                new Permission (){PermissionId=2, Name="Admin" },
                new Permission() {PermissionId=3, Name="Khách hàng" }
            };

        public SuperAdminController()
        {
            _userProvider = new UserProvider();
            _agencyProvider = new AgencyProvider();
        }

        public ActionResult Index()
        {
            ViewBag.ListAgency = _agencyProvider.GetAllAgency();
            ViewBag.Permission = listPermission;
            var listAccount = _userProvider.GetAllUser();
            ViewBag.ListAccount = listAccount;
            return View();
        }

        [HttpPost]
        public ActionResult SaveAccount(UserViewModel userViewModel)
        {
            if (ModelState.IsValid)
            {
                var user = userViewModel.User;
                if (userViewModel.PermissionId == 1)
                {
                    user.IsSuperAdmin = true;
                }
                else if (userViewModel.PermissionId == 2)
                {
                    user.IsAdmin = true;
                }
                else
                {
                    user.IsCustomer = true;
                }

                user.Password = ShipwayBusiness.Helper.Utils.MD5(userViewModel.User.Password);

                _userProvider.InsertUser(user);
                return RedirectToAction("Index");
            }
            else
            {
                var errors = ModelState.Select(x => x.Value.Errors)
                           .Where(y => y.Count > 0)
                           .ToList();
            }
            return View("Index", userViewModel);
        }

        [HttpGet]
        public ActionResult EditAccount(int id)
        {
            var account = _userProvider.GetUserById(id);
            var userViewModel = new UserViewModel();
            if (account != null)
            {
                userViewModel.User = account;
                userViewModel.PermissionId = account.IsSuperAdmin == true ? 1 : account.IsAdmin == true ? 2 : 3;
            }
            ViewBag.Permission = listPermission;

            return PartialView("_editAccount", userViewModel);
        }

        [HttpPost]
        public ActionResult EditAccount(UserViewModel userViewModel)
        {
            var user = userViewModel.User;
            if (ModelState.IsValid)
            {
                if (userViewModel.PermissionId == 1)
                {
                    user.IsSuperAdmin = true;
                }else if (userViewModel.PermissionId == 2)
                {
                    user.IsAdmin = true;
                }
                else
                {
                    user.IsCustomer = true;
                }
                user.Password = ShipwayBusiness.Helper.Utils.MD5(userViewModel.User.Password);

                user = _userProvider.UpdateUser(user);

                return RedirectToAction("Index", "SuperAdmin");
            }
            return View("Index",userViewModel);
        }

        [HttpGet]
        public ActionResult DeleteAccount(int id)
        {
            var account = _userProvider.GetUserById(id);
            return PartialView("_DeleteAccount",account);
        }

        [HttpPost]
        public ActionResult DeleteAccount(User user)
        {
            var account = _userProvider.GetUserById(user.Id);
            bool success = _userProvider.Delete(account);
            if (success)
            {
                TempData["Success"] = "Delete account success!";
                return RedirectToAction("Index", "SuperAdmin");
            }
            else
            {
                TempData["Success"] = "Delete account failed!";
                return RedirectToAction("Index", "SuperAdmin");
            }
        }


        //Customer
        public ActionResult ManageCustomer()
        {
            var listCustomer = _userProvider.GetListCutomer();
            ViewBag.ListCustomer = listCustomer;
            return View();
        }

        [HttpPost]
        public ActionResult SaveCustomer(User user)
        {
            if (ModelState.IsValid)
            {
                user.IsCustomer = true;
                _userProvider.InsertUser(user);
                return RedirectToAction("ManageCustomer", "SuperAdmin");
            }
            return RedirectToAction("ManageCustomer", "SuperAdmin");
        }

        public ActionResult EditCustomer(int id)
        {
            var customer = _userProvider.GetUserById(id);
            return PartialView("_EditCustomer", customer);
        }

        [HttpPost]
        public ActionResult EditCustomer( User user)
        {
            if (ModelState.IsValid)
            {
                user.IsCustomer = true;
                user = _userProvider.UpdateUser(user);
                return RedirectToAction("ManageCustomer", "SuperAdmin");
            }
            return RedirectToAction("ManageCustomer", "SuperAdmin");
        }

        public ActionResult DeleteCustomer(int id)
        {
            var customer = _userProvider.GetUserById(id);
            return PartialView("_DeleteCustomer", customer);
        }

        [HttpPost]
        public ActionResult DeleteCustomer( User user)
        {
            bool success = _userProvider.Delete(user);
            if (success)
            {
                TempData["Success"] = "Xóa khách hàng thành công";
                return RedirectToAction("ManageCustomer", "SuperAdmin");
            }
            else
            {
                TempData["Success"] = "Xóa khách hàng thất bại";
                return RedirectToAction("ManageCustomer", "SuperAdmin");
            }
        }
    }
}
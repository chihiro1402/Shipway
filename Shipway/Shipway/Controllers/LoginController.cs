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
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            User user = new User();
            return View(user);
        }

        [HttpPost]
        public ActionResult Login(User user)
        {
            IUserProvider userProvider = new UserProvider();
            if (ModelState.IsValid)
            {
                var passwordHash = ShipwayBusiness.Helper.Utils.MD5(user.Password);

                User usernameExist = null;
                var existUser = userProvider.Login(user.UserName, passwordHash, out usernameExist);
                if (existUser != null)
                {
                    Session["CurrentUser"] = existUser;
                    if (existUser.IsSuperAdmin)
                    {
                        return RedirectToAction("Index", "SuperAdmin");
                    }
                    if (existUser.IsAdmin == true)
                    {
                        return RedirectToAction("ManageCustomer", "SuperAdmin");
                    }
                    if (existUser.IsCustomer == true)
                    {
                        return RedirectToAction("Index", "ExhibitionCustomer");
                    }
                }
                else if (usernameExist!= null && usernameExist.Id > 0)
                {
                    ViewBag.Invalid = true;
                    TempData["ErrorMessage"] = "Mật khẩu không đúng";
                    return View("Index");
                }
                else
                {
                    ViewBag.Invalid = true;
                    TempData["ErrorMessage"] = "Tên đăng nhập không tồn tại";
                    return View("Index");
                }
            }
            
            return View("Index");
        }

        public ActionResult Logout()
        {
            Session.Clear();
            Session.RemoveAll();
            return RedirectToAction("Index");
        }
    }
}
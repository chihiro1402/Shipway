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
    public class SignUpController : Controller
    {
        private IUserProvider userProvider;
        public SignUpController()
        {
            userProvider = new UserProvider();
        }
        // GET: SignUp
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(User user)
        {
            if (ModelState.IsValid)
            {
                var existUser = userProvider.GetUserByUsername(user.UserName);
                if (existUser != null)
                {
                    @TempData["ErrorMsg"] = "Tên đăng nhập đã tồn tại";
                    return View();
                }
                user.IsCustomer = true;
                user.IsAdmin = false;
                user.IsSuperAdmin = false;
                user.Password = ShipwayBusiness.Helper.Utils.MD5(user.Password);
                userProvider.InsertUser(user);
                return RedirectToAction("Index", "ExhibitionCustomer");
            }
            else
            {
                return View();
            }
        }
    }
}
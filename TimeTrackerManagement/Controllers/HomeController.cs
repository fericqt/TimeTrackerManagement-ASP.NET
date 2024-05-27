using FerPROJ.Design.Class;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TimeTrackerManagement.EntityData;
using TimeTrackerManagementDTO;

namespace TimeTrackerManagement.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SaveData(UserDTO user, HttpPostedFileBase profile) {
            using (var MyData = new UserAccountData()) {
                user.ProfileImg = profile.ToByte();
                MyData.SaveDTO(user, false, true);
                return ShowModal("Index", "Home", "Account Created Successfully! You can now login with your credentials!");
            }
        }
        [HttpPost]
        public ActionResult VerifyLogin(UserDTO user) {
            using (var MyData = new UserAccountData()) {
                var tbl = MyData.GetUser(user);
                if (tbl != null) {
                    TempData["Username"] = tbl.Username;
                    TempData["ProfileImg"] = tbl.ProfileImg.ToImage();
                    return RedirectToAction("Index", "Dashboard"); 
                }
                return ShowModal("Index", "Home", "Incorrect username or password!");
            }
        }
        public ActionResult Logout() {
            return ShowModal("Index", "Home", "Thank you for using the app!");
        }
        public ActionResult ShowModal(string actionName, string controllerName, string msg) {
            ViewBag.ActionName = actionName;
            ViewBag.ControllerName = controllerName;
            ViewBag.Messages = msg;
            return View("~/Views/Includes/ModalAlert.cshtml");
        }
    }
}
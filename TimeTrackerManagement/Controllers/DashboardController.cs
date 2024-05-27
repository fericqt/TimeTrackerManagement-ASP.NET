using FerPROJ.Design.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TimeTrackerManagement.Entity;
using TimeTrackerManagement.EntityData;
using TimeTrackerManagementDTO;

namespace TimeTrackerManagement.Controllers
{
    public class DashboardController : Controller
    {
        // GET: Dashboard
        [HttpGet]
        public ActionResult Index()
        {
            using (var myData = new UserAccountData()) {
                var myDTO = new CMappingList<tbluser, UserDTO>().GetMappingResultList(myData.GetAll());
                var myDTOConverted = myDTO.Select(c => new UserDTO {
                    IdTrack = c.IdTrack,
                    Username = c.Username,
                    Password = c.Password,
                    Email = c.Email,
                    ProfileImgBase64 = c.ProfileImg.ToImage(),
                }).ToList();


                return View(myDTOConverted);
            }
        }
        [HttpPost]
        public ActionResult DeleteData(int id) {
            using (var myData = new UserAccountData()) {
                myData.Delete(id, true);
                return ShowModal("Index", "Dashboard", "User has been deleted successfully!");
            }
        }
        [HttpPost]
        public ActionResult GetData(int id) {
            using (var myData = new UserAccountData()) {
                var tbl = new CMapping<tbluser, UserDTO>().GetMappingResult(myData.GetById(id));
                var myDTOConverted = new UserDTO {
                    IdTrack = tbl.IdTrack,
                    Username= tbl.Username,
                    Password = tbl.Password,
                    Email = tbl.Email,
                    ProfileImg = tbl.ProfileImg,
                    ProfileImgBase64= tbl.ProfileImg.ToImage(),
                };
                return ShowModal("Index", "Dashboard", myDTOConverted);
            }
        }
        [HttpPost]
        public ActionResult UpdateData(UserDTO user) {
            using (var myData = new UserAccountData()) {
                myData.UpdateDTO(user, false, true);
                return ShowModal("Index", "Dashboard", "User data has been updated successfully!");
            }
        }

        public ActionResult ShowModal(string actionName, string controllerName, string msg) {
            ViewBag.ActionName = actionName;
            ViewBag.ControllerName = controllerName;
            ViewBag.Messages = msg;
            return View("~/Views/Includes/ModalAlert.cshtml");
        }
        public ActionResult ShowModal(string actionName, string controllerName, UserDTO user) {           
            ViewBag.ActionName = actionName;
            ViewBag.ControllerName = controllerName;
            return View("~/Views/Includes/ModalUserUpdate.cshtml", user);
        }



    }
}
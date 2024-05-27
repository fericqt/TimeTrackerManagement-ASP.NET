using FerPROJ.Design.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TimeTrackerManagement.Entity;
using TimeTrackerManagement.EntityData;
using TimeTrackerManagementDB;
using TimeTrackerManagementDTO;

namespace TimeTrackerManagement.Controllers
{
    public class TimeController : Controller
    {
        // GET: Time
        public ActionResult Index()
        {
            using (var myData = new UserTimeData()) {
                var myDTO = new CMappingList<tbltime, TimeDTO>().GetMappingResultList(myData.GetAll(GetUser().Username));
                var totalCount = myData.GetAll(GetUser().Username).Count();
                var totalPresent = myData.GetAll(GetUser().Username).Count(c => c.Status == "Successfully Time Out");
                var myModel = new TimeViewModel {
                    TimeList = myDTO,
                    TimeCount = new UserTimeCountDTO {
                        DayAbsentCount = totalCount - totalPresent,
                        DayPresentCount = totalPresent
                    },
                };
                return View(myModel);
            }
        }
        public ActionResult CheckTimeIn() {
            using (var myData = new UserTimeData()) {
                var tblOld = myData.GetAll(GetUser().Username).FirstOrDefault(c => c.DateReference >= DateTime.Now.Date);
                if(tblOld != null) {
                    return ShowModal("Index", "Time", "Already done checked in for today. Thank you and have a nice day!");
                }
                //
                var tbl = new TimeDTO {
                    TimeIn = DateTime.Now,
                    Status = "Successfully Time In",
                    DateReference = DateTime.Now.Date,
                    Username = GetUser().Username,
                    TotalHrs = 0,
                };
                myData.SaveDTO(tbl, false, true);
                return ShowModal("Index", "Time", "Sucessfully checked in. Thank you and have a nice day!");
            }
        }
        public ActionResult CheckTimeOut() {
            using (var myData = new UserTimeData()) {
                
                var tblOld = myData.GetAll(GetUser().Username).FirstOrDefault(c=>c.DateReference >= DateTime.Now.Date && c.Status != null);
                //Okay to time out
                if(tblOld != null && tblOld.Status == "Successfully Time In") {
                    //
                    var totalHrs = DateTime.Now - tblOld.TimeIn;
                    var tbl = new TimeDTO {
                        IdTrack = tblOld.IdTrack,
                        TimeIn = (DateTime)tblOld.TimeIn,
                        TimeOut = DateTime.Now,
                        Status = "Successfully Time Out",
                        Username = GetUser().Username,
                        TotalHrs = (decimal)totalHrs.Value.TotalHours,
                        DateReference = (DateTime)tblOld.DateReference,

                    };
                    myData.UpdateDTO(tbl, false, true);
                    return ShowModal("Index", "Time", "Sucessfully checked out. Thank you and have a nice day!");
                }
                return ShowModal("Index", "Time", "Already done checed out for today. Comeback tomorrow!");
            }
        }
        public ActionResult ShowModal(string actionName, string controllerName, string msg) {
            ViewBag.ActionName = actionName;
            ViewBag.ControllerName = controllerName;
            ViewBag.Messages = msg;
            return View("~/Views/Includes/ModalAlert.cshtml");
        }
        private UserDTO GetUser() {
            return Session["User"] as UserDTO;
        }
    }
    public class TimeViewModel {
        public List<TimeDTO> TimeList { get; set; }
        public UserTimeCountDTO TimeCount { get; set; }
    }
}
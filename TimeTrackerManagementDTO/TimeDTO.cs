using FerPROJ.Design.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeTrackerManagementDTO {
    public class TimeDTO : CValidator {
        public long IdTrack { get; set; }
        public string Username { get; set; }
        public System.DateTime TimeIn { get; set; }
        public System.DateTime TimeOut { get; set; }
        public System.DateTime DateReference { get; set; }
        public string Status { get; set; }
        public decimal TotalHrs { get; set; }

        public override bool DataValidation() {
            throw new NotImplementedException();
        }
    }
}

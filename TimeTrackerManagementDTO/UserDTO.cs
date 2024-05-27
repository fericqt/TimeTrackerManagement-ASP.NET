using FerPROJ.Design.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeTrackerManagementDTO
{
    public class UserDTO : CValidator
    {
        public long IdTrack { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public Nullable<System.DateTime> CreatedAt { get; set; } =  DateTime.Now;
        public string Email { get; set; }
        public byte[] ProfileImg { get; set; }
        public string ProfileImgBase64 { get; set; }

        public override bool DataValidation() {
            throw new NotImplementedException();
        }
    }
}

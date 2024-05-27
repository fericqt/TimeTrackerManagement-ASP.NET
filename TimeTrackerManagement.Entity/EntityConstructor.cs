using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeTrackerManagement.Entity
{
    public partial class timetrackerEntities : DbContext { 
        public timetrackerEntities() : base("name=timetrackerEntities") {
            Database.Connection.ConnectionString = "Server=localhost;Port=3309;Database=timetracker;Uid=adminserver;Pwd=admin123!@#;SslMode=none;";
        }
    }
}

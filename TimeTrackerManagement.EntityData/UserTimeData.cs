using FerPROJ.DBHelper.Base;
using FerPROJ.DBHelper.CRUD;
using FerPROJ.Design.Class;
using FerPROJ.Design.Interface;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeTrackerManagement.Entity;
using TimeTrackerManagementDTO;

namespace TimeTrackerManagementDB {
    public class UserTimeData : BaseDBEntity<timetrackerEntities, Conn, TimeDTO, int>, IEntityData<tbltime, int> {
        public UserTimeData() {
        }

        public UserTimeData(timetrackerEntities ts) : base(ts) {
        }

        public UserTimeData(Conn conn) : base(conn) {
        }

        public IEnumerable<tbltime> GetAll() {
            return _ts.tbltimes.ToList();
        }
        public IEnumerable<tbltime> GetAll(string username) {
            return _ts.tbltimes.Where(c=>c.Username==username);
        }

        public tbltime GetById(int id) {
            return _ts.tbltimes.FirstOrDefault(c=>c.IdTrack==id);
        }

        public string GetNewID() {
            throw new NotImplementedException();
        }

        protected override void DeleteData(int id) {
            throw new NotImplementedException();
        }

        protected override void SaveData(TimeDTO myDTO) {
            var tbl = new CMapping<TimeDTO, tbltime>().GetMappingResult(myDTO);
            _ts.tbltimes.Add(tbl);
            _ts.SaveChanges();
        }

        protected override void SetTables() {
            _tableName = "tbltime";
        }

        protected override void UpdateData(TimeDTO myDTO) {
            var tbl = new CMapping<TimeDTO, tbltime>().GetMappingResult(myDTO);
            _ts.tbltimes.AddOrUpdate(tbl);
            _ts.SaveChanges();
            
        }
    }
}

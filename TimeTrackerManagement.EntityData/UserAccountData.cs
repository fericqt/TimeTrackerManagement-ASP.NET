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

namespace TimeTrackerManagement.EntityData
{
    public class UserAccountData : BaseDBEntity<timetrackerEntities, Conn, UserDTO, int>, IEntityData<tbluser, int> {
        public UserAccountData() {
        }

        public UserAccountData(timetrackerEntities ts) : base(ts) {
        }

        public UserAccountData(Conn conn) : base(conn) {
        }
        public IEnumerable<tbluser> GetAll() {
            return _ts.tblusers.ToList();
        }

        public tbluser GetById(int id) {
            return _ts.tblusers.FirstOrDefault(c=>c.IdTrack == id);
        }
        public tbluser GetUser(UserDTO myDTO) { 
            return _ts.tblusers.Where(c=>c.Username == myDTO.Username && c.Password == myDTO.Password).FirstOrDefault();
        }

        public string GetNewID() {
            throw new NotImplementedException();
        }

        protected override void DeleteData(int id) {
            var tbl = GetById(id);
            _ts.tblusers.Remove(tbl);
            _ts.SaveChanges();
        }

        protected override void SaveData(UserDTO myDTO) {
            var tbl = new CMapping<UserDTO, tbluser>().GetMappingResult(myDTO);
            _ts.tblusers.Add(tbl);
            _ts.SaveChanges();
        }

        protected override void SetTables() {
            _tableName = "tbluser";
        }

        protected override void UpdateData(UserDTO myDTO) {
            var tbl = GetById(myDTO.IdTrack.ToInt());
            tbl.Username = myDTO.Username;
            tbl.Email = myDTO.Email;
            _ts.SaveChanges();
        }
    }
}

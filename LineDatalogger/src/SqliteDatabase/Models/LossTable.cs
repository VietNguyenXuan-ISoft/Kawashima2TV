using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace SqliteDatabase.Models
{
    //  CREATE TABLE "LossTable" (
    //	"id"	INTEGER NOT NULL,
    //	"LineId"	INTEGER,
    //	"MachineId"	INTEGER,
    //	"LossCode"	INTEGER,
    //	"LossDescription"	TEXT,
    //	"IsUsed"	INTEGER,
    //	"GroupIdx"	INTEGER,
    //	"menu_1"	TEXT,
    //	"menu_2"	TEXT,
    //	"menu_3"	TEXT,
    //	"menu_4"	TEXT,
    //	"RolePermit"	INTEGER,
    //	"StandardTiming"	TEXT,
    //	"StandardCounting"	TEXT,
    //	"Machine"	INTEGER,
    //	"Man"	INTEGER,
    //	"Method"	INTEGER,
    //	"Material"	INTEGER,
    //	"Management"	INTEGER,
    //	"Spare01"	INTEGER,
    //	"Spare02"	INTEGER,
    //	"IsUnassignLoss"	INTEGER,
    //	"SendMail"	INTEGER,
    //	"TimeLossStandard"	INTEGER,
    //	"IsLockLoss"	INTEGER,
    //	"IsDisplayMenuLoss"	INTEGER,
    //	"createId"	INTEGER,
    //	"updateId"	INTEGER,
    //	"created"	TEXT,
    //	"updated"	TEXT,
    //	PRIMARY KEY("id" AUTOINCREMENT)
    //);
    public class LossTable
    {
        #region Models
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }
        public int LineId { get; set; }
        public int MachineId { get; set; }
        public int LossCode { get; set; }
        public string LossDescription { get; set; }
        public int IsUsed { get; set; }
        public int GroupIdx { get; set; }
        public string menu_1 { get; set; }
        public string menu_2 { get; set; }
        public string menu_3 { get; set; }
        public string menu_4 { get; set; }
        public int RolePermit { get; set; }
        public string StandardTiming { get; set; }
        public string StandardCounting { get; set; }
        public bool Machine { get; set; }
        public bool Man { get; set; }
        public bool Method { get; set; }
        public bool Material { get; set; }
        public bool Management { get; set; }
        public int Spare01 { get; set; }
        public int Spare02 { get; set; }
        public int IsUnassignLoss { get; set; }
        public bool SendMail { get; set; }
        public int TimeLossStandard { get; set; }
        public bool IsLockLoss { get; set; }
        public bool IsDisplayMenuLoss
        {
            get;
            set;
        }
        public int createId { get; set; }
        public int updateId { get; set; }
        public string created { get; set; }
        public string updated { get; set; }
        //	PRIMARY KEY("id" AUTOINCREMENT)
        #endregion






        #region Methods
        private static LossTable Clone(LossTable src)
        {
            LossTable dst = new LossTable()
            {
                id = src.id,
                LineId = src.LineId,
                MachineId = src.MachineId,
                LossCode = src.LossCode,
                LossDescription = src.LossDescription,
                IsUsed = src.IsUsed,
                GroupIdx = src.GroupIdx,
                menu_1 = src.menu_1,
                menu_2 = src.menu_2,
                menu_3 = src.menu_3,
                menu_4 = src.menu_4,
                RolePermit = src.RolePermit,
                StandardTiming = src.StandardTiming,
                StandardCounting = src.StandardCounting,
                Machine = src.Machine,
                Man = src.Man,
                Method = src.Method,
                Material = src.Material,
                Management = src.Management,
                Spare01 = src.Spare01,
                Spare02 = src.Spare02,
                IsUnassignLoss = src.IsUnassignLoss,
                SendMail = src.SendMail,
                TimeLossStandard = src.TimeLossStandard,
                IsLockLoss = src.IsLockLoss,
                IsDisplayMenuLoss = src.IsDisplayMenuLoss,
                createId = src.createId,
                updateId = src.updateId,
                created = src.created,
                updated = src.updated,
            };
            return dst;
        }

        public static List<LossTable> LoadAll(SQLiteConnection db)
        {
            List<LossTable> data = new List<LossTable>();
            try
            {
                data = (db != null) ? db.Table<LossTable>().Where(v => v.id > 0).ToList() : data;
                data.ForEach(x => x.IsDisplayMenuLoss = true);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error LoadAll LossTable: {ex.Message.ToString()}");
            }
            return data;
        }
        public static int Insert(SQLiteConnection db, LossTable src)
        {
            int rowId = -1;
            try
            {
                if (db != null)
                {
                    rowId = db.Insert(src);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error Insert LossTable: {ex.Message.ToString()}");
            }

            return rowId;
        }

        public static int Update(SQLiteConnection db, LossTable src)
        {
            int rowId = -1;
            try
            {
                if (db != null)
                {
                    rowId = db.Update(src);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error Update LossTable: {ex.Message.ToString()}");
            }
            return rowId;
        }

        #endregion
    }
}

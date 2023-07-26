using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace SqliteDatabase.Models.Datalog
{
    //  CREATE TABLE "MaterialWaste" (
    //	"id"	INTEGER NOT NULL,
    //	"DateTime"	TEXT,
    //	"LineId"	INTEGER,
    //	"MachineId"	INTEGER,
    //	"Shift"	INTEGER,
    //	"SKU"	INTEGER,
    //	"FGs"	INTEGER,
    //	"CounterIn"	INTEGER,
    //	"CounterOut"	INTEGER,
    //	"ePcs"	INTEGER,
    //	"Spare01"	TEXT,
    //	"Spare02"	TEXT,
    //	"createId"	INTEGER,
    //	"updateId"	INTEGER,
    //	"created"	TEXT,
    //	"updated"	TEXT,
    //	PRIMARY KEY("id" AUTOINCREMENT)
    //);
    public class MaterialWaste
    {
        #region Models
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }
        public string DateTime { get; set; }
        public int LineId { get; set; }
        public int MachineId { get; set; }
        public int Shift { get; set; }
        public int SKU { get; set; }
        public string FGs { get; set; }
        public int CounterIn { get; set; }
        public int CounterOut { get; set; }
        public int ePcs { get; set; }
        public int Spare01 { get; set; }
        public int Spare02 { get; set; }
        public int createId { get; set; }
        public int updateId { get; set; }
        public string created { get; set; }
        public string updated { get; set; }
        #endregion
        #region Methods
        private static MaterialWaste Clone(MaterialWaste src)
        {
            MaterialWaste dst = new MaterialWaste()
            {
                id = src.id,
                DateTime = src.DateTime,
                LineId = src.LineId,
                MachineId = src.MachineId,
                Shift = src.Shift,
                SKU = src.SKU,
                FGs = src.FGs,
                CounterIn = src.CounterIn,
                CounterOut = src.CounterOut,
                ePcs = src.ePcs,
                Spare01 = src.Spare01,
                Spare02 = src.Spare02,
                createId = src.createId,
                updateId = src.updateId,
                created = src.created,
                updated = src.updated,
            };
            return dst;
        }

        public static List<MaterialWaste> LoadAll(SQLiteConnection db)
        {
            List<MaterialWaste> data = new List<MaterialWaste>();
            try
            {
                data = (db != null) ? db.Table<MaterialWaste>().Where(v => v.id > 0).ToList() : data;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error LoadAll MaterialWaste: {ex.Message.ToString()}");
            }
            return data;
        }
        public static int Insert(SQLiteConnection db, MaterialWaste src)
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
                Console.WriteLine($"Error Insert MaterialWaste: {ex.Message.ToString()}");
            }
            return rowId;
        }

        public static int Update(SQLiteConnection db, MaterialWaste src)
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
                Console.WriteLine($"Error Update MaterialWaste: {ex.Message.ToString()}");
            }
            return rowId;
        }

        #endregion
    }
}

using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace SqliteDatabase.Models.Datalog
{
    //  CREATE TABLE "loss_management" (
    //	"id"	INTEGER NOT NULL,
    //	"DateTime_Start"	TEXT,
    //	"LineId"	INTEGER,
    //	"MachineID"	INTEGER,
    //	"Duration"	INTEGER,
    //	"loss_id"	INTEGER,
    //	"Description"	TEXT,
    //	"DateTime_End"	TEXT,
    //	"Shift"	INTEGER,
    //	"SKU"	INTEGER,
    //	"FGs"	TEXT,
    //	"StatusLog"	TEXT,
    //	"Operators"	TEXT,
    //	"DateTimeUpdate"	TEXT,
    //	"AM_5AM"	INTEGER,
    //	"WaitingConfirm"	INTEGER,
    //	"Spare02"	TEXT,
    //	"Spare03"	TEXT,
    //	"Spare05"	TEXT,
    //	"createId"	INTEGER,
    //	"updateId"	INTEGER,
    //	"created"	TEXT,
    //	"updated"	TEXT,
    //	"MaterialWasteByLoss"	INTEGER,
    //	PRIMARY KEY("id" AUTOINCREMENT)
    //);
    public class loss_management
    {
        #region Models
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }

        public string DateTime_Start { get; set; }
        public int LineId { get; set; }
        public int MachineID { get; set; }
        public int Duration { get; set; }
        public int loss_id { get; set; }
        public string Description { get; set; }
        public string DateTime_End { get; set; }
        public int Shift { get; set; }
        public int SKU { get; set; }
        public string FGs { get; set; }
        public string StatusLog { get; set; }
        public string Operators { get; set; }
        public string DateTimeUpdate { get; set; }
        public int AM_5AM { get; set; }
        public int WaitingConfirm { get; set; }
        public string Spare02 { get; set; }
        public string Spare03 { get; set; }
        public string Spare05 { get; set; }
        public int createId { get; set; }
        public int updateId { get; set; }
        public string created { get; set; }
        public string updated { get; set; }
        public int MaterialWasteByLoss { get; set; }


        #endregion
        #region Methods
        private static loss_management Clone(loss_management src)
        {
            loss_management dst = new loss_management()
            {
                DateTime_Start = src.DateTime_Start,
                LineId = src.LineId,
                MachineID = src.MachineID,
                Duration = src.Duration,
                loss_id = src.loss_id,
                Description = src.Description,
                DateTime_End = src.DateTime_End,
                Shift = src.Shift,
                SKU = src.SKU,
                FGs = src.FGs,
                StatusLog = src.StatusLog,
                Operators = src.Operators,
                DateTimeUpdate = src.DateTimeUpdate,
                AM_5AM = src.AM_5AM,
                WaitingConfirm = src.WaitingConfirm,
                Spare02 = src.Spare02,
                Spare03 = src.Spare03,
                Spare05 = src.Spare05,
                createId = src.createId,
                updateId = src.updateId,
                created = src.created,
                updated = src.updated,
                MaterialWasteByLoss = src.MaterialWasteByLoss,
            };
            return dst;
        }

        public static List<loss_management> LoadAll(SQLiteConnection db)
        {
            List<loss_management> data = new List<loss_management>();
            try
            {
                data = (db != null) ? db.Table<loss_management>().Where(v => v.id > 0).ToList() : data;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error LoadAll loss_management: {ex.Message.ToString()}");
            }
            return data;
        }
        public static int Insert(SQLiteConnection db, loss_management src)
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
                Console.WriteLine($"Error Insert loss_management: {ex.Message.ToString()}");
            }
            return rowId;
        }

        public static int Update(SQLiteConnection db, loss_management src)
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
                Console.WriteLine($"Error Update loss_management: {ex.Message.ToString()}");
            }
            return rowId;
        }

        #endregion
    }
}

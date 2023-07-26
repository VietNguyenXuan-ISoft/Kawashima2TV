using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace SqliteDatabase.Models
{
    //  CREATE TABLE "ProductionPlan" (
    //	"id"	INTEGER NOT NULL,
    //	"LineId"	INTEGER,
    //	"Date"	TEXT,
    //	"Active"	INTEGER,
    //	"Shift"	TEXT,
    //	"SKU"	TEXT,
    //	"FGs"	TEXT,
    //	"PlanTime"	INTEGER,
    //	"Target"	TEXT,
    //	"Operator"	TEXT,
    //	"DateTimeFromFileAccess"	TEXT,
    //	"DateTimeFromUserInputManual"	TEXT,
    //	"createId"	INTEGER,
    //	"updatedId"	INTEGER,
    //	"created"	TEXT,
    //	"updated"	TEXT,
    //	"updateId"	INTEGER,
    //	PRIMARY KEY("id" AUTOINCREMENT)
    //);
    public class ProductionPlan
    {
        #region Models
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }
        public int LineId { get; set; }
        public string Date { get; set; }
        public bool Active { get; set; }
        public string Shift { get; set; }
        public string SKU { get; set; }
        public string FGs { get; set; }
        public int PlanTime { get; set; }
        public string Target { get; set; }
        public string Operator { get; set; }
        public string DateTimeFromFileAccess { get; set; }
        public string DateTimeFromUserInputManual { get; set; }
        public int createId { get; set; }
        public int updatedId { get; set; }
        public string created { get; set; }
        public string updated { get; set; }
        public int updateId { get; set; }
        #endregion


        #region Methods
        private static ProductionPlan Clone(ProductionPlan src)
        {
            ProductionPlan dst = new ProductionPlan()
            {
                id = src.id,
                LineId = src.LineId,
                Date = src.Date,
                Active = src.Active,
                Shift = src.Shift,
                SKU = src.SKU,
                FGs = src.FGs,
                PlanTime = src.PlanTime,
                Target = src.Target,
                Operator = src.Operator,
                DateTimeFromFileAccess = src.DateTimeFromFileAccess,
                DateTimeFromUserInputManual = src.DateTimeFromUserInputManual,
                createId = src.createId,
                updatedId = src.updatedId,
                created = src.created,
                updated = src.updated,
                updateId = src.updateId,
            };
            return dst;
        }

        public static List<ProductionPlan> LoadAll(SQLiteConnection db)
        {
            List<ProductionPlan> data = new List<ProductionPlan>();
            try
            {
                data = (db != null) ? db.Table<ProductionPlan>().Where(v => v.id > 0).ToList() : data;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error LoadAll ProductionPlan: {ex.Message.ToString()}");
            }
            return data;
        }
        public static int Insert(SQLiteConnection db, ProductionPlan src)
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
                Console.WriteLine($"Error Insert ProductionPlan: {ex.Message.ToString()}");
            }
            return rowId;
        }

        public static int Update(SQLiteConnection db, ProductionPlan src)
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
                Console.WriteLine($"Error Update ProductionPlan: {ex.Message.ToString()}");
            }
            return rowId;
        }

        #endregion
    }
}

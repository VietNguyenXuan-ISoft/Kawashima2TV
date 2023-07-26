using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace SqliteDatabase.Models.Datalog
{
    //  CREATE TABLE "data_log" (
    //	"id"	INTEGER,
    //	"LineId"	INTEGER,
    //	"DateTime"	TEXT,
    //	"Shift"	INTEGER,
    //	"FGs"	TEXT,
    //	"SKU"	INTEGER,
    //	"Target_speed"	TEXT,
    //	"Actual_speed"	TEXT,
    //	"Target_counter"	TEXT,
    //	"Actual_counter"	TEXT,
    //	"Target_Temperature"	TEXT,
    //	"Actual_Temperature"	TEXT,
    //	"Operators"	TEXT,
    //	"CounterAllLine"	INTEGER,
    //	"Actual_counterIN"	TEXT,
    //	"Spare01"	TEXT,
    //	"Spare02"	TEXT,
    //	"Spare03"	TEXT,
    //	"Spare04"	TEXT,
    //	"Spare05"	TEXT,
    //	"createId"	INTEGER,
    //	"updateId"	INTEGER,
    //	"created"	TEXT,
    //	"updated"	TEXT,
    //	PRIMARY KEY("id" AUTOINCREMENT)
    //);
    public class data_log
    {
        #region Models
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }
        public int LineId { get; set; }
        public string DateTime { get; set; }
        public int Shift { get; set; }
        public string FGs { get; set; }
        public int SKU { get; set; }
        public string Target_speed { get; set; }
        public string Actual_speed { get; set; }
        public string Target_counter { get; set; }
        public string Actual_counter { get; set; }
        public string Target_Temperature { get; set; }
        public string Actual_Temperature { get; set; }
        public string Operators { get; set; }
        public int CounterAllLine { get; set; }
        public string Actual_counterIN { get; set; }
        public string Spare01 { get; set; }
        public string Spare02 { get; set; }
        public string Spare03 { get; set; }
        public string Spare04 { get; set; }
        public string Spare05 { get; set; }
        public int createId { get; set; }
        public int updateId { get; set; }
        public string created { get; set; }
        public string updated { get; set; }

        //public data_log()
        //{

        //}
        #endregion
        #region Methods
        private static data_log Clone(data_log src)
        {
            data_log dst = new data_log()
            {
                id = src.id,
                LineId = src.LineId,
                DateTime = src.DateTime,
                Shift = src.Shift,
                FGs = src.FGs,
                SKU = src.SKU,
                Target_speed = src.Target_speed,
                Actual_speed = src.Actual_speed,
                Target_counter = src.Target_counter,
                Actual_counter = src.Actual_counter,
                Target_Temperature = src.Target_Temperature,
                Actual_Temperature = src.Actual_Temperature,
                Operators = src.Operators,
                CounterAllLine = src.CounterAllLine,
                Actual_counterIN = src.Actual_counterIN,
                Spare01 = src.Spare01,
                Spare02 = src.Spare02,
                Spare03 = src.Spare03,
                Spare04 = src.Spare04,
                Spare05 = src.Spare05,
                createId = src.createId,
                updateId = src.updateId,
                created = src.created,
                updated = src.updated,
            };
            return dst;
        }

        public static List<data_log> LoadAll(SQLiteConnection db)
        {
            List<data_log> data = new List<data_log>();
            try
            {
                data = (db != null) ? db.Table<data_log>().Where(v => v.id > 0).ToList() : data;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error LoadAll data_log: {ex.Message.ToString()}");
            }
            return data;
        }
        public static int Insert(SQLiteConnection db, data_log src)
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
                Console.WriteLine($"Error Insert data_log: {ex.Message.ToString()}");
            }
            return rowId;
        }

        public static int Update(SQLiteConnection db, data_log src)
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
                Console.WriteLine($"Error Update data_log: {ex.Message.ToString()}");
            }
            return rowId;
        }

        #endregion
    }
}

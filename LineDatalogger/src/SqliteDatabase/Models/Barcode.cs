using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqliteDatabase.Models
{
    //  CREATE TABLE "Barcode" (
    //	"id"	INTEGER NOT NULL,
    //	"FGs"	TEXT,
    //	"Description"	TEXT,
    //	"BarcodeScanner"	TEXT,
    //	"StandardSpeed_1"	TEXT,
    //	"StandardSpeed_2"	TEXT,
    //	"StandardSpeed_3"	TEXT,
    //	"StandardSpeed_4"	TEXT,
    //	"StandardSpeed_5"	TEXT,
    //	"StandardSpeed_6"	TEXT,
    //	"ProductCategory"	TEXT,
    //	"DateCodeFormat"	TEXT,
    //	"DateCodeMonth"	TEXT,
    //	"PcsInOneBox"	TEXT,
    //	"OEETarget"	TEXT,
    //	"Spare_03"	TEXT,
    //	"LineId"	INTEGER,
    //	"StandardSpeed_7"	TEXT,
    //	"StandardSpeed_8"	TEXT,
    //	"StandardSpeed_9"	TEXT,
    //	"Factor_1"	INTEGER,
    //	"Factor_2"	INTEGER,
    //	"Factor_3"	INTEGER,
    //	"Factor_4"	INTEGER,
    //	"Factor_5"	INTEGER,
    //	"Factor_6"	INTEGER,
    //	"Factor_7"	INTEGER,
    //	"Factor_8"	INTEGER,
    //	"Factor_9"	INTEGER,
    //	"RowId"	INTEGER,
    //	"IsUserInput"	INTEGER,
    //	"IsEnzim"	INTEGER,
    //	"createId"	INTEGER,
    //	"updateId"	INTEGER,
    //	"created"	TEXT,
    //	"updated"	TEXT,
    //	"BoxInOnePallet"	TEXT,
    //	"PackingWeight"	FLOAT,
    //	"DelayTiming_1"	FLOAT,
    //	"DelayTiming_2"	FLOAT,
    //	"DelayTiming_3"	FLOAT,
    //	"DelayTiming_4"	FLOAT,
    //	"DelayTiming_5"	FLOAT,
    //	"DelayTiming_6"	FLOAT,
    //	"DelayTiming_7"	FLOAT,
    //	"DelayTiming_8"	FLOAT,
    //	"DelayTiming_9"	FLOAT,
    //	PRIMARY KEY("id" AUTOINCREMENT)
    //);
    public class Barcode
    {
        #region Models
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }
        public string FGs { get; set; }
        public string Description { get; set; }
        public string BarcodeScanner { get; set; }
        public string StandardSpeed_1 { get; set; }
        public string StandardSpeed_2 { get; set; }
        public string StandardSpeed_3 { get; set; }
        public string StandardSpeed_4 { get; set; }
        public string StandardSpeed_5 { get; set; }
        public string StandardSpeed_6 { get; set; }
        public string ProductCategory { get; set; }
        public string DateCodeFormat { get; set; }
        public string DateCodeMonth { get; set; }
        public int PcsInOneBox { get; set; }
        public string OEETarget { get; set; }
        public string Spare_03 { get; set; }
        public int LineId { get; set; }
        public string StandardSpeed_7 { get; set; }
        public string StandardSpeed_8 { get; set; }
        public string StandardSpeed_9 { get; set; }
        public double Factor_1 { get; set; }
        public double Factor_2 { get; set; }
        public double Factor_3 { get; set; }
        public double Factor_4 { get; set; }
        public double Factor_5 { get; set; }
        public double Factor_6 { get; set; }
        public double Factor_7 { get; set; }
        public double Factor_8 { get; set; }
        public double Factor_9 { get; set; }
        public int RowId { get; set; }
        public bool IsUserInput { get; set; }
        public bool IsEnzim { get; set; }
        public int createId { get; set; }
        public int updateId { get; set; }
        public string created { get; set; }
        public string updated { get; set; }
        public double BoxInOnePallet { get; set; }
        public double PackingWeight { get; set; }
        public double DelayTiming_1 { get; set; }
        public double DelayTiming_2 { get; set; }
        public double DelayTiming_3 { get; set; }
        public double DelayTiming_4 { get; set; }
        public double DelayTiming_5 { get; set; }
        public double DelayTiming_6 { get; set; }
        public double DelayTiming_7 { get; set; }
        public double DelayTiming_8 { get; set; }
        public double DelayTiming_9 { get; set; }
        #endregion


        #region Methods
        private static Barcode Clone(Barcode src)
        {
            Barcode dst = new Barcode()
            {
                id = src.id,
                FGs = src.FGs,
                Description = src.Description,
                BarcodeScanner = src.BarcodeScanner,
                StandardSpeed_1 = src.StandardSpeed_1,
                StandardSpeed_2 = src.StandardSpeed_2,
                StandardSpeed_3 = src.StandardSpeed_3,
                StandardSpeed_4 = src.StandardSpeed_4,
                StandardSpeed_5 = src.StandardSpeed_5,
                StandardSpeed_6 = src.StandardSpeed_6,
                ProductCategory = src.ProductCategory,
                DateCodeFormat = src.DateCodeFormat,
                DateCodeMonth = src.DateCodeMonth,
                PcsInOneBox = src.PcsInOneBox,
                OEETarget = src.OEETarget,
                Spare_03 = src.Spare_03,
                LineId = src.LineId,
                StandardSpeed_7 = src.StandardSpeed_7,
                StandardSpeed_8 = src.StandardSpeed_8,
                StandardSpeed_9 = src.StandardSpeed_9,
                Factor_1 = src.Factor_1,
                Factor_2 = src.Factor_2,
                Factor_3 = src.Factor_3,
                Factor_4 = src.Factor_4,
                Factor_5 = src.Factor_5,
                Factor_6 = src.Factor_6,
                Factor_7 = src.Factor_7,
                Factor_8 = src.Factor_8,
                Factor_9 = src.Factor_9,
                RowId = src.RowId,
                IsUserInput = src.IsUserInput,
                IsEnzim = src.IsEnzim,
                createId = src.createId,
                updateId = src.updateId,
                created = src.created,
                updated = src.updated,
                BoxInOnePallet = src.BoxInOnePallet,
                PackingWeight = src.PackingWeight,
                DelayTiming_1 = src.DelayTiming_1,
                DelayTiming_2 = src.DelayTiming_2,
                DelayTiming_3 = src.DelayTiming_3,
                DelayTiming_4 = src.DelayTiming_4,
                DelayTiming_5 = src.DelayTiming_5,
                DelayTiming_6 = src.DelayTiming_6,
                DelayTiming_7 = src.DelayTiming_7,
                DelayTiming_8 = src.DelayTiming_8,
                DelayTiming_9 = src.DelayTiming_9,
            };
            return dst;
        }

        public static List<Barcode> LoadAll(SQLiteConnection db)
        {
            List<Barcode> data = new List<Barcode>();
            try
            {
                data = (db != null) ? db.Table<Barcode>().Where(v => v.id > 0).ToList() : data;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error LoadAll Barcode: {ex.Message.ToString()}");
            }
            return data;
        }

        public static int Insert(SQLiteConnection db, Barcode src)
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
                Console.WriteLine($"Error Insert Barcode: {ex.Message.ToString()}");
            }

            return rowId;
        }

        public static int Update(SQLiteConnection db, Barcode src)
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
                Console.WriteLine($"Error Update Update: {ex.Message.ToString()}");
            }
            return rowId;
        }

        #endregion
    }


}

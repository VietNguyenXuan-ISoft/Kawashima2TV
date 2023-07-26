using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace SqliteDatabase.Models
{
    //  CREATE TABLE "ProductCategory" (
    //	"id"	INTEGER NOT NULL,
    //	"LineId"	INTEGER,
    //	"TextCode"	TEXT,
    //	"TextValue"	TEXT,
    //	"Spare01"	TEXT,
    //	PRIMARY KEY("id" AUTOINCREMENT)
    //);
    public class ProductCategory
    {
        #region Models
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }
        public string LineId { get; set; }
        public string TextCode { get; set; }
        public string TextValue { get; set; }
        public string Spare01 { get; set; }
        #endregion


        #region Methods
        private static ProductCategory Clone(ProductCategory src)
        {
            ProductCategory dst = new ProductCategory()
            {
                id = src.id,
                LineId = src.LineId,
                TextCode = src.TextCode,
                TextValue = src.TextValue,
                Spare01 = src.Spare01
            };
            return dst;
        }

        public static List<ProductCategory> LoadAll(SQLiteConnection db)
        {
            List<ProductCategory> data = new List<ProductCategory>();
            try
            {
                data = (db != null) ? db.Table<ProductCategory>().Where(v => v.id > 0).ToList() : data;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error LoadAll Position: {ex.Message.ToString()}");
            }
            return data;
        }
        public static int Insert(SQLiteConnection db, ProductCategory src)
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
                Console.WriteLine($"Error Insert ProductCategory: {ex.Message.ToString()}");
            }
            return rowId;
        }

        public static int Update(SQLiteConnection db, ProductCategory src)
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
                Console.WriteLine($"Error Update ProductCategory: {ex.Message.ToString()}");
            }
            return rowId;
        }

        #endregion
    }
}

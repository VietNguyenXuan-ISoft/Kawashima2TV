using SQLite;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqliteDatabase.Models
{
    //  CREATE TABLE "AM_5AM" (
    //	"id"	INTEGER NOT NULL,
    //	"AMCode"	INTEGER,
    //	"AMDescription"	TEXT,
    //	"Spare01"	TEXT,
    //	PRIMARY KEY("id" AUTOINCREMENT)
    //);
    public class AM_5AM
    {
        #region Models
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }
        public int AMCode { get; set; }
        public string AMDescription { get; set; }
        public string Spare01 { get; set; }
        #endregion

        #region Methods
        private static AM_5AM Clone(AM_5AM src)
        {
            AM_5AM dst = new AM_5AM()
            {
                id = src.id,
                AMCode = src.AMCode,
                AMDescription = src.AMDescription,
            };
            return dst;
        }

        public static List<AM_5AM> LoadAll(SQLiteConnection db)
        {
            List<AM_5AM> data = new List<AM_5AM>();
            try
            {
                data = (db != null) ? db.Table<AM_5AM>().Where(v => v.id > 0).ToList() : data;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error Load AM_5AM: {ex.Message.ToString()}");
            }
            return data;
        }
        // Returns:
        //     The number of rows added to the table.
        public static int Insert(SQLiteConnection db, AM_5AM src)
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
                Console.WriteLine($"Error Insert AM_5AM: {ex.Message.ToString()}");
            }

            return rowId;
        }
        // Returns:
        //     The number of rows updated.
        public static int Update(SQLiteConnection db, AM_5AM src)
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
                Console.WriteLine($"Error Update AM_5AM: {ex.Message.ToString()}");
            }
            return rowId;
        }

        #endregion
    }
}

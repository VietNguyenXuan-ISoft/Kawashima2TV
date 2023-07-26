using SQLite;
using SqliteDatabase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace SqliteDatabase.Models
{
    //  CREATE TABLE "Operators" (
    //	"id"	INTEGER NOT NULL,
    //	"LineId"	INTEGER,
    //	"Name"	TEXT,
    //	"LastShift"	INTEGER,
    //	"LastMachineIdx"	INTEGER,
    //	PRIMARY KEY("id" AUTOINCREMENT)
    //);
    public class Operators
    {
        #region Models
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }
        public int LineId { get; set; }
        public string Name { get; set; }
        public int LastShift { get; set; }
        public int LastMachineIdx { get; set; }
        #endregion


        #region Methods
        private static Operators Clone(Operators src)
        {
            Operators dst = new Operators()
            {
                id = src.id,
                LineId = src.LineId,
                Name = src.Name,
                LastShift = src.LastShift,
                LastMachineIdx = src.LastMachineIdx,
            };
            return dst;
        }

        public static List<Operators> LoadAll(SQLiteConnection db)
        {
            List<Operators> data = new List<Operators>();
            try
            {
                data = (db != null) ? db.Table<Operators>().Where(v => v.id > 0).ToList() : data;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error LoadAll Operators: {ex.Message.ToString()}");
            }
            return data;
        }
        public static int Insert(SQLiteConnection db, Operators src)
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
                Console.WriteLine($"Error Insert Operators: {ex.Message.ToString()}");
            }
            return rowId;
        }

        public static int Update(SQLiteConnection db, Operators src)
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
                Console.WriteLine($"Error Update Operators: {ex.Message.ToString()}");
            }
            return rowId;
        }

        #endregion
    }
}

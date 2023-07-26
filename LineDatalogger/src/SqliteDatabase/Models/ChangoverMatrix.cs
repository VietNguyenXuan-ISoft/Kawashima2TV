using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqliteDatabase.Models
{
    //  CREATE TABLE "ChangoverMatrix" (
    //	"id"	INTEGER NOT NULL,
    //	"LineId"	INTEGER,
    //	"Row"	INTEGER,
    //	"Column"	INTEGER,
    //	"TextValue"	TEXT,
    //	"Spare01"	TEXT,
    //	PRIMARY KEY("id" AUTOINCREMENT)
    //);
    public class ChangoverMatrix
    {
        #region Models
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }
        public int LineId { get; set; }
        public int Row { get; set; }
        public int Column { get; set; }
        public string TextValue { get; set; }
        public string Spare01 { get; set; }
        #endregion



        #region Methods
        private static ChangoverMatrix Clone(ChangoverMatrix src)
        {
            ChangoverMatrix dst = new ChangoverMatrix()
            {
                id = src.id,
                LineId = src.LineId,
                Row = src.Row,
                Column = src.Column,
                TextValue = src.TextValue,
                Spare01 = src.Spare01
            };
            return dst;
        }

        public static List<ChangoverMatrix> LoadAll(SQLiteConnection db)
        {
            List<ChangoverMatrix> data = new List<ChangoverMatrix>();
            try
            {
                data = (db != null) ? db.Table<ChangoverMatrix>().Where(v => v.id > 0).ToList() : data;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error LoadAll ChangoverMatrix: {ex.Message.ToString()}");
            }
            return data;
        }

        public static int Insert(SQLiteConnection db, ChangoverMatrix src)
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
                Console.WriteLine($"Error Insert ChangoverMatrix: {ex.Message.ToString()}");
            }

            return rowId;
        }

        public static int Update(SQLiteConnection db, ChangoverMatrix src)
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
                Console.WriteLine($"Error Update ChangoverMatrix: {ex.Message.ToString()}");
            }
            return rowId;
        }

        #endregion
    }
}

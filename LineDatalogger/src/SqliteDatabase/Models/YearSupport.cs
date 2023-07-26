using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace SqliteDatabase.Models
{
    //  CREATE TABLE "YearSupport" (
    //	"id"	INTEGER NOT NULL,
    //	"Year"	INTEGER,
    //	PRIMARY KEY("id" AUTOINCREMENT)
    //);
    public class YearSupport
    {
        #region Models
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }
        public int Year { get; set; }
        #endregion
        #region Methods
        private static YearSupport Clone(YearSupport src)
        {
            YearSupport dst = new YearSupport()
            {
                id = src.id,
                Year = src.Year,
            };
            return dst;
        }

        public static List<YearSupport> LoadAll(SQLiteConnection db)
        {
            List<YearSupport> data = new List<YearSupport>();
            try
            {
                data = (db != null) ? db.Table<YearSupport>().Where(v => v.id > 0).ToList() : data;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error LoadAll YearSupport: {ex.Message.ToString()}");
            }
            return data;
        }
        public static int Insert(SQLiteConnection db, YearSupport src)
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
                Console.WriteLine($"Error Insert YearSupport: {ex.Message.ToString()}");
            }
            return rowId;
        }

        public static int Update(SQLiteConnection db, YearSupport src)
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
                Console.WriteLine($"Error Update YearSupport: {ex.Message.ToString()}");
            }
            return rowId;
        }

        #endregion

        #region Contructor
        public YearSupport()
        {

        }
        public YearSupport(int year)
        {
            this.id = id;
            this.Year = year;
        }
        #endregion
    }
}

using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace SqliteDatabase.Models
{
    //  CREATE TABLE "Factory" (
    //	"id"	INTEGER NOT NULL,
    //	"FactoryName"	TEXT,
    //	"EmailFrom"	TEXT,
    //	"EmailPassword"	TEXT,
    //	"MailService"	TEXT,
    //	PRIMARY KEY("id" AUTOINCREMENT)
    //);
    public class Factory
    {
        #region Models
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }
        public string FactoryName { get; set; }
        public string EmailFrom { get; set; }
        public string EmailPassword { get; set; }
        public string MailService { get; set; }
        #endregion


        #region Methods
        private static Factory Clone(Factory src)
        {
            Factory dst = new Factory()
            {
                id = src.id,
                FactoryName = src.FactoryName,
                EmailFrom = src.EmailFrom,
                EmailPassword = src.EmailPassword,
                MailService = src.MailService,
            };
            return dst;
        }

        public static List<Factory> LoadAll(SQLiteConnection db)
        {
            List<Factory> data = new List<Factory>();
            try
            {
                data = (db != null) ? db.Table<Factory>().Where(v => v.id > 0).ToList() : data;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error LoadAll Factory: {ex.Message.ToString()}");
            }
            return data;
        }
        public static int Insert(SQLiteConnection db, Factory src)
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
                Console.WriteLine($"Error Insert Factory: {ex.Message.ToString()}");
            }

            return rowId;
        }

        public static int Update(SQLiteConnection db, Factory src)
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
                Console.WriteLine($"Error Update Factory: {ex.Message.ToString()}");
            }
            return rowId;
        }

        #endregion
    }
}

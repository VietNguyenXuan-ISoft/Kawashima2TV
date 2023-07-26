using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace SqliteDatabase.Models
{
    //  CREATE TABLE "MailAddressSupport" (
    //	"id"	INTEGER,
    //	"MailAddress"	TEXT,
    //	"Spare01"	TEXT,
    //	"Spare02"	TEXT,
    //	"Spare03"	TEXT,
    //	"FactoryName"	TEXT,
    //	"GroupName"	TEXT,
    //	"Duration"	TEXT,
    //	PRIMARY KEY("id")
    //);
    public class MailAddressSupport
    {
        #region Models
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }
        public string MailAddress { get; set; }
        public string Spare01 { get; set; }
        public string Spare02 { get; set; }
        public string Spare03 { get; set; }
        public string FactoryName { get; set; }
        public string GroupName { get; set; }
        public string Duration { get; set; }
        #endregion


        #region Methods
        private static MailAddressSupport Clone(MailAddressSupport src)
        {
            MailAddressSupport dst = new MailAddressSupport()
            {
                id = src.id,
                MailAddress = src.MailAddress,
                Spare01 = src.Spare01,
                Spare02 = src.Spare02,
                Spare03 = src.Spare03,
                FactoryName = src.FactoryName,
                GroupName = src.GroupName,
                Duration = src.Duration,
            };
            return dst;
        }

        public static List<MailAddressSupport> LoadAll(SQLiteConnection db)
        {
            List<MailAddressSupport> data = new List<MailAddressSupport>();
            try
            {
                data = (db != null) ? db.Table<MailAddressSupport>().Where(v => v.id > 0).ToList() : data;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error LoadAll MailAddressSupport: {ex.Message.ToString()}");
            }
            return data;
        }
        public static int Insert(SQLiteConnection db, MailAddressSupport src)
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
                Console.WriteLine($"Error Insert MailAddressSupport: {ex.Message.ToString()}");
            }

            return rowId;
        }

        public static int Update(SQLiteConnection db, MailAddressSupport src)
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
                Console.WriteLine($"Error Update MailAddressSupport: {ex.Message.ToString()}");
            }
            return rowId;
        }

        #endregion
    }
}

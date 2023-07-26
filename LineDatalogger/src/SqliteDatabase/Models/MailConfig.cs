using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace SqliteDatabase.Models
{
    //  CREATE TABLE "MailConfig" (
    //	"id"	INTEGER,
    //	"SMTPAddress"	TEXT,
    //	"EmailPassword"	TEXT,
    //	"Subject"	TEXT,
    //	"EmailFrom"	TEXT,
    //	"LossDuration"	INTEGER,
    //	"Spare01"	TEXT,
    //	"Spare02"	TEXT,
    //	"Spare03"	TEXT,
    //	"FactoryName"	TEXT,
    //	"MailService"	TEXT,
    //	PRIMARY KEY("id")
    //);
    public class MailConfig
    {
        #region Models
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }
        public string SMTPAddress { get; set; }
        public string EmailPassword { get; set; }
        public string Subject { get; set; }
        public string EmailFrom { get; set; }
        public int LossDuration { get; set; }
        public string Spare01 { get; set; }
        public string Spare02 { get; set; }
        public string Spare03 { get; set; }
        public string FactoryName { get; set; }
        public string MailService { get; set; }
        #endregion


        #region Methods
        private static MailConfig Clone(MailConfig src)
        {
            MailConfig dst = new MailConfig()
            {
                id = src.id,
                SMTPAddress = src.SMTPAddress,
                EmailPassword = src.EmailPassword,
                Subject = src.Subject,
                EmailFrom = src.EmailFrom,
                LossDuration = src.LossDuration,
                Spare01 = src.Spare01,
                Spare02 = src.Spare02,
                Spare03 = src.Spare03,
                FactoryName = src.FactoryName,
                MailService = src.MailService
            };
            return dst;
        }

        public static List<MailConfig> LoadAll(SQLiteConnection db)
        {
            List<MailConfig> data = new List<MailConfig>();
            try
            {
                data = (db != null) ? db.Table<MailConfig>().Where(v => v.id > 0).ToList() : data;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error LoadAll MailAddressSupport: {ex.Message.ToString()}");
            }
            return data;
        }
        public static int Insert(SQLiteConnection db, MailConfig src)
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
                Console.WriteLine($"Error Insert MailConfig: {ex.Message.ToString()}");
            }
            return rowId;
        }

        public static int Update(SQLiteConnection db, MailConfig src)
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
                Console.WriteLine($"Error Update MailConfig: {ex.Message.ToString()}");
            }
            return rowId;
        }

        #endregion
    }
}

using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace SqliteDatabase.Models
{
    //  CREATE TABLE "EventLogs" (
    //	"id"	INTEGER NOT NULL,
    //	"LineId"	INTEGER,
    //	"DateTime"	TEXT,
    //	"User"	INTEGER,
    //	"Shift"	TEXT,
    //	"EventCode"	INTEGER,
    //	"EventDescription"	TEXT,
    //	"Spare01"	TEXT,
    //	"Spare02"	TEXT,
    //	"Note"	TEXT,
    //	PRIMARY KEY("id" AUTOINCREMENT)
    //);
    public class EventLogs
    {
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }
        public int LineId { get; set; }
        public string DateTime { get; set; }
        public int User { get; set; }
        public int Shift { get; set; }
        public int EventCode { get; set; }
        public string EventDescription { get; set; }
        public string Spare01 { get; set; }
        public string Spare02 { get; set; }
        public string Note { get; set; }
        public EventLogs()
        {

        }
        public static List<EventLogs> LoadAll(SQLiteConnection db)
        {
            List<EventLogs> data = new List<EventLogs>();
            try
            {
                data = (db != null) ? db.Table<EventLogs>().Where(v => v.id > 0).ToList() : data;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error LoadAll EventLogs: {ex.Message.ToString()}");
            }
            return data;
        }

        public static int Insert(SQLiteConnection db, EventLogs src)
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
                Console.WriteLine($"Error Insert EventLogs: {ex.Message.ToString()}");
            }

            return rowId;
        }

        public static int Update(SQLiteConnection db, EventLogs src)
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
                Console.WriteLine($"Error Update EventLogs: {ex.Message.ToString()}");
            }
            return rowId;
        }




    }



}

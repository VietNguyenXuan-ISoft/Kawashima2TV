using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace SqliteDatabase.Models
{
    //  CREATE TABLE "SerialSettings" (
    //	"id"	INTEGER NOT NULL,
    //	"LineId"	INTEGER,
    //	"ComPort"	TEXT,
    //	"CallOfSystemSerialPortCap"	TEXT,
    //	"CallOfSystemSerialPortBottle"	TEXT,
    //	"ComPortTemperature"	TEXT,
    //	"ComPortMettlerToldeoICS425"	TEXT,
    //	PRIMARY KEY("id" AUTOINCREMENT)
    //);
    public class SerialSettings
    {
        #region Models
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }
        public int LineId { get; set; }
        public string ComPort { get; set; }
        public string CallOfSystemSerialPortCap { get; set; }
        public string CallOfSystemSerialPortBottle { get; set; }
        public string ComPortTemperature { get; set; }
        public string ComPortMettlerToldeoICS425 { get; set; }
        #endregion


        #region Methods
        private static SerialSettings Clone(SerialSettings src)
        {
            SerialSettings dst = new SerialSettings()
            {
                id = src.id,
                LineId = src.LineId,
                ComPort = src.ComPort,
                CallOfSystemSerialPortCap = src.CallOfSystemSerialPortCap,
                CallOfSystemSerialPortBottle = src.CallOfSystemSerialPortBottle,
                ComPortTemperature = src.ComPortTemperature,
                ComPortMettlerToldeoICS425 = src.ComPortMettlerToldeoICS425,
            };
            return dst;
        }

        public static List<SerialSettings> LoadAll(SQLiteConnection db)
        {
            List<SerialSettings> data = new List<SerialSettings>();
            try
            {
                data = (db != null) ? db.Table<SerialSettings>().Where(v => v.id > 0).ToList() : data;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error LoadAll SerialSettings: {ex.Message.ToString()}");
            }
            return data;
        }
        public static int Insert(SQLiteConnection db, SerialSettings src)
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
                Console.WriteLine($"Error Insert SerialSettings: {ex.Message.ToString()}");
            }
            return rowId;
        }

        public static int Update(SQLiteConnection db, SerialSettings src)
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
                Console.WriteLine($"Error Update SerialSettings: {ex.Message.ToString()}");
            }
            return rowId;
        }

        #endregion
    }
}

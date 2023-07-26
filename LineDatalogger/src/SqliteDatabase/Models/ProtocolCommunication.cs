using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace SqliteDatabase.Models
{
    //  CREATE TABLE "ProtocolCommunication" (
    //	"id"	INTEGER NOT NULL,
    //	"Protocol"	TEXT,
    //	PRIMARY KEY("id" AUTOINCREMENT)
    //);
    public class ProtocolCommunication
    {
        #region Models
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }
        public string Protocol { get; set; }
        #endregion
        #region Methods
        private static ProtocolCommunication Clone(ProtocolCommunication src)
        {
            ProtocolCommunication dst = new ProtocolCommunication()
            {
                id = src.id,
                Protocol = src.Protocol,
            };
            return dst;
        }

        public static List<ProtocolCommunication> LoadAll(SQLiteConnection db)
        {
            List<ProtocolCommunication> data = new List<ProtocolCommunication>();
            try
            {
                data = (db != null) ? db.Table<ProtocolCommunication>().Where(v => v.id > 0).ToList() : data;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error LoadAll ProtocolCommunication: {ex.Message.ToString()}");
            }
            return data;
        }
        public static int Insert(SQLiteConnection db, ProtocolCommunication src)
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
                Console.WriteLine($"Error Insert ProtocolCommunication: {ex.Message.ToString()}");
            }
            return rowId;
        }

        public static int Update(SQLiteConnection db, ProtocolCommunication src)
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
                Console.WriteLine($"Error Update ProtocolCommunication: {ex.Message.ToString()}");
            }
            return rowId;
        }

        #endregion
    }
}

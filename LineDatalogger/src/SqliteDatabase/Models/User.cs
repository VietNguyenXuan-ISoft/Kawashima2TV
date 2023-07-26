using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace SqliteDatabase.Models
{
    //  CREATE TABLE "User" (
    //	"id"	INTEGER NOT NULL,
    //	"Role"	INTEGER,
    //	"roleEnable"	INTEGER,
    //	"Password"	TEXT,
    //	"LineId"	INTEGER,
    //	"Spare02"	INTEGER,
    //	PRIMARY KEY("id" AUTOINCREMENT)
    //);
    public class User
    {
        #region Models
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }
        public int Role { get; set; }
        public int roleEnable { get; set; }
        public string Password { get; set; }
        public int LineId { get; set; }
        public int Spare02 { get; set; }
        #endregion
        #region Methods
        private static User Clone(User src)
        {
            User dst = new User()
            {
                id = src.id,
                Role = src.Role,
                roleEnable = src.roleEnable,
                Password = src.Password,
                LineId = src.LineId,
                Spare02 = src.Spare02,
            };
            return dst;
        }

        public static List<User> LoadAll(SQLiteConnection db)
        {
            List<User> data = new List<User>();
            try
            {
                data = (db != null) ? db.Table<User>().Where(v => v.id > 0).ToList() : data;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error LoadAll User: {ex.Message.ToString()}");
            }
            return data;
        }
        public static int Insert(SQLiteConnection db, User src)
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
                Console.WriteLine($"Error Insert User: {ex.Message.ToString()}");
            }
            return rowId;
        }

        public static int Update(SQLiteConnection db, User src)
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
                Console.WriteLine($"Error Update User: {ex.Message.ToString()}");
            }
            return rowId;
        }

        #endregion
    }
}

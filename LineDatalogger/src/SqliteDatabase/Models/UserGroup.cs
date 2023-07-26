using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace SqliteDatabase.Models
{
    //  CREATE TABLE "UserGroupGroup" (
    //	"id"	INTEGER,
    //	"GroupName"	TEXT,
    //	"Duration"	INTEGER,
    //	PRIMARY KEY("id" AUTOINCREMENT)
    //);
    public class UserGroup
    {
        #region Models
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }
        public string GroupName { get; set; }
        public int Duration { get; set; }
        #endregion
        #region Methods
        private static UserGroup Clone(UserGroup src)
        {
            UserGroup dst = new UserGroup()
            {
                id = src.id,
                GroupName = src.GroupName,
                Duration = src.Duration,
            };
            return dst;
        }

        public static List<UserGroup> LoadAll(SQLiteConnection db)
        {
            List<UserGroup> data = new List<UserGroup>();
            try
            {
                data = (db != null) ? db.Table<UserGroup>().Where(v => v.id > 0).ToList() : data;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error LoadAll UserGroup: {ex.Message.ToString()}");
            }
            return data;
        }
        public static int Insert(SQLiteConnection db, UserGroup src)
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
                Console.WriteLine($"Error Insert UserGroup: {ex.Message.ToString()}");
            }
            return rowId;
        }

        public static int Update(SQLiteConnection db, UserGroup src)
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
                Console.WriteLine($"Error Update UserGroup: {ex.Message.ToString()}");
            }
            return rowId;
        }

        #endregion
    }
}

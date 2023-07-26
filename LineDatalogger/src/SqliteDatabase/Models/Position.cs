using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace SqliteDatabase.Models
{
    //  CREATE TABLE "Position" (
    //	"id"	INTEGER NOT NULL,
    //	"PosX"	INTEGER,
    //	"PosY"	INTEGER,
    //	"Width"	INTEGER,
    //	"Height"	INTEGER,
    //	"Name"	TEXT,
    //	"MachineId"	INTEGER,
    //	"LineId"	INTEGER,
    //	PRIMARY KEY("id" AUTOINCREMENT)
    //);
    public class Position
    {
        #region Model
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }
        public int PosX { get; set; }
        public int PosY { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public string Name { get; set; }
        public int MachineId { get; set; }
        public int LineId { get; set; }
        #endregion

        #region Methods
        private static Position Clone(Position src)
        {
            Position dst = new Position()
            {
                id = src.id,
                PosX = src.PosX,
                PosY = src.PosY,
                Width = src.Width,
                Height = src.Height,
                Name = src.Name,
                MachineId = src.MachineId,
                LineId = src.LineId,
            };
            return dst;
        }

        public static List<Position> LoadAll(SQLiteConnection db)
        {
            List<Position> data = new List<Position>();
            try
            {
                data = (db != null) ? db.Table<Position>().Where(v => v.id > 0).ToList() : data;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error LoadAll Position: {ex.Message.ToString()}");
            }
            return data;
        }
        public static int Insert(SQLiteConnection db, Position src)
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
                Console.WriteLine($"Error Insert Position: {ex.Message.ToString()}");
            }
            return rowId;
        }

        public static int Update(SQLiteConnection db, Position src)
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
                Console.WriteLine($"Error Update Position: {ex.Message.ToString()}");
            }
            return rowId;
        }

        #endregion
    }
}

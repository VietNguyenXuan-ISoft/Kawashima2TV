using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqliteDatabase.Models
{
//  CREATE TABLE "MaterialWaste" (
//	"id"	INTEGER NOT NULL,
//	"LineId"	INTEGER,
//	"MachineId"	INTEGER,
//	"Date"	TEXT,
//	"Shift"	TEXT,
//	"SKU"	INTEGER,
//	"Type"	TEXT,
//	"FGs"	TEXT,
//	"Quantity"	TEXT,
//	"Reason"	TEXT,
//	"UoM"	TEXT,
//	"Spare01"	TEXT,
//	"Spare02"	TEXT,
//	"Spare03"	TEXT,
//	PRIMARY KEY("id" AUTOINCREMENT)
//);
  //public class MaterialWaste
  //{
  //  [PrimaryKey, AutoIncrement]
  //  public int Id { get; set; }
  //  public int LineId { get; set; }
  //  public int MachineId { get; set; }
  //  public string Date { get; set; }
  //  public string Shift { get; set; }
  //  public string SKU { get; set; }
  //  public string Type { get; set; }
  //  public int FGs { get; set; }
  //  public string Quantity { get; set; }
  //  public string Reason { get; set; }
  //  public string UoM { get; set; }
  //  public string Spare01 { get; set; }
  //  public string Spare02 { get; set; }
  //  public string Spare03 { get; set; }

  //  public MaterialWaste()
  //  {

  //  }
  //  public static List<MaterialWaste> LoadAll(SQLiteConnection db)
  //  {
  //    List<MaterialWaste> data = new List<MaterialWaste>();
  //    try
  //    {
  //      data = (db != null) ? db.Table<MaterialWaste>().Where(v => v.Id > 0).ToList() : data;
  //    }
  //    catch
  //    {
  //    }
  //    return data;
  //  }

  //  public static int Insert(SQLiteConnection db, MaterialWaste src)
  //  {
  //    return ((db != null) ? db.Insert(src) : -1);
  //  }

  //  public static int Update(SQLiteConnection db, MaterialWaste src)
  //  {
  //    return ((db != null) ? db.Update(src) : -1);
  //  }
  //}
}

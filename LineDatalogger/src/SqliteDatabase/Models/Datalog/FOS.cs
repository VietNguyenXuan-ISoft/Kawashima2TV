using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace SqliteDatabase.Models.Datalog
{
    //  CREATE TABLE "FOS" (
    //	"id"	INTEGER NOT NULL,
    //	"MachineId"	INTEGER,
    //	"DateTime"	TEXT,
    //	"Shift"	INTEGER,
    //	"Van_hanh_may"	TEXT,
    //	"An_toan"	TEXT,
    //	"An_toan_ghi_chu"	TEXT,
    //	"San_pham_description"	TEXT,
    //	"San_pham_date_code"	TEXT,
    //	"San_luong_theo_ke_hoach_1_Gio"	TEXT,
    //	"San_luong_theo_toc_do_chuan_1_Gio"	TEXT,
    //	"San_luong_theo_gio_01"	TEXT,
    //	"San_luong_theo_gio_02"	TEXT,
    //	"San_luong_theo_gio_03"	TEXT,
    //	"San_luong_theo_gio_04"	TEXT,
    //	"San_luong_theo_gio_05"	TEXT,
    //	"San_luong_theo_gio_06"	TEXT,
    //	"San_luong_theo_gio_07"	TEXT,
    //	"San_luong_theo_gio_08"	TEXT,
    //	"San_luong_vs_ke_hoach"	TEXT,
    //	"San_luong_vs_toc_do_chuan"	TEXT,
    //	"Ton_that_bao_bi"	TEXT,
    //	"Thoi_gian_chuyen_doi"	TEXT,
    //	"Spare_02"	TEXT,
    //	"Spare_03"	TEXT,
    //	"Spare_04"	TEXT,
    //	"createId"	INTEGER,
    //	"updateId"	INTEGER,
    //	"created"	TEXT,
    //	"updated"	TEXT,
    //	PRIMARY KEY("id" AUTOINCREMENT)
    //);
    public class FOS
    {
        #region Models
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }
        public int MachineId { get; set; }
        public string DateTime { get; set; }
        public int Shift { get; set; }
        public string Van_hanh_may { get; set; }
        public string An_toan { get; set; }
        public string An_toan_ghi_chu { get; set; }
        public string San_pham_description { get; set; }
        public string San_pham_date_code { get; set; }
        public string San_luong_theo_ke_hoach_1_Gio { get; set; }
        public string San_luong_theo_toc_do_chuan_1_Gio { get; set; }
        public string San_luong_theo_gio_01 { get; set; }
        public string San_luong_theo_gio_02 { get; set; }
        public string San_luong_theo_gio_03 { get; set; }
        public string San_luong_theo_gio_04 { get; set; }
        public string San_luong_theo_gio_05 { get; set; }
        public string San_luong_theo_gio_06 { get; set; }
        public string San_luong_theo_gio_07 { get; set; }
        public string San_luong_theo_gio_08 { get; set; }
        public string San_luong_vs_ke_hoach { get; set; }
        public string San_luong_vs_toc_do_chuan { get; set; }
        public string Ton_that_bao_bi { get; set; }
        public string Thoi_gian_chuyen_doi { get; set; }
        public string Spare_02 { get; set; }
        public string Spare_03 { get; set; }
        public string Spare_04 { get; set; }
        public int createId { get; set; }
        public int updateId { get; set; }
        public string created { get; set; }
        public string updated { get; set; }
        //	PRIMARY KEY("id" AUTOINCREMENT)


        #endregion
        #region Methods
        private static FOS Clone(FOS src)
        {
            FOS dst = new FOS()
            {
                id = src.id,
                MachineId = src.MachineId,
                DateTime = src.DateTime,
                Shift = src.Shift,
                Van_hanh_may = src.Van_hanh_may,
                An_toan = src.An_toan,
                An_toan_ghi_chu = src.An_toan_ghi_chu,
                San_pham_description = src.San_pham_description,
                San_pham_date_code = src.San_pham_date_code,
                San_luong_theo_ke_hoach_1_Gio = src.San_luong_theo_ke_hoach_1_Gio,
                San_luong_theo_toc_do_chuan_1_Gio = src.San_luong_theo_toc_do_chuan_1_Gio,
                San_luong_theo_gio_01 = src.San_luong_theo_gio_01,
                San_luong_theo_gio_02 = src.San_luong_theo_gio_02,
                San_luong_theo_gio_03 = src.San_luong_theo_gio_03,
                San_luong_theo_gio_04 = src.San_luong_theo_gio_04,
                San_luong_theo_gio_05 = src.San_luong_theo_gio_05,
                San_luong_theo_gio_06 = src.San_luong_theo_gio_06,
                San_luong_theo_gio_07 = src.San_luong_theo_gio_07,
                San_luong_theo_gio_08 = src.San_luong_theo_gio_08,
                San_luong_vs_ke_hoach = src.San_luong_vs_ke_hoach,
                San_luong_vs_toc_do_chuan = src.San_luong_vs_toc_do_chuan,
                Ton_that_bao_bi = src.Ton_that_bao_bi,
                Thoi_gian_chuyen_doi = src.Thoi_gian_chuyen_doi,
                Spare_02 = src.Spare_02,
                Spare_03 = src.Spare_03,
                Spare_04 = src.Spare_04,
                createId = src.createId,
                updateId = src.updateId,
                created = src.created,
                updated = src.updated,
            };
            return dst;
        }

        public static List<FOS> LoadAll(SQLiteConnection db)
        {
            List<FOS> data = new List<FOS>();
            try
            {
                data = (db != null) ? db.Table<FOS>().Where(v => v.id > 0).ToList() : data;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error LoadAll FOS: {ex.Message.ToString()}");
            }
            return data;
        }
        public static int Insert(SQLiteConnection db, FOS src)
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
                Console.WriteLine($"Error Insert FOS: {ex.Message.ToString()}");
            }
            return rowId;
        }

        public static int Update(SQLiteConnection db, FOS src)
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
                Console.WriteLine($"Error Update FOS: {ex.Message.ToString()}");
            }
            return rowId;
        }

        #endregion


    }
}

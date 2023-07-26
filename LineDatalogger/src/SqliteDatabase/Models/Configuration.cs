using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace SqliteDatabase.Models
{
    /*
	CREATE TABLE "Configuration" (
	"id"	INTEGER,
	"LineId"	INTEGER,
	"FactoryId"	INTEGER,
	"LineName"	TEXT,
	"PLC_IPAddress"	TEXT,
	"Database_path"	TEXT,
	"Template_path"	TEXT,
	"IsUsed"	INTEGER,
	"CurrentBarcodeChoseFile"	TEXT,
	"LossTemplate"	TEXT,
	"LossReportPath"	TEXT,
	"SummaryPM_EWOPath"	TEXT,
	"SingleFilePM_EWOPath"	TEXT,
	"Product_Plan_Folder"	TEXT,
	"DailyProductionMachineCode"	TEXT,
	"LastFGs"	TEXT,
	"LastSKU"	INTEGER,
	"Spare01"	INTEGER,
	"Spare02"	INTEGER,
	"Spare03"	INTEGER,
	"IsEnableBarcode"	INTEGER,
	"IsEnableEmail"	INTEGER,
	"CommunicationProtocol"	INTEGER,
	"IsBarcodeScanDone"	INTEGER,
	"NetworkProductionPlanPath"	TEXT,
	"NetworkBarcodePath"	TEXT,
	"BarcodeFileDatetime"	TEXT,
	"IsEnableActiveDeactiveSKU"	INTEGER,
	"TimeToSendMailQuicklyReport"	INTEGER,
	"updated"	TEXT,
	"createId"	INTEGER,
	"updateId"	INTEGER,
	"created"	TEXT,
	"IsEnableMettlerToldeoICS425"	INTEGER,
	"Port"	INTEGER,
	"DurationToSendMailSpeedLoss"	INTEGER,
	"IsEnableAssignLossFromVirtualMachine"	INTEGER,
	"IsEnableCheckList"	INTEGER,
	"DfosDatabasePath"	TEXT,
	"DfosDatabaseTimingUpdated"	INTEGER,
	PRIMARY KEY("id" AUTOINCREMENT)
);*/

    public class Configuration : Entity
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public int LineId { get; set; }
        public int FactoryId { get; set; }
        public string LineName { get; set; }
        public string PLC_IPAddress { get; set; }
        public string Database_path { get; set; }
        public string Template_path { get; set; }
        public int IsUsed { get; set; }
        public string CurrentBarcodeChoseFile { get; set; }
        public string LossTemplate { get; set; }
        public string LossReportPath { get; set; }
        public string SummaryPM_EWOPath { get; set; }
        public string SingleFilePM_EWOPath { get; set; }
        public string Product_Plan_Folder { get; set; }
        public string DailyProductionMachineCode { get; set; }
        public string LastFGs { get; set; }
        public int LastSKU { get; set; }
        public int Spare01 { get; set; }
        public int Spare02 { get; set; }
        public int Spare03 { get; set; }
        public int IsEnableBarcode { get; set; }
        public int IsEnableEmail { get; set; }
        public int CommunicationProtocol { get; set; }
        public int IsBarcodeScanDone { get; set; }
        public string NetworkProductionPlanPath { get; set; }
        public string NetworkBarcodePath { get; set; }
        public string BarcodeFileDatetime { get; set; }
        public int IsEnableActiveDeactiveSKU { get; set; }
        public int TimeToSendMailQuicklyReport { get; set; }
        public string updated { get; set; }
        public int createId { get; set; }
        public int updateId { get; set; }
        public string created { get; set; }
        public int IsEnableMettlerToldeoICS425 { get; set; }
        public int Port { get; set; }
        public int DurationToSendMailSpeedLoss { get; set; }
        public int IsEnableAssignLossFromVirtualMachine { get; set; }
        public int IsEnableCheckList { get; set; }
        public string DfosDatabasePath { get; set; }
        public int DfosDatabaseTimingUpdated { get; set; }

        private List<Machines> _machines = new List<Machines>();
        private int _commId = 0;
        public Configuration()
        {

        }

        public void SetMachines(List<Machines> machines)
        {
            this._machines = machines;
        }

        public List<Machines> GetMachines()
        {
            return this._machines;
        }

        public void SetCommId(int commId)
        {
            this._commId = commId;
        }

        public int GetCommId()
        {
            return this._commId;
        }

        public static List<Configuration> LoadAll(SQLiteConnection db)
        {
            List<Configuration> data = new List<Configuration>();
            try
            {
                data = (db != null) ? db.Table<Configuration>().Where(v => v.Id > 0).ToList() : data;

            }
            catch (Exception ex)
            {
                string err = $"Error LoadAll Configuration: {ex.Message.ToString()}";
                Console.WriteLine(err);
                using (System.IO.StreamWriter w = System.IO.File.AppendText("log1.txt"))
                {
                    Log($"[Configuration] error: {err}", w);
                }
            }
            return data;
        }

        private static Configuration Clone(Configuration src)
        {
            Configuration dst = new Configuration()
            {
                Id = src.Id,
                LineId = src.LineId,
                FactoryId = src.FactoryId,
                LineName = src.LineName,
                PLC_IPAddress = src.PLC_IPAddress,
                Database_path = src.Database_path,
                Template_path = src.Template_path,
                IsUsed = src.IsUsed,
                CurrentBarcodeChoseFile = src.CurrentBarcodeChoseFile,
                LossTemplate = src.LossTemplate,
                LossReportPath = src.LossReportPath,
                SummaryPM_EWOPath = src.SummaryPM_EWOPath,
                SingleFilePM_EWOPath = src.SingleFilePM_EWOPath,
                Product_Plan_Folder = src.Product_Plan_Folder,
                DailyProductionMachineCode = src.DailyProductionMachineCode,
                LastFGs = src.LastFGs,
                LastSKU = src.LastSKU,
                Spare01 = src.Spare01,
                Spare02 = src.Spare02,
                Spare03 = src.Spare03,
                IsEnableBarcode = src.IsEnableBarcode,
                IsEnableEmail = src.IsEnableEmail,
                CommunicationProtocol = src.CommunicationProtocol,
                IsBarcodeScanDone = src.IsBarcodeScanDone,
                NetworkProductionPlanPath = src.NetworkProductionPlanPath,
                NetworkBarcodePath = src.NetworkBarcodePath,
                BarcodeFileDatetime = src.BarcodeFileDatetime,
                IsEnableActiveDeactiveSKU = src.IsEnableActiveDeactiveSKU,
                TimeToSendMailQuicklyReport = src.TimeToSendMailQuicklyReport,
                updated = src.updated,
                createId = src.createId,
                updateId = src.updateId,
                created = src.created,
                IsEnableMettlerToldeoICS425 = src.IsEnableMettlerToldeoICS425,
                Port = src.Port,
                DurationToSendMailSpeedLoss = src.DurationToSendMailSpeedLoss,
                IsEnableAssignLossFromVirtualMachine = src.IsEnableAssignLossFromVirtualMachine,
                IsEnableCheckList = src.IsEnableCheckList,
                DfosDatabasePath = src.DfosDatabasePath,
                DfosDatabaseTimingUpdated = src.DfosDatabaseTimingUpdated,
            };
            return dst;
        }
        public static int Insert(SQLiteConnection db, Configuration src)
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
                Console.WriteLine($"Error Insert Configuration: {ex.Message.ToString()}");
            }

            return rowId;
        }

        public static int Update(SQLiteConnection db, Configuration src)
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
                Console.WriteLine($"Error Update Configuration: {ex.Message.ToString()}");
            }
            return rowId;
        }
    }
}

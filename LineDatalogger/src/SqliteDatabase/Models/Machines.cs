using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace SqliteDatabase.Models
{
//  CREATE TABLE "Machines" (
//	"id"	INTEGER NOT NULL,
//	"LineId"	INTEGER,
//	"MachineId"	INTEGER,
//	"MachineName"	TEXT,
//	"ChangeOverDefault"	INTEGER,
//	"ReportFile"	TEXT,
//	"ReportSheet"	INTEGER,
//	"IsUseLocalCounter"	INTEGER,
//	"IsUseForFOS"	INTEGER,
//	"IsMainMachine"	INTEGER,
//	"Spare01"	INTEGER,
//	"Spare02"	INTEGER,
//	"IsUsed"	INTEGER,
//	"IsSendMailGroup1"	INTEGER,
//	"IsSendMailGroup2"	INTEGER,
//	"IsSendMailGroup3"	INTEGER,
//	"IsSendMailGroup4"	INTEGER,
//	"IsChangeoverInProgress"	INTEGER,
//	"DefaultOEE"	TEXT,
//	"createId"	INTEGER,
//	"updateId"	INTEGER,
//	"created"	TEXT,
//	"updated"	TEXT,
//	"TotalLossCounting"	INTEGER,
//	"IsSupportEOL"	INTEGER,
//	"IsEOL_Palletizer"	INTEGER,
//	"IsSendMailSpeedLoss"	INTEGER,
//	"IsEnableInterLock"	INTEGER,
//	PRIMARY KEY("id" AUTOINCREMENT)
//);
  public class Machines
  {
    #region Model
    [PrimaryKey, AutoIncrement]
    public int id { get; set; }
    public int LineId{ get; set; }
    public int MachineId{ get; set; }
    public string MachineName{ get; set; }
    public int ChangeOverDefault{ get; set; }
    public string ReportFile{ get; set; }
    public int ReportSheet{ get; set; }
    public int IsUseLocalCounter{ get; set; }
    public int IsUseForFOS{ get; set; }
    public int IsMainMachine{ get; set; }
    public int Spare01{ get; set; }
    public int Spare02{ get; set; }
    public int IsUsed{ get; set; }
    public int IsSendMailGroup1{ get; set; }
    public int IsSendMailGroup2{ get; set; }
    public int IsSendMailGroup3{ get; set; }
    public int IsSendMailGroup4{ get; set; }
    public int IsChangeoverInProgress{ get; set; }
    public int DefaultOEE{ get; set; }
    public int createId{ get; set; }
    public int updateId{ get; set; }
    public string created{ get; set; }
    public string updated { get; set; }
    public int TotalLossCounting{ get; set; }
    public int IsSupportEOL{ get; set; }
    public int IsEOL_Palletizer{ get; set; }
    public int IsSendMailSpeedLoss{ get; set; }
    public int IsEnableInterLock{ get; set; }
    #endregion


    private int _CounterIN = 0;

    private int _CounterOUT =  0;

    private int _FOS_Counter1 = 0;

    private int _FOS_Counter2 = 0;

    private int _FOS_Counter3 = 0;

    private int _FOS_Counter4 = 0;

    private int _FOS_Counter5 = 0;

    private int _FOS_Counter6 = 0;

    private int _FOS_Counter7 = 0;

    private int _FOS_Counter8 = 0;

    private int _CurrentSpeed = 0;
    private int _CurrentLossCode = 0;
    private int _LossLog_CurrentItem = 0;
    private int _Status = 0;
    private int _LineId = 0;
    private int _MachineId = 0;
    private int _LossDuration = 0;
    private int _StateMachine = 0;
    private bool _is_error = false;


    private DateTime _last_update = DateTime.Now;

    public void SetCounterIN(int value)
    {
      _CounterIN = value;
    }

    public void SetCounterOUT(int value)
    {
      _CounterOUT = value;
    }

    public void SetFOS_Counter1(int value)
    {
      _FOS_Counter1 = value;
    }

    public void SetFOS_Counter2(int value)
    {
      _FOS_Counter2 = value;
    }

    public void SetFOS_Counter3(int value)
    {
      _FOS_Counter3 = value;
    }

    public void SetFOS_Counter4(int value)
    {
      _FOS_Counter4 = value;
    }

    public void SetFOS_Counter5(int value)
    {
      _FOS_Counter5 = value;
    }

    public void SetFOS_Counter6(int value)
    {
      _FOS_Counter6 = value;
    }

    public void SetFOS_Counter7(int value)
    {
      _FOS_Counter7 = value;
    }

    public void SetFOS_Counter8(int value)
    {
      _FOS_Counter8 = value;
    }

    public void SetCurrentSpeed(int value)
    {
      _CurrentSpeed = value;
    }
    public void SetCurrentLossCode(int value)
    {
      _CurrentLossCode = value;
    }
    public void SetLossLog_CurrentItem(int value)
    {
      _LossLog_CurrentItem = value;
    }
    public void SetStatus(int value)
    {
      _Status = value;
    }
    public void SetLineId(int value)
    {
      LineId = value;
    }
    public void SetMachineId(int value)
    {
      MachineId = value;
    }
    public void SetLossDuration(int value)
    {
      _LossDuration = value;
    }
    public void SetStateMachine(int value)
    {
      _StateMachine = value;
    }

    public void SetLastUpdate(DateTime datetime)
    {
      this._last_update = datetime;
    }

    public void SetError(bool error)
    {
      this._is_error = error;
    }
    public int GetCounterIN(){return _CounterIN;}

    public int GetCounterOUT()
    { return _CounterOUT; }

    public int GetFOS_Counter1() { return _FOS_Counter1; }

    public int GetFOS_Counter2() { return _FOS_Counter2; }

    public int GetFOS_Counter3() { return _FOS_Counter3; }

    public int GetFOS_Counter4() { return _FOS_Counter4; }

    public int GetFOS_Counter5() { return _FOS_Counter5; }

    public int GetFOS_Counter6() { return _FOS_Counter6; }

    public int GetFOS_Counter7() { return _FOS_Counter7; }

    public int GetFOS_Counter8() { return _FOS_Counter8; }

    public int GetCurrentSpeed() { return _CurrentSpeed; }
    public int GetCurrentLossCode() { return _CurrentLossCode; }
    public int GetLossLog_CurrentItem() { return _LossLog_CurrentItem; }
    public int GetStatus() { return _Status; }
    public int GetLineId() { return _LineId; }
    public int GetMachineId() { return _MachineId; }
    public int GetLossDuration() { return _LossDuration; }
    public int GetStateMachine() { return _StateMachine; }
    public DateTime GetLastUpdate() { return this._last_update; }

    public bool GetError() { return this._is_error; }

    #region Methods
    public static Machines Clone(Machines src)
    {
      Machines dst = new Machines()
      {
        id = src.id,
        LineId = src.LineId,
        MachineId = src.MachineId,
        MachineName = src.MachineName,
        ChangeOverDefault = src.ChangeOverDefault,
        ReportFile = src.ReportFile,
        ReportSheet = src.ReportSheet,
        IsUseLocalCounter = src.IsUseLocalCounter,
        IsUseForFOS = src.IsUseForFOS,
        IsMainMachine = src.IsMainMachine,
        Spare01 = src.Spare01,
        Spare02 = src.Spare02,
        IsUsed = src.IsUsed,
        IsSendMailGroup1 = src.IsSendMailGroup1,
        IsSendMailGroup2 = src.IsSendMailGroup2,
        IsSendMailGroup3 = src.IsSendMailGroup3,
        IsSendMailGroup4 = src.IsSendMailGroup4,
        IsChangeoverInProgress = src.IsChangeoverInProgress,
        DefaultOEE = src.DefaultOEE,
        createId = src.createId,
        updateId = src.updateId,
        created = src.created,
        updated = src.updated,
        TotalLossCounting = src.TotalLossCounting,
        IsSupportEOL = src.IsSupportEOL,
        IsEOL_Palletizer = src.IsEOL_Palletizer,
        IsSendMailSpeedLoss = src.IsSendMailSpeedLoss,
        IsEnableInterLock = src.IsEnableInterLock,
      };
      return dst;
    }

    public static List<Machines> LoadAll(SQLiteConnection db)
    {
      List<Machines> data = new List<Machines>();
      try
      {
        data = (db != null) ? db.Table<Machines>().Where(v => v.id > 0).ToList():data;
      }
      catch (Exception ex)
      {
        Console.WriteLine($"Error LoadAll Machines: {ex.Message.ToString()}");
      }
      return data;
    }
    public static int Insert(SQLiteConnection db, Machines src)
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
        Console.WriteLine($"Error Insert Machines: {ex.Message.ToString()}");
      }

      return rowId;
    }
    // Returns:
    //     The number of rows updated.
    public static int Update(SQLiteConnection db, Machines src)
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
        Console.WriteLine($"Error Update Machines: {ex.Message.ToString()}");
      }
      return rowId;
    }

    #endregion
  }
}

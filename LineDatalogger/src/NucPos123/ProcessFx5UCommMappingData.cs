using SqliteDatabase.Models;
using SqliteDatabase.Models.Datalog;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace NucPos123
{
  public partial class frmMain
  {
    private void SaveDatalog_DoWork(int comId)
    {
      if (is_load_config_done == true)
      {
        Configuration configuration = list_configurations.Find(x => x.GetCommId() == comId);
        if (comId == 5)
        {
          int mmm = 0;
        }
        if (configuration != null)
        {
          int second = DateTime.Now.Second;// > 30 ? 30 : 0;
          string database_path = ($"C:\\Dfos\\{configuration.LineName}");
          DateTime dt = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, DateTime.Now.Minute, second);
          string datalog_file_name = Path.Combine(database_path, String.Format("{0}_{1}.s3db", dt.ToString("yyyyMMdd"), "datalog"));
          SqliteDatabase.SqliteDataLogContext context = new SqliteDatabase.SqliteDataLogContext(datalog_file_name, "");

          string FGs = "FGs";
          string SKU = "SKU";
          string Target_speed = "";
          string Actual_speed = "";
          string Target_counter = "";
          string Actual_counter = "";
          string Actual_counterIN = "";
          string Target_Temperature = "";
          string Actual_Temperature = "";
          string Template_path = "";
          string Database_path = "";
          string OperatorNames = "";
          string LossCodeAllMachines = "";
          string TemperatureAllMachines = "";
          
          string StatemachineAlMachins = "";
          int CounterAllLine = 0;
          List<Machines> all_machines = configuration.GetMachines().FindAll(x => x.IsUsed.ToBool() == true);


          for (int i = 0; i < all_machines.Count; i++)
          {
            Machines machine = all_machines[i];
            if (machine.IsMainMachine.ToBool() == true)
            {
              CounterAllLine = machine.GetCounterOUT();
            }
            if (i == all_machines.Count - 1)
            {
              Actual_speed += machine.GetCurrentSpeed().ToString();
              Actual_counter += machine.GetCounterOUT().ToString();
              Actual_counterIN += machine.GetCounterIN().ToString();
              LossCodeAllMachines += machine.GetCurrentLossCode().ToString();
#if enable_statemachines
              StatemachineAlMachins += machine.GetStateMachine().ToString();
#else
              StatemachineAlMachins += 0.ToString();
        
#endif
            }
            else
            {
              Actual_speed += machine.GetCurrentSpeed().ToString() + "@";
              Actual_counter += machine.GetCounterOUT().ToString() + "@";
              Actual_counterIN += machine.GetCounterIN().ToString() + "@";
              LossCodeAllMachines += machine.GetCurrentLossCode().ToString() + "@";
#if enable_statemachines
              StatemachineAlMachins += machine.GetStateMachine().ToString() + "@";
#else
              StatemachineAlMachins += 0.ToString() + "@";
        
#endif
            }
          }

          SqliteDatabase.Models.Datalog.data_log dst = new SqliteDatabase.Models.Datalog.data_log()
          {
            LineId = configuration.LineId,
            DateTime = dt.ToyyyyMMddHHmmss(),
            Shift = (int)GetShift(),
            FGs = FGs,
            SKU = 0,
            Target_speed = Target_speed,
            Actual_speed = Actual_speed,
            Target_counter = Target_counter,
            Actual_counter = Actual_counter,
            Target_Temperature = Target_Temperature,
            Actual_Temperature = Actual_Temperature,
            Operators = OperatorNames,
            CounterAllLine = CounterAllLine,
            Actual_counterIN = Actual_counterIN,
            Spare01 = LossCodeAllMachines,
            Spare02 = StatemachineAlMachins,
            Spare03 = "",
            //Spare04 = data_log.Spare04,
            //Spare05 = data_log.Spare05,
            //createId = src.createId,
            //updateId = src.updateId,
            //created = src.created,
            //updated = src.updated,
          };
          //try
          {
            context.Insert(dst);
          }
          //catch
          //{
          //}
          context.Close();
        }
      }
    }
    private void SaveDatalog_ProgressChanged(int comId)
    {

    }

    private void SaveDatalog_RunWorkerCompleted(int comId)
    {

    }


    //private bool SetStatus(int comId, bool is_error, List<FX_DATA> list_data)
    //{
    //  bool is_need_save_datalog = false;
    //  Color back_color = is_error ? Color.Red : Color.Green;
    //  Color fore_color = is_error ? Color.White : Color.White;
    //  //find Config
    //  Configuration configuration = list_configurations.Find(x => x.GetCommId() == comId);
    //  if (configuration != null)
    //  {
    //    if (this.lblLineName.Text == configuration.LineName)
    //    {
    //      this.lblLineName.BackColor= back_color;
    //      this.lblLineName.ForeColor = fore_color;
    //    }
    //    if (is_error == false)
    //    {
    //      //----------------------------------
    //      foreach (Machines machine in configuration.GetMachines())
    //      {
    //        int machineId = machine.id;
    //        int start_address = 300 + (machineId - 1) * 30;// + (machineId - 1) * 300;
    //        int CounterIN = GetValue(list_data, start_address, 2);
    //        int CounterOUT = GetValue(list_data, start_address + 2, 2);
    //        //-----------------------------------
    //        int FOS_Counter1 = GetValue(list_data, start_address + 4, 2);
    //        int FOS_Counter2 = GetValue(list_data, start_address + 6, 2);
    //        int FOS_Counter3 = GetValue(list_data, start_address + 8, 2);
    //        int FOS_Counter4 = GetValue(list_data, start_address + 10, 2);
    //        int FOS_Counter5 = GetValue(list_data, start_address + 12, 2);
    //        int FOS_Counter6 = GetValue(list_data, start_address + 14, 2);
    //        int FOS_Counter7 = GetValue(list_data, start_address + 16, 2);
    //        int FOS_Counter8 = GetValue(list_data, start_address + 18, 2);
    //        int CurrentSpeed = GetValue(list_data, start_address + 20, 1);
    //        int CurrentLossCode = GetValue(list_data, start_address + 21, 1);
    //        int LossLog_CurrentItem = GetValue(list_data, start_address + 22, 1);
    //        int Status = GetValue(list_data, start_address + 23, 1);
    //        int LineId = GetValue(list_data, start_address + 24, 1);
    //        int MachineId = GetValue(list_data, start_address + 25, 1);
    //        int LossDuration = GetValue(list_data, start_address + 26, 2);
    //        int StateMachine = GetValue(list_data, start_address, 2);
    //        //
    //        machine.SetCounterIN(CounterIN);
    //        machine.SetCounterOUT(CounterOUT);
    //        machine.SetFOS_Counter1(FOS_Counter1);
    //        machine.SetFOS_Counter2(FOS_Counter2);
    //        machine.SetFOS_Counter3(FOS_Counter3);
    //        machine.SetFOS_Counter4(FOS_Counter4);
    //        machine.SetFOS_Counter5(FOS_Counter5);
    //        machine.SetFOS_Counter6(FOS_Counter6);
    //        machine.SetFOS_Counter7(FOS_Counter7);
    //        machine.SetFOS_Counter8(FOS_Counter8);
    //        machine.SetCurrentSpeed(CurrentSpeed);
    //        machine.SetCurrentLossCode(CurrentLossCode);
    //        machine.SetLossLog_CurrentItem(LossLog_CurrentItem);
    //        machine.SetStatus(Status);
    //        //machine.SetLineId(LineId);
    //        //machine.SetMachineId(MachineId);
    //        machine.SetLossDuration(LossDuration);
    //        machine.SetStateMachine(StateMachine);
    //        machine.SetLastUpdate(DateTime.Now);
    //        machine.SetError(false);
    //        //
    //        bool is_exit = false;
    //        for (int i = 0; i < this.flowLayoutPanel1.Controls.Count && is_exit == false; i++)
    //        {
    //          if (this.flowLayoutPanel1.Controls[i] is SingleMachine)
    //          {
    //            SingleMachine singleMachine = (SingleMachine)(this.flowLayoutPanel1.Controls[i]);
    //            if (singleMachine.Tag != null)
    //            {
    //              if (singleMachine.Tag is Tuple<Configuration, Machines>)
    //              {
    //                Tuple<Configuration, Machines> tuple = (Tuple<Configuration, Machines>)(singleMachine.Tag);
    //                if (tuple.Item1.LineName == configuration.LineName)
    //                {
    //                  if (tuple.Item2.id == machine.id)
    //                  {
    //                    singleMachine.CounterIn = machine.GetCounterIN();
    //                    singleMachine.CounterOut = machine.GetCounterOUT();
    //                    singleMachine.Speed = machine.GetCurrentSpeed();
    //                    singleMachine.SetLastUpdate(machine.GetLastUpdate());
    //                    singleMachine.SetStatemachine(StateMachine, CurrentLossCode, error: machine.GetError());
    //                    //-------------------------------------------------------
    //                    if (singleMachine.LastUpdate.Second % 30 == 0)
    //                    {
    //                      is_need_save_datalog = true;
    //                    }





    //                    //
    //                    is_exit = true;
    //                  }
    //                }
    //              }
    //            }
    //          }/*if (this.flowLayoutPanel1.Controls[i] is SingleMachine)*/
    //        }/*for (int i = 0; i < this.flowLayoutPanel1.Controls.Count; i++)*/

         
    //      }
    //    }
    //    else
    //    {
    //      foreach (Machines machine in configuration.GetMachines())
    //      {
    //        bool is_exit = false;
    //        for (int i = 0; i < this.flowLayoutPanel1.Controls.Count && is_exit == false; i++)
    //        {
    //          if (this.flowLayoutPanel1.Controls[i] is SingleMachine)
    //          {
    //            SingleMachine singleMachine = (SingleMachine)(this.flowLayoutPanel1.Controls[i]);
    //            if (singleMachine.Tag != null)
    //            {
    //              if (singleMachine.Tag is Tuple<Configuration, Machines>)
    //              {
    //                Tuple<Configuration, Machines> tuple = (Tuple<Configuration, Machines>)(singleMachine.Tag);
    //                if (tuple.Item1.LineName == configuration.LineName)
    //                {
    //                  if (tuple.Item2.id == machine.id)
    //                  {
    //                    machine.SetError(true);
    //                    singleMachine.SetStatemachine(machine.GetStateMachine(), machine.GetCurrentLossCode(), error: machine.GetError());


    //                    //
    //                    is_exit = true;
    //                  }
    //                }
    //              }
    //            }
    //          }/*if (this.flowLayoutPanel1.Controls[i] is SingleMachine)*/
    //        }
    //      }
    //    }
    //  }
    //  return is_need_save_datalog;
    //}

    //private void SetCounterOut(int comId, List<FX_DATA> list_data)
    //{
      
    //}

    private int GetValue(List<FX_DATA> list_data, int start_address, int len)
    {
      int ret = 0;
      if (len == 2)
      {
        FX_DATA msb = list_data.Find(x => x.address == start_address);
        FX_DATA lsb = list_data.Find(x => x.address == start_address + 1);
        if ((msb != null) && (lsb != null))
        {
          ret = (lsb.value) << 16 | msb.value;
        }
      }
      else
      {
        FX_DATA msb = list_data.Find(x => x.address == start_address);
        if (msb != null)
        {
          ret = (msb.value);
        }
      }
      return ret;
    }


    //private void SetStatus(Line line, bool is_error)
    //{
    //  Color back_color = is_error ? Color.Red : Color.White;
    //  Color fore_color = is_error ? Color.White : Color.Green;
    //  //if (line == Line.Posimat_1)
    //  //{
    //  //  this.lblPosimat1.BackColor = back_color;
    //  //  this.lblPosimat1.ForeColor = fore_color;
    //  //}
    //  //else if (line == Line.Posimat_2)
    //  //{
    //  //  this.lblPosimat2.BackColor = back_color;
    //  //  this.lblPosimat2.ForeColor = fore_color;
    //  //}
    //  //else if (line == Line.Posimat_3)
    //  //{
    //  //  this.lblPosimat3.BackColor = back_color;
    //  //  this.lblPosimat3.ForeColor = fore_color;
    //  //}
    //}
  }
}

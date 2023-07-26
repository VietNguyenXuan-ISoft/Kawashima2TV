using Mitsubishi.McProtocol;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace PlcMcProtocolController
{
  public class PlcController
  {
    public delegate void SendDataReceived(string ip_address, int blockIdex, int[] data, bool isEndBlock);
    public event SendDataReceived OnSendDataReceived;
    //
    private McProtocolClient mcClient_Pos1;
    private Timer _cyclicReadAfterReconnected_Pos1 = new Timer();

    private string _ip_address = "";
    private int _port = 0;

    private bool _is_Connecting_Pos1 = false;
    private bool _is_Connected_Pos1 = false;
    private int max_block = 0;

    BackgroundWorker savedatalog_backgroundWorker = new System.ComponentModel.BackgroundWorker();
    public PlcController(string ipAdress, int port)
    {
      this._ip_address = ipAdress;
      this._port = port;
      //
      //savedatalog_backgroundWorker.WorkerReportsProgress = true;
      //savedatalog_backgroundWorker.WorkerSupportsCancellation = true;
      //savedatalog_backgroundWorker.DoWork += Savedatalog_backgroundWorker_DoWork;
      //savedatalog_backgroundWorker.RunWorkerCompleted += Savedatalog_backgroundWorker_RunWorkerCompleted;
      //savedatalog_backgroundWorker.ProgressChanged += Savedatalog_backgroundWorker_ProgressChanged;
    }

    //private void Savedatalog_backgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
    //{
    //  throw new NotImplementedException();
    //}

    //private void Savedatalog_backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    //{
    //  throw new NotImplementedException();
    //}

    //private void Savedatalog_backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
    //{
    //  throw new NotImplementedException();
    //}

    //public 
    private void McClient_NotifyEvent(object sender, Notify notify)
    {
      //string lblControllerStatus_Text = "";
      //Color lblControllerStatus_ForeColor = Color.Black;
      //bool _station_Enable = false;
      Console.WriteLine($"McClient_NotifyEvent : {this._ip_address}, port {this._port}, {notify.ToString()}");
      WriteLog($"McClient_NotifyEvent : {this._ip_address}, port {this._port}, {notify.ToString()}");
      if (notify == Notify.Connecting)
      {
        _is_Connecting_Pos1 = true;
      }
      if (notify == Notify.Connected)
      {
        _is_Connected_Pos1 = (notify == Notify.Connected);
      }

      if (notify == Notify.Connected)
      {
        //lblControllerStatus_Text = $"Online";
        //lblControllerStatus_ForeColor = Color.Green;
        //_station_Enable = true;

        //WriteSettingToPlc();
      }
      else if (notify == Notify.Disconnected)
      {
        //lblControllerStatus_Text = $"Offline";
        //lblControllerStatus_ForeColor = Color.Red;
        //_station_Enable = false;
      }
      else if (notify == Notify.Connecting)
      {
        //lblControllerStatus_ForeColor = Color.Orange;
        //lblControllerStatus_Text = $"{notify}";
        //_station_Enable = false;
      }
      else if ((notify == Notify.ConnectionTimedOut) || (notify == Notify.ReadTimedOut))
      {
        this._cyclicReadAfterReconnected_Pos1.Enabled = false;
      }
      //if (lblControllerStatus_Text != "")
      //  this?.Invoke((MethodInvoker)delegate
      //  {
      //    this.lblControllerStatus.Text = lblControllerStatus_Text;
      //    this.lblControllerStatus.ForeColor = lblControllerStatus_ForeColor;
      //    this._station.Enable = _station_Enable;
      //  });

      //Debug.WriteLine("McClient_NotifyEvent", $"{notify}");
      if ((_is_Connecting_Pos1 == true) && (_is_Connected_Pos1 == true))
      {
        //this?.Invoke((MethodInvoker)delegate
        //{
        //  this._cyclicReadAfterReconnected_Pos1.Enabled = true;
        //  _is_Connecting_Pos1 = false;
        //  _is_Connected_Pos1 = false;
        //});
      }
    }
    private void McClient_AutoReadRecivedEvent(object sender, DeviceBlock dataInfo, int[] data)
    {
      try
      {
       // this?.Invoke((MethodInvoker)delegate
        {
          //_station.SyncMemory(data); //call all event
          //Console.WriteLine($"length: {data.Length}");
         // WriteLog($"McClient_AutoReadRecivedEvent : {this._ip_address}, port {this._port}, Address: {dataInfo.Address.ToString()},length:{data.Length}, machine {dataInfo.Index} ");

          for(int i = 0; i < data.Length; i++)
          {
           // Console.WriteLine($"value: {iem}");
            //WriteLog($"===========================> : {this._ip_address}, port {this._port}, machine {dataInfo.Index}: D{i}: {data[i]} ");
          }
          //
          if (data.Length >= dataInfo.Length)
          {

            // WriteLog($"===========================> : {this._ip_address}, port {this._port}, Machine_CounterOUT {data[3]}, {data[2]} ==> {data[3] << 16 | data[2]} ==>  {data[2] << 16 | data[3]}");
            //int Machine_CounterIN = data[1] << 16 | data[0];
            //int Machine_CounterOUT = data[3] << 16 | data[2];

            //Machine_CounterIN = (Machine_CounterIN < 0)? (-1) * Machine_CounterIN: Machine_CounterIN;
            //Machine_CounterOUT = (Machine_CounterOUT < 0) ? (-1) * Machine_CounterOUT : Machine_CounterOUT;

           
            ////int Machine_CounterIN = data[0] << 16 | data[1];
            ////int Machine_CounterOUT = data[2] << 16 | data[3];

            //int Machine_FOS_Counter1 = data[5] << 16 | data[4];
            //int Machine_FOS_Counter2 = data[7] << 16 | data[6];
            //int Machine_FOS_Counter3 = data[9] << 16 | data[8];
            //int Machine_FOS_Counter4 = data[11] << 16 | data[10];
            //int Machine_FOS_Counter5 = data[13] << 16 | data[12];
            //int Machine_FOS_Counter6 = data[15] << 16 | data[14];
            //int Machine_FOS_Counter7 = data[17] << 16 | data[16];
            //int Machine_FOS_Counter8 = data[19] << 16 | data[18];
            //int Machine_CurrentSpeed = data[20];
            //int Machine_CurrentLossCode = data[21];
            //int Machine_LossLog_CurrentItem = data[22];
            //int Machine_Status = data[23];
            //int Machine_LineId = data[24];
            //int Machine_MachineId = data[25];
            //int Machine_LossDuration = data[27] << 16 | data[26];
            //int Machine_StateMachine = data[28];
            //Search correct lineId, machineId by Ip
            if (OnSendDataReceived != null)
            {
              OnSendDataReceived(this._ip_address, dataInfo.Index, data, (dataInfo.Index == this.max_block));
            }
          }



          int mm = 0;
        };
      }
      catch
      {

      }
      //AppCore.Def.Notify("mcClient1", sender);
    }

    private void McClient_Pos1_ReadDeviceBlockRecivedEvent(object sender, int[] data)
    {
      try
      {
        //this?.Invoke((MethodInvoker)delegate
        {
          //_station.SyncMemory(data); //call all event
          Console.WriteLine($"length: {data.Length}");
          foreach (int iem in data)
          {
            Console.WriteLine($"value: {iem}");
          }
          int mm = 0;
        };
      }
      catch
      {

      }
    }
    public async void Init(List<DeviceBlock> DeviceBlocks)
    {
      if (mcClient_Pos1 == null) mcClient_Pos1 = new McProtocolClient();
      mcClient_Pos1.NotifyEvent += new McProtocolClient.NotifydHandle(McClient_NotifyEvent);
      mcClient_Pos1.AutoReadRecivedEvent += new McProtocolApp.AutoReadRecivedHandle(McClient_AutoReadRecivedEvent);
      mcClient_Pos1.ReadDeviceBlockRecivedEvent += McClient_Pos1_ReadDeviceBlockRecivedEvent;
      mcClient_Pos1.HostName = this._ip_address;
      mcClient_Pos1.PortNumber = this._port;
      mcClient_Pos1.AutoReadDelay = 100;
      mcClient_Pos1.CommandFrame = McFrame.MC3E;
      //mcClient.AutoReconnect = ctrl.AutoConnect;

      //auto read
      mcClient_Pos1.EnableAutoRead = false;
      //
      List<DeviceBlock> deviceBlock = DeviceBlocks;// new List<DeviceBlock>() { new DeviceBlock(DeviceType.D, 700, 10) };
      this.max_block = DeviceBlocks.Max(x => x.Index);
      //
      mcClient_Pos1.AutoReadInit(deviceBlock);

      await mcClient_Pos1.Open();
      //
      mcClient_Pos1.StartAutoRead();
      mcClient_Pos1.AutoReconnect = true;
    }

    //public async void StartRead(List<DeviceBlock> DeviceBlocks)
    //{
    //  //List<DeviceBlock> deviceBlock = new List<DeviceBlock>() { new DeviceBlock(DeviceType.D, 700, 10) };
    //  mcClient_Pos1.AutoReadInit(DeviceBlocks);

    //}

    //private async Task ConnectToPlc_Pos1()
    //{
    //  //if (ctrl.AutoConnect && ctrl != null)
    //  {
    //    await mcClient_Pos1.Open();
    //    //
    //    mcClient_Pos1.StartAutoRead();
    //    mcClient_Pos1.AutoReconnect = true;
    //  }
    //}

    public async void DeInit()
    {
      if (mcClient_Pos1 != null)
      {
        mcClient_Pos1.Close();
      }
    }

    public static void WriteLog(string strLog)
    {
      string m_exePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
      string logFilePath = Path.Combine(m_exePath, "log.txt");
      FileInfo logFileInfo = new FileInfo(logFilePath);
      DirectoryInfo logDirInfo = new DirectoryInfo(logFileInfo.DirectoryName);
      if (!logDirInfo.Exists) logDirInfo.Create();
      using (FileStream fileStream = new FileStream(logFilePath, FileMode.Append))
      {
        using (StreamWriter log = new StreamWriter(fileStream))
        {
          log.WriteLine(strLog);
        }
      }
    }







  }
}

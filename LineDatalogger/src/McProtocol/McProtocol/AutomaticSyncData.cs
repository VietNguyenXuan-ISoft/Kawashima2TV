//#define test

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net.Sockets;
using System.Threading.Tasks;
using System.Timers;


namespace Mitsubishi.McProtocol
{

  public partial class McProtocolClient: McProtocolApp
  {
    //Automatic data synchronization between PC and PLC

    //Read from plc


    //#region Event AutoRead
    //public delegate void AutoReadRecivedHandle(object sender, PlcDataPackage dataInfo, int[] data);
    //public event AutoReadRecivedHandle AutoReadRecivedEvent;
    //#endregion

    #region Fields

    private bool autoReconnect = false;
    private int autoReadDelay = 100;
    private long totalReadCommand = 0;
    private long totalReadSuccessul = 0;
    private long totalReadFailed = 0;
    private long avgIntervalRead = 0;
    private long sumIntervalAutoRead;
    private long lastIntervalAutoRead = 0;
    private long lastAutoRead = 0;

    private long minIntervalAutoRead = 0;
    private long maxIntervalAutoRead;
    private int readIndex = 0;
    private bool enableAutoRead = false;


    private Timer autoReadTimer;
    private Timer reconnectTimer;
    private List<DeviceBlock> readDeviceBlocks = new List<DeviceBlock>();
    #endregion

    #region Public Properties
    /// <summary>
    /// Khoảng thời gian (ms) delay sau khi kết thúc lần đọc trước đó cho đến khi lần đọc liên tiếp theo được thực hiện.
    /// Default value 100 ms
    /// </summary>
    [Category("Auto Read")]
    public int AutoReadDelay
    {
      get => autoReadDelay;
      set { autoReadDelay = value; if (autoReadTimer != null) autoReadTimer.Interval = autoReadDelay; }
    }

    /// <summary>
    /// Tổng số lần gửi lệnh đọc
    /// </summary>
    [Browsable(false)]
    public long TotalReadCommand { get => totalReadCommand; set => totalReadCommand = value; }
    [Browsable(false)]
    public long TotalReadSuccessul { get => totalReadSuccessul; set => totalReadSuccessul = value; }
    [Browsable(false)]
    public long TotalReadFailed { get => totalReadFailed; set => totalReadFailed = value; }

    /// <summary>
    /// thời gian trung bình giữa 2 lần đọc
    /// </summary>
    [Browsable(false)]
    public long AvgIntervalAutoRead { get => avgIntervalRead; set => avgIntervalRead = value; }
    [Browsable(false)]
    public long LastIntervalAutoRead { get => lastIntervalAutoRead; set => lastIntervalAutoRead = value; }
    [Browsable(false)]
    public long MinIntervalAutoRead { get => minIntervalAutoRead; set => minIntervalAutoRead = value; }
    [Browsable(false)]
    public long MaxIntervalAutoRead { get => maxIntervalAutoRead; set => maxIntervalAutoRead = value; }

    [Category("Auto Read")]
    public bool EnableAutoRead { get => enableAutoRead; set => enableAutoRead = value; }

    [Category("Connection")]
    public bool AutoReconnect { get => autoReconnect; set => autoReconnect = value; }
    [Category("Auto Read")]
    public List<DeviceBlock> ReadDeviceBlocks { get => readDeviceBlocks; set => readDeviceBlocks = value; }
    #endregion

    #region Private Properties
    private long UnixTimeMilliseconds { get => DateTimeOffset.Now.ToUnixTimeMilliseconds(); }

    #endregion

    #region Methods
    public void Init()
    {
      if (reconnectTimer == null)
      {
        reconnectTimer = new Timer() { Interval = 1000, Enabled = true, AutoReset = false };
        reconnectTimer.Elapsed += ReconnectTimer_Elapsed;
        reconnectTimer.Start();
      }
    }


    private async void ReconnectTimer_Elapsed(object sender, ElapsedEventArgs e)
    {
      if (autoReconnect == true && this.Connected == false)
      {
        await Open();
      }
      var timer = sender as Timer;
      timer.Start();
    }

    public void AutoReadInit(List<DeviceBlock> readPackages)
    {
      if (autoReadTimer == null) autoReadTimer = new Timer() { Interval = autoReadDelay, Enabled = false, AutoReset = false };
      autoReadTimer.Elapsed += new ElapsedEventHandler(AutoReadTimer_Elapsed);
      //this.ReadDeviceBlockRecivedEvent += McProtocolTcp_ReadRecivedEvent;
      this.NotifyEvent += McProtocolTcp_NotifyEvent;
      this.AutoReadRecivedEvent += McProtocolTcp_AutoReadRecivedEvent;
      this.ReadDeviceBlocks = readPackages;
    }

    public void ResetCounter()
    {
      TotalReadCommand = 0;
      TotalReadFailed = 0;
      TotalReadSuccessul = 0;
      AvgIntervalAutoRead = 0;
      LastIntervalAutoRead = 0;
      lastAutoRead = 0;
      MinIntervalAutoRead = 0;
      MaxIntervalAutoRead = 0;
      sumIntervalAutoRead = 0;
    }

    private void McProtocolTcp_NotifyEvent(object sender, Notify notify)
    {
      switch (notify)
      {
        case Notify.Connected:
          //if (enableAutoRead)
          //  Task.Run(() => { Task.Delay(5000); autoReadTimer.Start(); });
          break;
        case Notify.Disconnected:
          autoReadTimer.Stop();
          break;
      }
    }

    private void McProtocolTcp_AutoReadRecivedEvent(object sender, DeviceBlock dataInfo, int[] data)
    {
      TotalReadSuccessul++; // update counter
    }

    private async void AutoReadTimer_Elapsed(object sender, ElapsedEventArgs e)
    {
      if (this.Connected && EnableAutoRead)
      {
        if (this.ReadDeviceBlocks == null)
          throw new Exception("Read package not initialized yet!");
        else if (ReadDeviceBlocks.Count > 0)
        {
          //udpate counter
          if (totalReadCommand > 1)
          {
            maxIntervalAutoRead = (maxIntervalAutoRead < lastIntervalAutoRead) ? lastIntervalAutoRead : maxIntervalAutoRead;
            minIntervalAutoRead = ((minIntervalAutoRead > lastIntervalAutoRead) || (minIntervalAutoRead == 0)) ? lastIntervalAutoRead : minIntervalAutoRead;
            sumIntervalAutoRead += lastIntervalAutoRead;
            avgIntervalRead = (sumIntervalAutoRead / TotalReadCommand);
          }
          lastIntervalAutoRead = UnixTimeMilliseconds - lastAutoRead;
          lastAutoRead = UnixTimeMilliseconds;
          TotalReadCommand++;
          var p = ReadDeviceBlocks[readIndex];
          try
          {
            await ReadDeviceBlock(p);
          }
          catch (Exception ex)
          {
            if (ex.InnerException != null && ex.InnerException.GetType() == typeof(SocketException))
            {
              var _e = ex.InnerException as SocketException;
              if (_e.SocketErrorCode == SocketError.TimedOut)
                if (NotifyEvent != null) NotifyEvent(this, Notify.ReadTimedOut);
              if (_e.SocketErrorCode == SocketError.ConnectionReset)
                if (NotifyEvent != null) NotifyEvent(this, Notify.Disconnected);
            }
            var msg = ex.Message;
            Console.WriteLine(msg);
          }
          readIndex++;
          if (readIndex >= ReadDeviceBlocks.Count) readIndex = 0;
          if (this.Connected == true && EnableAutoRead == true)
            autoReadTimer.Start();
        }
      }
    }

    public void StartAutoRead()
    {
      EnableAutoRead = true;
      autoReadTimer.Enabled = true;
      autoReadTimer.Start();
    }

    public void StopAutoRead()
    {
      EnableAutoRead = false;
      autoReadTimer.Enabled = false;
      autoReadTimer.Stop();
    }
    #endregion
  }

  [TypeConverterAttribute(typeof(ExpandableObjectConverter))]
  public class DeviceBlock
  {
    public DeviceBlock() { }

    public int Index { set; get; }
    public DeviceType DeviceType { set; get; }
    public int Address { set; get; }
    public int Length { set; get; }
    public string DeviceAddress { get => $"{DeviceType}{Address}"; }

    public DeviceBlock(DeviceType DeviceType, int Address, int Length)
    {
      this.DeviceType = DeviceType;
      this.Address = Address;
      this.Length = Length;
    }

    public DeviceBlock(string DeviceAddress, int Length)
    {
      int oaddress;
      DeviceType otype;
      McProtocolClient.GetDeviceCode(DeviceAddress, out otype, out oaddress);
      this.DeviceType = otype;
      this.Address = oaddress;
      this.Length = Length;
    }
  }

}

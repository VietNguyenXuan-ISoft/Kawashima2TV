#define old //Now that .NET Standard is supported in UWP old code is Good
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using System.Text;
using System.Net.Sockets;
using System.IO;
using System.ComponentModel;
#if !old
using Windows.Networking;
using Windows.Networking.Sockets;
using Windows.Foundation;
#endif
using System.Runtime.InteropServices;


namespace Mitsubishi.McProtocol
{
  public class PlcData
  {
    public int Index = 0;
    public static Mitsubishi.McProtocol.Plc PLC;

  }

  public class PlcData<T> : PlcData
  {
    public DeviceType DeviceType { private set; get; }
    public int Address { private set; get; }
    public int Length { private set; get; }
    public List<T> Range { set; get; }

    int LENGTH;//Length in bytes
    byte[] bytes;
    public PlcData(DeviceType DeviceType, int Address, int Length)
    {
      this.DeviceType = DeviceType;
      this.Address = Address;
      this.Range = new List<T>(Length);

      string t = typeof(T).Name;
      switch (t)
      {
        case "Boolean":
          this.LENGTH = (Length / 16 + (Length % 16 > 0 ? 1 : 0)) * 2;
          this.Length = Length;
          break;
        case "Int32":
          this.LENGTH = 4 * Length;
          this.Length = Length * 2;
          break;
        case "Int16":
          this.LENGTH = 2 * Length;
          this.Length = Length;
          break;
        case "UInt16":
          this.LENGTH = 2 * Length;
          this.Length = Length;
          break;
        case "UInt32":
          this.LENGTH = 4 * Length;
          this.Length = Length * 2;
          break;
        case "Single":
          this.LENGTH = 4 * Length;
          this.Length = Length * 2;
          break;
        case "Double":
          this.LENGTH = 8 * Length;
          this.Length = Length * 4;
          break;
        case "Char":
          this.LENGTH = Length;
          this.Length = Length;
          break;
        default:
          throw new Exception("Type not supported by PLC.");
      }
      this.bytes = new byte[this.LENGTH];

    }
    public PlcData(string DeviceAddress, int Length)
    {
      var oaddress = 0;
      var otype = DeviceType.D;
      Mitsubishi.McProtocol.McProtocolClient.GetDeviceCode(DeviceAddress, out otype, out oaddress);
      this.DeviceType = otype;
      this.Address = oaddress;
      this.Range = new List<T>(Length);

      string t = typeof(T).Name;
      switch (t)
      {
        case "Boolean":
          this.LENGTH = (Length / 16 + (Length % 16 > 0 ? 1 : 0)) * 2;
          this.Length = Length;
          break;
        case "Int32":
          this.LENGTH = 4 * Length;
          this.Length = Length * 2;
          break;
        case "Int16":
          this.LENGTH = 2 * Length;
          this.Length = Length;
          break;
        case "UInt16":
          this.LENGTH = 2 * Length;
          this.Length = Length;
          break;
        case "UInt32":
          this.LENGTH = 4 * Length;
          this.Length = Length * 2;
          break;
        case "Single":
          this.LENGTH = 4 * Length;
          this.Length = Length * 2;
          break;
        case "Double":
          this.LENGTH = 8 * Length;
          this.Length = Length * 4;
          break;
        case "Char":
          this.LENGTH = Length;
          this.Length = Length;
          break;
        default:
          throw new Exception("Type not supported by PLC.");
      }
      this.bytes = new byte[this.LENGTH];

    }
    public T this[int i]
    {
      get
      {
        Union u = new Union();
        string t = typeof(T).Name;
        switch (t)
        {
          case "Boolean":
            return (T)Convert.ChangeType(((this.bytes[i / 8] >> (i % 8)) % 2 == 1), typeof(T));
          case "Int32":
            u.a = this.bytes[i * 4];
            u.b = this.bytes[i * 4 + 1];
            u.c = this.bytes[i * 4 + 2];
            u.d = this.bytes[i * 4 + 3];
            return (T)Convert.ChangeType(u.DINT, typeof(T));
          case "Int16":
            u.a = this.bytes[i * 2];
            u.b = this.bytes[i * 2 + 1];
            return (T)Convert.ChangeType(u.INT, typeof(T));
          case "UInt16":
            u.a = this.bytes[i * 2];
            u.b = this.bytes[i * 2 + 1];
            return (T)Convert.ChangeType(u.UINT, typeof(T));
          case "UInt32":
            u.a = this.bytes[i * 4];
            u.b = this.bytes[i * 4 + 1];
            u.c = this.bytes[i * 4 + 2];
            u.d = this.bytes[i * 4 + 3];
            return (T)Convert.ChangeType(u.UDINT, typeof(T));
          case "Single":
            u.a = this.bytes[i * 4];
            u.b = this.bytes[i * 4 + 1];
            u.c = this.bytes[i * 4 + 2];
            u.d = this.bytes[i * 4 + 3];
            return (T)Convert.ChangeType(u.REAL, typeof(T));
          case "Char":
            return (T)Convert.ChangeType(this.ToString()[i], typeof(T));
          default:
            throw new Exception("Type not recognized.");
        }
      }
      set
      {
        Union u = new Union();
        string t = typeof(T).Name;
        switch (t)
        {
          case "Boolean":
            bool arg = Convert.ToBoolean(value);
            if (arg && (this.bytes[i / 8] >> (i % 8)) % 2 == 0)
              this.bytes[i / 8] += (byte)(1 << (i % 8));
            else if (!arg && (this.bytes[i / 8] >> (i % 8)) % 2 == 1)
              this.bytes[i / 8] -= (byte)(1 << (i % 8));
            return;
          case "Int32":
            u.DINT = Convert.ToInt32(value);
            this.bytes[i * 4] = u.a;
            this.bytes[i * 4 + 1] = u.b;
            this.bytes[i * 4 + 2] = u.c;
            this.bytes[i * 4 + 3] = u.d;
            return;
          case "Int16":
            u.INT = Convert.ToInt16(value);
            this.bytes[i * 2] = u.a;
            this.bytes[i * 2 + 1] = u.b;
            return;
          case "UInt32":
            u.UDINT = Convert.ToUInt32(value);
            this.bytes[i * 4] = u.a;
            this.bytes[i * 4 + 1] = u.b;
            this.bytes[i * 4 + 2] = u.c;
            this.bytes[i * 4 + 3] = u.d;
            return;
          case "UInt16":
            u.UINT = Convert.ToUInt16(value);
            this.bytes[i * 2] = u.a;
            this.bytes[i * 2] = u.b;
            return;
          case "Single":
            u.REAL = Convert.ToSingle(value);
            this.bytes[i * 4] = u.a;
            this.bytes[i * 4 + 1] = u.b;
            this.bytes[i * 4 + 2] = u.c;
            this.bytes[i * 4 + 3] = u.d;
            return;
          default:
            throw new Exception("Type not recognized.");
        }
      }
    }

    public async Task WriteData()
    {
      await PLC.WriteDeviceBlock(this.DeviceType, this.Address, Length, bytes);
    }
    public async Task ReadData()
    {
      this.bytes = await PLC.ReadDeviceBlock(DeviceType, this.Address, this.Length);
    }
  }
  [StructLayout(LayoutKind.Explicit)]
  public class Union
  {
    [FieldOffset(0)]
    public float REAL;
    [FieldOffset(0)]
    public short INT;
    [FieldOffset(0)]
    public uint UINT;
    [FieldOffset(0)]
    public int DINT;
    [FieldOffset(0)]
    public uint UDINT;
    [FieldOffset(0)]
    public char letter;
    [FieldOffset(0)]
    public byte bite;
    [FieldOffset(0)]
    public byte a;
    [FieldOffset(1)]
    public byte b;
    [FieldOffset(2)]
    public byte c;
    [FieldOffset(3)]
    public byte d;
  }

  // %%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
  // PLCと接続するための共通のインターフェースを定義する
  public interface Plc : IDisposable
  {
    bool Connected { get; }
    Task<int> Open();
    int Close();
    Task<int> SetBitDevice(string iDeviceName, int iSize, int[] iData);
    Task<int> SetBitDevice(DeviceType iType, int iAddress, int iSize, int[] iData);
    Task<int> GetBitDevice(string iDeviceName, int iSize, int[] oData);
    Task<int> GetBitDevice(DeviceType iType, int iAddress, int iSize, int[] oData);
    Task<int> WriteDeviceBlock(string iDeviceName, int iSize, int[] iData);
    Task<int> WriteDeviceBlock(DeviceType iType, int iAddress, int iSize, int[] iData);
    Task<int> WriteDeviceBlock(DeviceType iType, int iAddress, int iSize, byte[] bData);
    Task<byte[]> ReadDeviceBlock(string iDeviceName, int iSize, int[] oData);
    Task<byte[]> ReadDeviceBlock(DeviceType iType, int iAddress, int iSize, int[] oData);
    Task<byte[]> ReadDeviceBlock(DeviceType iType, int iAddress, int iSize);
    Task<int> SetDevice(string iDeviceName, int iData);
    Task<int> SetDevice(DeviceType iType, int iAddress, int iData);
    Task<int> GetDevice(string iDeviceName);
    Task<int> GetDevice(DeviceType iType, int iAddress);
  }
  // ########################################################################################
  abstract public class McProtocolApp : Plc
  {
    //Events
    public delegate void ReadDeviceBlockRecivedHandle(object sender, int[] data);
    public event ReadDeviceBlockRecivedHandle ReadDeviceBlockRecivedEvent;

    public delegate void AutoReadRecivedHandle(object sender, DeviceBlock dataInfo, int[] data);
    public event AutoReadRecivedHandle AutoReadRecivedEvent;


    public abstract bool Connected { get; }
    // ====================================================================================
    [Category("Connection")]
    public McFrame CommandFrame { get; set; }   // 使用フレーム
    [Category("Connection")]
    public string HostName { get; set; }   // ホスト名またはIPアドレス
    [Category("Connection")]
    public int PortNumber { get; set; }    // ポート番号
    public int Device { private set; get; }
    // ====================================================================================
    // コンストラクタ
    protected McProtocolApp(string iHostName, int iPortNumber, McFrame frame)
    {
      CommandFrame = frame;
      //C70 = MC3E

      HostName = iHostName;
      PortNumber = iPortNumber;
    }

    // ====================================================================================
    // 後処理
    public void Dispose()
    {
      Close();
    }

    // ====================================================================================
    public async Task<int> Open()
    {
      Command = new McCommand(CommandFrame);
      await DoConnect();
      
      return 0;
    }
    // ====================================================================================
    public int Close()
    {
      DoDisconnect();
      return 0;
    }
    // ====================================================================================
    public async Task<int> SetBitDevice(string iDeviceName, int iSize, int[] iData)
    {
      DeviceType type;
      int addr;
      GetDeviceCode(iDeviceName, out type, out addr);
      return await SetBitDevice(type, addr, iSize, iData);
    }
    // ====================================================================================
    public async Task<int> SetBitDevice(DeviceType iType, int iAddress, int iSize, int[] iData)
    {
      var type = iType;
      var addr = iAddress;
      var data = new List<byte>(6)
                    {
                        (byte) addr
                      , (byte) (addr >> 8)
                      , (byte) (addr >> 16)
                      , (byte) type
                      , (byte) iSize
                      , (byte) (iSize >> 8)
                    };
      var d = (byte)iData[0];
      var i = 0;
      while (i < iData.Length)
      {
        if (i % 2 == 0)
        {
          d = (byte)iData[i];
          d <<= 4;
        }
        else
        {
          d |= (byte)(iData[i] & 0x01);
          data.Add(d);
        }
        ++i;
      }
      if (i % 2 != 0)
      {
        data.Add(d);
      }
      int length = (int)Command.FrameType;// == McFrame.MC3E) ? 11 : 15;
      byte[] sdCommand = Command.SetCommandMC3E(0x1401, 0x0001, data.ToArray());
      byte[] rtResponse = await TryExecution(sdCommand, length);
      int rtCode = Command.SetResponse(rtResponse);
      return rtCode;
    }
    // ====================================================================================
    public async Task<int> GetBitDevice(string iDeviceName, int iSize, int[] oData)
    {
      DeviceType type;
      int addr;
      GetDeviceCode(iDeviceName, out type, out addr);
      return await GetBitDevice(type, addr, iSize, oData);
    }
    // ====================================================================================
    public async Task<int> GetBitDevice(DeviceType iType, int iAddress, int iSize, int[] oData)
    {

      DeviceType type = iType;
      int addr = iAddress;
      var data = new List<byte>(6)
                    {
                        (byte) addr
                      , (byte) (addr >> 8)
                      , (byte) (addr >> 16)
                      , (byte) type
                      , (byte) iSize
                      , (byte) (iSize >> 8)
                    };
      byte[] sdCommand = Command.SetCommandMC3E(0x0401, 0x0001, data.ToArray());
      int length = (Command.FrameType == McFrame.MC3E) ? 11 : 15;
      byte[] rtResponse = await TryExecution(sdCommand, length);
      int rtCode = Command.SetResponse(rtResponse);
      byte[] rtData = Command.Response;
      for (int i = 0; i < iSize; ++i)
      {
        if (i % 2 == 0)
        {
          oData[i] = (rtCode == 0) ? ((rtData[i / 2] >> 4) & 0x01) : 0;
        }
        else
        {
          oData[i] = (rtCode == 0) ? (rtData[i / 2] & 0x01) : 0;
        }
      }
      return rtCode;
    }
    // ====================================================================================
    public async Task<int> WriteDeviceBlock(string iDeviceName, int iSize, int[] iData)
    {
      DeviceType type;
      int addr;
      GetDeviceCode(iDeviceName, out type, out addr);
      return await WriteDeviceBlock(type, addr, iSize, iData);
    }
    // ====================================================================================
    public async Task<int> WriteDeviceBlock(DeviceType iType, int iAddress, int iSize, int[] iData)
    {

      DeviceType type = iType;
      int addr = iAddress;
      List<byte> data;

      List<byte> DeviceData = new List<byte>();
      foreach (int t in iData)
      {
        DeviceData.Add((byte)t);
        DeviceData.Add((byte)(t >> 8));
      }

      byte[] sdCommand;
      int length;
      //TEST Create this write switch statement
      switch (CommandFrame)
      {
        case McFrame.MC3E:
          data = new List<byte>(6)
                    {
                        (byte) addr
                      , (byte) (addr >> 8)
                      , (byte) (addr >> 16)
                      , (byte) type
                      , (byte) iSize
                      , (byte) (iSize >> 8)
                    };
          data.AddRange(DeviceData.ToArray());
          sdCommand = Command.SetCommandMC3E(0x1401, 0x0000, data.ToArray());
          length = 11;
          break;
        case McFrame.MC4E:
          data = new List<byte>(6)
                    {
                        (byte) addr
                      , (byte) (addr >> 8)
                      , (byte) (addr >> 16)
                      , (byte) type
                      , (byte) iSize
                      , (byte) (iSize >> 8)
                    };
          data.AddRange(DeviceData.ToArray());
          sdCommand = Command.SetCommandMC4E(0x1401, 0x0000, data.ToArray());
          length = 15;
          break;
        case McFrame.MC1E:
          data = new List<byte>(6)
                   {
                          (byte) addr
                      , (byte) (addr >> 8)
                      , (byte) (addr >> 16)
                      , (byte) (addr >> 24)
                      , 0x20
                      , 0x44
                      , (byte) iSize
                      , 0x00
                    };
          data.AddRange(DeviceData.ToArray());
          //Add data
          sdCommand = Command.SetCommandMC1E(0x03, data.ToArray());
          length = 2;
          break;
        default:
          throw new Exception("Message frame not supported");
      }

      //TEST take care of the writing
      byte[] rtResponse = await TryExecution(sdCommand, length);
      int rtCode = Command.SetResponse(rtResponse);
      return rtCode;
    }
    public async Task<int> WriteDeviceBlock(DeviceType iType, int iAddress, int devicePoints, byte[] bData)
    {
      //FIXME
      int iSize = devicePoints;
      DeviceType type = iType;
      int addr = iAddress;
      List<byte> data;
      byte[] sdCommand;
      int length;
      //TEST Create this write switch statement
      switch (CommandFrame)
      {
        case McFrame.MC3E:
          data = new List<byte>(6)
                    {
                        (byte) addr
                      , (byte) (addr >> 8)
                      , (byte) (addr >> 16)
                      , (byte) type
                      , (byte) iSize
                      , (byte) (iSize >> 8)
                    };
          data.AddRange(bData);
          sdCommand = Command.SetCommandMC3E(0x1401, 0x0000, data.ToArray());
          length = 11;
          break;
        case McFrame.MC4E:
          data = new List<byte>(6)
                    {
                        (byte) addr
                      , (byte) (addr >> 8)
                      , (byte) (addr >> 16)
                      , (byte) type
                      , (byte) iSize
                      , (byte) (iSize >> 8)
                    };
          data.AddRange(bData);
          sdCommand = Command.SetCommandMC4E(0x1401, 0x0000, data.ToArray());
          length = 15;
          break;
        case McFrame.MC1E:
          data = new List<byte>(6)
                   {
                          (byte) addr
                      , (byte) (addr >> 8)
                      , (byte) (addr >> 16)
                      , (byte) (addr >> 24)
                      , 0x20
                      , 0x44
                      , (byte) iSize
                      , 0x00
                    };
          data.AddRange(bData);
          //Add data
          sdCommand = Command.SetCommandMC1E(0x03, data.ToArray());
          length = 2;
          break;
        default:
          throw new Exception("Message frame not supported");
      }
      //TEST take care of the writing
      byte[] rtResponse = await TryExecution(sdCommand, length);
      int rtCode = Command.SetResponse(rtResponse);
      return rtCode;
    }
    // ====================================================================================
    public async Task<byte[]> ReadDeviceBlock(string iDeviceName, int iSize, int[] oData)
    {
      DeviceType type;
      int addr;
      GetDeviceCode(iDeviceName, out type, out addr);
      return await ReadDeviceBlock(type, addr, iSize, oData);
    }
    // ====================================================================================
    public async Task<byte[]> ReadDeviceBlock(DeviceType iType, int iAddress, int iSize, int[] oData)
    {
      var dataInt = new int[iSize];
      DeviceType type = iType;
      int addr = iAddress;
      List<byte> data;
      byte[] sdCommand;
      int length;

      switch (CommandFrame)
      {
        case McFrame.MC3E:
          data = new List<byte>(6)
                    {
                        (byte) addr
                      , (byte) (addr >> 8)
                      , (byte) (addr >> 16)
                      , (byte) type
                      , (byte) iSize
                      , (byte) (iSize >> 8)
                    };
          sdCommand = Command.SetCommandMC3E(0x0401, 0x0000, data.ToArray());
          length = 11;
          break;
        case McFrame.MC4E:
          data = new List<byte>(6)
                    {
                        (byte) addr
                      , (byte) (addr >> 8)
                      , (byte) (addr >> 16)
                      , (byte) type
                      , (byte) iSize
                      , (byte) (iSize >> 8)
                    };
          sdCommand = Command.SetCommandMC4E(0x0401, 0x0000, data.ToArray());
          length = 15;
          break;
        case McFrame.MC1E:
          data = new List<byte>(6)
                    {
                          (byte) addr
                      , (byte) (addr >> 8)
                      , (byte) (addr >> 16)
                      , (byte) (addr >> 24)
                      , 0x20
                      , 0x44
                      , (byte) iSize
                      , 0x00
                    };
          sdCommand = Command.SetCommandMC1E(0x01, data.ToArray());
          length = 2;
          break;
        default:
          throw new Exception("Message frame not supported");
      }

      byte[] rtResponse = await TryExecution(sdCommand, length);
      //TEST verify read responses
      int rtCode = Command.SetResponse(rtResponse);
      byte[] rtData = Command.Response;
      for (int i = 0; i < iSize; ++i)
      {
        oData[i] = (rtCode == 0) ? BitConverter.ToInt16(rtData, i * 2) : 0;
        dataInt[i] = oData[i];
      }
      //Console.WriteLine("call event");
      if (ReadDeviceBlockRecivedEvent != null) ReadDeviceBlockRecivedEvent(this, dataInt);
      return rtData;
    }

    public async Task<byte[]> ReadDeviceBlock(DeviceType iType, int iAddress, int devicePoints)
    {
      int iSize = devicePoints;
      DeviceType type = iType;
      int addr = iAddress;
      List<byte> data;
      byte[] sdCommand;
      int length;

      switch (CommandFrame)
      {
        case McFrame.MC3E:
          data = new List<byte>(6)
                    {
                        (byte) addr
                      , (byte) (addr >> 8)
                      , (byte) (addr >> 16)
                      , (byte) type
                      , (byte) iSize
                      , (byte) (iSize >> 8)
                    };
          sdCommand = Command.SetCommandMC3E(0x0401, 0x0000, data.ToArray());
          length = 11;
          break;
        case McFrame.MC4E:
          data = new List<byte>(6)
                    {
                        (byte) addr
                      , (byte) (addr >> 8)
                      , (byte) (addr >> 16)
                      , (byte) type
                      , (byte) iSize
                      , (byte) (iSize >> 8)
                    };
          sdCommand = Command.SetCommandMC4E(0x0401, 0x0000, data.ToArray());
          length = 15;
          break;
        case McFrame.MC1E:
          data = new List<byte>(6)
                    {
                          (byte) addr
                      , (byte) (addr >> 8)
                      , (byte) (addr >> 16)
                      , (byte) (addr >> 24)
                      , 0x20
                      , 0x44
                      , (byte) iSize
                      , 0x00
                    };
          sdCommand = Command.SetCommandMC1E(0x01, data.ToArray());
          length = 2;
          break;
        default:
          throw new Exception("Message frame not supported");
      }

      byte[] rtResponse = await TryExecution(sdCommand, length);
      //TEST verify read responses
      int rtCode = Command.SetResponse(rtResponse);
      byte[] rtData = Command.Response;
      var dataInt = new int[iSize];
      //Console.WriteLine($"byte[] rtDate length: {rtData.Length}");
      //if (rtData.Length != iSize) return rtData;
      for (int i = 0; i < iSize; ++i)
      {
        dataInt[i] = (rtCode == 0) ? BitConverter.ToInt16(rtData, i * 2) : 0;
      }
      //Console.WriteLine("call event");
      if (ReadDeviceBlockRecivedEvent != null) ReadDeviceBlockRecivedEvent(this, dataInt);
      return rtData;
    }

    /// <summary>
    /// This method only for auto read function.
    /// </summary>
    /// <param name="DeviceBlock">Content DeviceType, Address, Length, this info use for read</param>
    /// <returns></returns>
    public async Task<byte[]> ReadDeviceBlock(DeviceBlock DeviceBlock)
    {
      int iSize = DeviceBlock.Length;
      DeviceType type = DeviceBlock.DeviceType;
      int addr = DeviceBlock.Address;
      List<byte> data;
      byte[] sdCommand;
      int length;

      switch (CommandFrame)
      {
        case McFrame.MC3E:
          data = new List<byte>(6)
                    {
                        (byte) addr
                      , (byte) (addr >> 8)
                      , (byte) (addr >> 16)
                      , (byte) type
                      , (byte) iSize
                      , (byte) (iSize >> 8)
                    };
          sdCommand = Command.SetCommandMC3E(0x0401, 0x0000, data.ToArray());
          length = 11;
          break;
        case McFrame.MC4E:
          data = new List<byte>(6)
                    {
                        (byte) addr
                      , (byte) (addr >> 8)
                      , (byte) (addr >> 16)
                      , (byte) type
                      , (byte) iSize
                      , (byte) (iSize >> 8)
                    };
          sdCommand = Command.SetCommandMC4E(0x0401, 0x0000, data.ToArray());
          length = 15;
          break;
        case McFrame.MC1E:
          data = new List<byte>(6)
                    {
                          (byte) addr
                      , (byte) (addr >> 8)
                      , (byte) (addr >> 16)
                      , (byte) (addr >> 24)
                      , 0x20
                      , 0x44
                      , (byte) iSize
                      , 0x00
                    };
          sdCommand = Command.SetCommandMC1E(0x01, data.ToArray());
          length = 2;
          break;
        default:
          throw new Exception("Message frame not supported");
      }

      byte[] rtResponse = await TryExecution(sdCommand, length);
      //TEST verify read responses
      int rtCode = Command.SetResponse(rtResponse);
      byte[] rtData = Command.Response;
      var dataInt = new int[iSize];
      //Console.WriteLine($"byte[] rtDate length: {rtData.Length}");
      //if (rtData.Length != iSize) return rtData;
      for (int i = 0; i < iSize; ++i)
      {
        dataInt[i] = (rtCode == 0) ? BitConverter.ToInt16(rtData, i * 2) : 0;
      }
      //call event
      if (ReadDeviceBlockRecivedEvent != null) ReadDeviceBlockRecivedEvent(this, dataInt);
      if (AutoReadRecivedEvent != null) AutoReadRecivedEvent(this, DeviceBlock, dataInt);
      return rtData;
    }

    // ====================================================================================
    public async Task<int> SetDevice(string iDeviceName, int iData)
    {
      DeviceType type;
      int addr;
      GetDeviceCode(iDeviceName, out type, out addr);
      var ret = await SetDevice(type, addr, iData);
      return ret;
    }
    // ====================================================================================
    public async Task<int> SetDevice(DeviceType iType, int iAddress, int iData)
    {

      DeviceType type = iType;
      int addr = iAddress;
      var data = new List<byte>(6)
                    {
                        (byte) addr
                      , (byte) (addr >> 8)
                      , (byte) (addr >> 16)
                      , (byte) type
                      , 0x01
                      , 0x00
                      , (byte) iData
                      , (byte) (iData >> 8)
                    };
      byte[] sdCommand = Command.SetCommandMC3E(0x1401, 0x0000, data.ToArray());
      int length = (Command.FrameType == McFrame.MC3E) ? 11 : 15;

      byte[] rtResponse = await TryExecution(sdCommand, length);

      int rtCode = Command.SetResponse(rtResponse);
      return rtCode;
    }
    // ====================================================================================
    public async Task<int> GetDevice(string iDeviceName)
    {
      DeviceType type;
      int addr;
      GetDeviceCode(iDeviceName, out type, out addr);
      return await GetDevice(type, addr);
    }
    // ====================================================================================
    public async Task<int> GetDevice(DeviceType iType, int iAddress)
    {
      DeviceType type = iType;
      int addr = iAddress;
      var data = new List<byte>(6)
                    {
                        (byte) addr
                      , (byte) (addr >> 8)
                      , (byte) (addr >> 16)
                      , (byte) type
                      , 0x01
                      , 0x00
                    };
      byte[] sdCommand = Command.SetCommandMC3E(0x0401, 0x0000, data.ToArray());
      int length = (Command.FrameType == McFrame.MC3E) ? 11 : 15;
      ; byte[] rtResponse = await TryExecution(sdCommand, length);
      int rtCode = Command.SetResponse(rtResponse);
      if (0 < rtCode)
      {
        this.Device = 0;
      }
      else
      {
        byte[] rtData = Command.Response;
        this.Device = BitConverter.ToInt16(rtData, 0);
      }
      return rtCode;
    }
    // ====================================================================================
    //public int GetCpuType(out string oCpuName, out int oCpuType)
    //{
    //    int rtCode = Command.Execute(0x0101, 0x0000, new byte[0]);
    //    oCpuName = "dummy";
    //    oCpuType = 0;
    //    return rtCode;
    //}
    // ====================================================================================
    public static DeviceType GetDeviceType(string s)
    {
      return (s == "M") ? DeviceType.M :
             (s == "SM") ? DeviceType.SM :
             (s == "L") ? DeviceType.L :
             (s == "F") ? DeviceType.F :
             (s == "V") ? DeviceType.V :
             (s == "S") ? DeviceType.S :
             (s == "X") ? DeviceType.X :
             (s == "Y") ? DeviceType.Y :
             (s == "B") ? DeviceType.B :
             (s == "SB") ? DeviceType.SB :
             (s == "DX") ? DeviceType.DX :
             (s == "DY") ? DeviceType.DY :
             (s == "D") ? DeviceType.D :
             (s == "SD") ? DeviceType.SD :
             (s == "R") ? DeviceType.R :
             (s == "ZR") ? DeviceType.ZR :
             (s == "W") ? DeviceType.W :
             (s == "SW") ? DeviceType.SW :
             (s == "TC") ? DeviceType.TC :
             (s == "TS") ? DeviceType.TS :
             (s == "TN") ? DeviceType.TN :
             (s == "CC") ? DeviceType.CC :
             (s == "CS") ? DeviceType.CS :
             (s == "CN") ? DeviceType.CN :
             (s == "SC") ? DeviceType.SC :
             (s == "SS") ? DeviceType.SS :
             (s == "SN") ? DeviceType.SN :
             (s == "Z") ? DeviceType.Z :
             (s == "TT") ? DeviceType.TT :
             (s == "TM") ? DeviceType.TM :
             (s == "CT") ? DeviceType.CT :
             (s == "CM") ? DeviceType.CM :
             (s == "A") ? DeviceType.A :
                           DeviceType.Max;
    }

    // ====================================================================================
    public static bool IsBitDevice(DeviceType type)
    {
      return !((type == DeviceType.D)
            || (type == DeviceType.SD)
            || (type == DeviceType.Z)
            || (type == DeviceType.ZR)
            || (type == DeviceType.R)
            || (type == DeviceType.W));
    }

    // ====================================================================================
    public static bool IsHexDevice(DeviceType type)
    {
      return (type == DeviceType.X)
          || (type == DeviceType.Y)
          || (type == DeviceType.B)
          || (type == DeviceType.W);
    }

    // ====================================================================================
    public static void GetDeviceCode(string iDeviceName, out DeviceType oType, out int oAddress)
    {
      string s = iDeviceName.ToUpper();
      string strAddress;

      // Trích xuất một ký tự
      string strType = s.Substring(0, 1);
      switch (strType)
      {
        case "A":
        case "B":
        case "D":
        case "F":
        case "L":
        case "M":
        case "R":
        case "V":
        case "W":
        case "X":
        case "Y":
          // 2文字目以降は数値のはずなので変換する
          strAddress = s.Substring(1);
          break;
        case "Z":
          // もう1文字取り出す
          strType = s.Substring(0, 2);
          // ファイルレジスタの場合     : 2
          // インデックスレジスタの場合 : 1
          strAddress = s.Substring(strType.Equals("ZR") ? 2 : 1);
          break;
        case "C":
          // もう1文字取り出す
          strType = s.Substring(0, 2);
          switch (strType)
          {
            case "CC":
            case "CM":
            case "CN":
            case "CS":
            case "CT":
              strAddress = s.Substring(2);
              break;
            default:
              throw new Exception("Invalid format.");
          }
          break;
        case "S":
          // もう1文字取り出す
          strType = s.Substring(0, 2);
          switch (strType)
          {
            case "SD":
            case "SM":
              strAddress = s.Substring(2);
              break;
            default:
              throw new Exception("Invalid format.");
          }
          break;
        case "T":
          // もう1文字取り出す
          strType = s.Substring(0, 2);
          switch (strType)
          {
            case "TC":
            case "TM":
            case "TN":
            case "TS":
            case "TT":
              strAddress = s.Substring(2);
              break;
            default:
              throw new Exception("Invalid format.");
          }
          break;
        default:
          throw new Exception("Invalid format.");
      }

      oType = GetDeviceType(strType);
      oAddress = IsHexDevice(oType) ? Convert.ToInt32(strAddress, BlockSize) :
                                      Convert.ToInt32(strAddress);
    }

    // &&&&& protected &&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&
    abstract protected Task<int> DoConnect();
    abstract protected void DoDisconnect();
    abstract protected Task<byte[]> Execute(byte[] iCommand);

    // &&&&& private &&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&
    private const int BlockSize = 0x0010;
    private McCommand Command { get; set; }



    // ================================================================================
    private async Task<byte[]> TryExecution(byte[] iCommand, int minlength)
    {

      byte[] rtResponse;
      int tCount = 10;
      do
      {
        rtResponse = await Execute(iCommand);
        --tCount;
        if (tCount < 0)
        {
          throw new Exception("Cannot get correct value from PLC.");
          //throw new Exception("PLCから正しい値が取得できません.");
        }
      } while (Command.IsIncorrectResponse(rtResponse, minlength));
      return rtResponse;
    }

    /// <summary>
    /// 通信に使用するコマンドを表現するインナークラス | Inner class that represents commands used for communication
    /// </summary>
    class McCommand
    {
      public McFrame FrameType { get; private set; }  // フレーム種別 | FrameType
      private uint SerialNumber { get; set; }  // シリアル番号
      private uint NetworkNumber { get; set; } // ネットワーク番号
      private uint PcNumber { get; set; }      // PC番号
      private uint IoNumber { get; set; }      // 要求先ユニットI/O番号
      private uint ChannelNumber { get; set; } // 要求先ユニット局番号
      private uint CpuTimer { get; set; }      // CPU監視タイマ
      private int ResultCode { get; set; }     // 終了コード
      public byte[] Response { get; private set; }    // 応答データ
                                                      // ================================================================================
                                                      // コンストラクタ
      public McCommand(McFrame iFrame)
      {
        FrameType = iFrame;
        SerialNumber = 0x0001u;
        NetworkNumber = 0x0000u;
        PcNumber = 0x00FFu;
        IoNumber = 0x03FFu;
        ChannelNumber = 0x0000u;
        CpuTimer = 0x0010u;
      }

      // ================================================================================
      public byte[] SetCommandMC1E(byte Subheader, byte[] iData)
      {
        List<byte> ret = new List<byte>(iData.Length + 4);
        ret.Add(Subheader);
        ret.Add((byte)this.PcNumber);
        ret.Add((byte)CpuTimer);
        ret.Add((byte)(CpuTimer >> 8));
        ret.AddRange(iData);
        return ret.ToArray();
      }

      public byte[] SetCommandMC3E(uint iMainCommand, uint iSubCommand, byte[] iData)
      {
        var dataLength = (uint)(iData.Length + 6);
        List<byte> ret = new List<byte>(iData.Length + 20);
        uint frame = 0x0050u;
        ret.Add((byte)frame);
        ret.Add((byte)(frame >> 8));

        ret.Add((byte)NetworkNumber);

        ret.Add((byte)PcNumber);

        ret.Add((byte)IoNumber);
        ret.Add((byte)(IoNumber >> 8));
        ret.Add((byte)ChannelNumber);
        ret.Add((byte)dataLength);
        ret.Add((byte)(dataLength >> 8));


        ret.Add((byte)CpuTimer);
        ret.Add((byte)(CpuTimer >> 8));
        ret.Add((byte)iMainCommand);
        ret.Add((byte)(iMainCommand >> 8));
        ret.Add((byte)iSubCommand);
        ret.Add((byte)(iSubCommand >> 8));

        ret.AddRange(iData);
        return ret.ToArray();
      }
      public byte[] SetCommandMC4E(uint iMainCommand, uint iSubCommand, byte[] iData)
      {
        var dataLength = (uint)(iData.Length + 6);
        var ret = new List<byte>(iData.Length + 20);
        uint frame = 0x0054u;
        ret.Add((byte)frame);
        ret.Add((byte)(frame >> 8));
        ret.Add((byte)SerialNumber);
        ret.Add((byte)(SerialNumber >> 8));
        ret.Add(0x00);
        ret.Add(0x00);
        ret.Add((byte)NetworkNumber);
        ret.Add((byte)PcNumber);
        ret.Add((byte)IoNumber);
        ret.Add((byte)(IoNumber >> 8));
        ret.Add((byte)ChannelNumber);
        ret.Add((byte)dataLength);
        ret.Add((byte)(dataLength >> 8));
        ret.Add((byte)CpuTimer);
        ret.Add((byte)(CpuTimer >> 8));
        ret.Add((byte)iMainCommand);
        ret.Add((byte)(iMainCommand >> 8));
        ret.Add((byte)iSubCommand);
        ret.Add((byte)(iSubCommand >> 8));

        ret.AddRange(iData);
        return ret.ToArray();
      }
      // ================================================================================

      public int SetResponse(byte[] iResponse)
      {
        int min;
        switch (FrameType)
        {
          case McFrame.MC1E:
            min = 2;
            if (min <= iResponse.Length)
            {
              //There is a subheader, end code and data.
              ResultCode = (int)iResponse[min - 2];
              Response = new byte[iResponse.Length - 2];
              Buffer.BlockCopy(iResponse, min, Response, 0, Response.Length);
            }
            break;
          case McFrame.MC3E:
            min = 11;
            if (min <= iResponse.Length)
            {
              var btCount = new[] { iResponse[min - 4], iResponse[min - 3] };
              var btCode = new[] { iResponse[min - 2], iResponse[min - 1] };
              int rsCount = BitConverter.ToUInt16(btCount, 0);
              ResultCode = BitConverter.ToUInt16(btCode, 0);
              Response = new byte[rsCount - 2];
              Buffer.BlockCopy(iResponse, min, Response, 0, Response.Length);
            }
            break;
          case McFrame.MC4E:
            min = 15;
            if (min <= iResponse.Length)
            {
              var btCount = new[] { iResponse[min - 4], iResponse[min - 3] };
              var btCode = new[] { iResponse[min - 2], iResponse[min - 1] };
              int rsCount = BitConverter.ToUInt16(btCount, 0);
              ResultCode = BitConverter.ToUInt16(btCode, 0);
              Response = new byte[rsCount - 2];
              Buffer.BlockCopy(iResponse, min, Response, 0, Response.Length);
            }
            break;
          default:
            throw new Exception("Frame type not supported.");

        }
        return ResultCode;
      }
      // ================================================================================
      public bool IsIncorrectResponse(byte[] iResponse, int minLenght)
      {
        //TEST add 1E frame
        switch (this.FrameType)
        {
          case McFrame.MC1E:
            return ((iResponse.Length < minLenght));

          case McFrame.MC3E:
          case McFrame.MC4E:
            var btCount = new[] { iResponse[minLenght - 4], iResponse[minLenght - 3] };
            var btCode = new[] { iResponse[minLenght - 2], iResponse[minLenght - 1] };
            var rsCount = BitConverter.ToUInt16(btCount, 0) - 2;
            var rsCode = BitConverter.ToUInt16(btCode, 0);
            return (rsCode == 0 && rsCount != (iResponse.Length - minLenght));

          default:
            throw new Exception("Type Not supported");

        }
      }
    }
  }

  // ########################################################################################
  public partial class McProtocolClient : McProtocolApp
  {
    //private object state;

    //events
    //public McProtocolTcp() { }

    public delegate void NotifydHandle(object sender, Notify notify);
    public event NotifydHandle NotifyEvent;

    // ====================================================================================
    // コンストラクタ
    [Category("Connection")]
    public override bool Connected
    {
      get
      {
        return Client.Connected;
      }
    }

    public McProtocolClient() : this("", 0, McFrame.MC3E)
    {
    }

    public McProtocolClient(string iHostName, int iPortNumber, McFrame frame)
        : base(iHostName, iPortNumber, frame)
    {
      CommandFrame = frame;
#if !old
                this.Host = new HostName(iHostName);

                this.streamSocket = new StreamSocket();

                this.Port = iPortNumber;
#endif
      Client = new TcpClient();
      this.Init();
    }

    // &&&&& protected &&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&
    async override protected Task<int> DoConnect()
    {
#if !old
                this.streamSocket.Control.KeepAlive = true;

                await this.streamSocket.ConnectAsync(this.Host, "" + this.Port);
#endif
#if old
      if (Client != null)
        Client = new TcpClient();
      Client.SendTimeout = 1000;
      Client.ReceiveTimeout = 1000;
      if (!Client.Connected)
      {
        // Keep Alive 機能の実装
        var ka = new List<byte>(sizeof(uint) * 3);
        ka.AddRange(BitConverter.GetBytes(1u));
        ka.AddRange(BitConverter.GetBytes(45000u));
        ka.AddRange(BitConverter.GetBytes(5000u));
        Client.Client.IOControl(IOControlCode.KeepAliveValues, ka.ToArray(), null);
        try
        {
          if (NotifyEvent != null) NotifyEvent(this, Notify.Connecting);
          await Client.ConnectAsync(HostName, PortNumber);
          Stream = Client.GetStream();
          //Call Event Conneted
          if (Client.Connected && NotifyEvent != null) NotifyEvent(this, Notify.Connected);
        }
        catch (Exception ex)
        {
          var _ex = ex as SocketException;
          if (_ex.SocketErrorCode == SocketError.TimedOut)
            if (NotifyEvent != null) NotifyEvent(this, Notify.ConnectionTimedOut);
        }
      }
#endif
      return 0;
    }
    // ====================================================================================
    override protected void DoDisconnect()
    {
#if !old
                this.streamSocket.Dispose();
#endif
#if old
      TcpClient c = Client;
      Stream s = Stream;
      if (c.Connected)
      {
        s.Close();
        c.Close();
      }
      Client = new TcpClient();
      if (NotifyEvent != null) NotifyEvent(this, Notify.Disconnected);
#endif
    }
    // ================================================================================
    async override protected Task<byte[]> Execute(byte[] iCommand)
    {
      List<byte> list = new List<byte>();
#if windows

                //Write to the buffer


                await this.streamSocket.CancelIOAsync();

                Windows.Storage.Streams.DataWriter writer = new Windows.Storage.Streams.DataWriter(this.streamSocket.OutputStream);
                writer.WriteBytes(iCommand);
                await writer.StoreAsync();
                writer.DetachStream();

                
                //Read back from the buffer

                Windows.Storage.Streams.DataReader reader = new Windows.Storage.Streams.DataReader(this.streamSocket.InputStream);
                reader.InputStreamOptions = Windows.Storage.Streams.InputStreamOptions.Partial;
                reader.UnicodeEncoding = Windows.Storage.Streams.UnicodeEncoding.Utf8;
                reader.ByteOrder = Windows.Storage.Streams.ByteOrder.LittleEndian;
                //Load 4 bytes off the buffer as the header
                //DONE Fix the read length
                //do
                //{
                await reader.LoadAsync(256);
                //if (reader.UnconsumedBufferLength == 0) break;
                byte[] bytes = new byte[reader.UnconsumedBufferLength];
                reader.ReadBytes(bytes);//Should be 4
                list.AddRange(bytes);
                reader.DetachStream();
                //} while (true);
                return list.ToArray();
#endif

#if old

#endif
#if reading
                    await reader.LoadAsync(header[header.Length - 1]);//The last byte should be the remaining lenght
                    //
                    byte[] data = new byte[reader.UnconsumedBufferLength];
                    reader.ReadBytes(data);
                    byte[] buffer = new byte[header.Length + data.Length];
                    header.CopyTo(buffer, 0);
                    data.CopyTo(buffer, header.Length);
                    
#else


#endif



#if old

      NetworkStream ns = Stream;
      ns.Write(iCommand, 0, iCommand.Length);
      ns.Flush();

      using (var ms = new MemoryStream())
      {
        var buff = new byte[256];
        do
        {
          //ns.BeginRead(buff, 0, buff.Length, callback, state);
          int sz = ns.Read(buff, 0, buff.Length);
          if (sz == 0)
          {
            throw new Exception("Disconnected");
          }
          ms.Write(buff, 0, sz);
        } while (ns.DataAvailable);
        return ms.ToArray();
      }
#endif

    }

    //private void callback(IAsyncResult ar)
    //{

    //}

    // &&&&& private &&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&
#if !old
            private HostName Host { get; set; }
            private StreamSocket streamSocket { get; set; }
            private int Port { get; set; }
#endif
#if old
    private TcpClient Client { get; set; }
    private NetworkStream Stream { get; set; }
#endif
  }
#if udp
        // ########################################################################################
        public class McProtocolUdp : McProtocolApp
        {
            // ====================================================================================
            // コンストラクタ
            public McProtocolUdp(int iPortNumber) : this("", iPortNumber) { }
            public McProtocolUdp(string iHostName, int iPortNumber)
                : base(iHostName, iPortNumber)
            {
                Client = new UdpClient(iPortNumber);
            }

            // &&&&& protected &&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&
            override protected void DoConnect()
            {
                UdpClient c = Client;
                c.Connect(HostName, PortNumber);
            }
            // ====================================================================================
            override protected void DoDisconnect()
            {
                // UDPでは何もしない
            }
            // ================================================================================
            override protected byte[] Execute(byte[] iCommand)
            {
                UdpClient c = Client;
                // 送信
                c.Send(iCommand, iCommand.Length);

                using (var ms = new MemoryStream())
                {
                    IPAddress ip = IPAddress.Parse(HostName);
                    var ep = new IPEndPoint(ip, PortNumber);
                    do
                    {
                        // 受信
                        byte[] buff = c.Receive(ref ep);
                        ms.Write(buff, 0, buff.Length);
                    } while (0 < c.Available);
                    return ms.ToArray();
                }
            }
            // &&&&& private &&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&
            private UdpClient Client { get; set; }
        }
#endif
}




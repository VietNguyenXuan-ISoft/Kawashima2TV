using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NucPos123
{
  public class PlcIpAddress
  {
   
    /// <summary>
    /// Alpha
    /// </summary>
    public static plcConfig Line_1 = new plcConfig(1, "192.168.3.14", 5200);
    /// <summary>
    /// Hassia
    /// </summary>
    public static plcConfig Line_2 = new plcConfig(2, "192.168.3.10", 5200);
    /// <summary>
    /// Leepack 12
    /// </summary>
    public static plcConfig Line_3 = new plcConfig(3, "192.168.3.11", 5200);
    /// <summary>
    /// Mespack
    /// </summary>
    public static plcConfig Line_4 = new plcConfig(4, "192.168.3.12", 5200);
    /// <summary>
    /// Mespack
    /// </summary>
    public static plcConfig Line_5 = new plcConfig(5, "192.168.3.13", 5200);
  }

  public class plcAddressAndValue
  {
    public int Address = 0;
    public int Value = 0;

    public plcAddressAndValue(int address, int value)
    {
      this.Address= address; 
      this.Value = value;
    }
    public plcAddressAndValue()
    {

    }
  }
  public class plcConfig
  {
    public int id = 0;
    public string IpAddress = "";
    public int Port = 5200;

    public plcAddressAndValue Machine1_CounterIN = new plcAddressAndValue();

    public plcAddressAndValue Machine1_CounterOUT = new plcAddressAndValue();

    public plcAddressAndValue Machine1_FOS_Counter1 = new plcAddressAndValue();

    public plcAddressAndValue Machine1_FOS_Counter2 = new plcAddressAndValue();

    public plcAddressAndValue Machine1_FOS_Counter3 = new plcAddressAndValue();

    public plcAddressAndValue Machine1_FOS_Counter4 = new plcAddressAndValue();

    public plcAddressAndValue Machine1_FOS_Counter5 = new plcAddressAndValue();

    public plcAddressAndValue Machine1_FOS_Counter6 = new plcAddressAndValue();

    public plcAddressAndValue Machine1_FOS_Counter7 = new plcAddressAndValue();

    public plcAddressAndValue Machine1_FOS_Counter8 = new plcAddressAndValue();

    public plcAddressAndValue Machine1_CurrentSpeed = new plcAddressAndValue();
    public plcAddressAndValue Machine1_CurrentLossCode = new plcAddressAndValue();
    public plcAddressAndValue Machine1_LossLog_CurrentItem = new plcAddressAndValue();
    public plcAddressAndValue Machine1_Status = new plcAddressAndValue();
    public plcAddressAndValue Machine1_LineId = new plcAddressAndValue();
    public plcAddressAndValue Machine1_MachineId = new plcAddressAndValue();
    public plcAddressAndValue Machine1_LossDuration = new plcAddressAndValue();
    public plcAddressAndValue Machine1_StateMachine = new plcAddressAndValue();

    public plcConfig(int id, string ipAddress, int port)
    {
      this.id = id;
      this.IpAddress = ipAddress;
      this.Port = port;
    }
  }
}

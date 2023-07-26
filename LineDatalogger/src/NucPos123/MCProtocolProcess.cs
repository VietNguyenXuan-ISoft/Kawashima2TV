//#define debug_1
#define debug_2
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Diagnostics.PerformanceData;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Markup;
using System.Xml.Linq;
using Mitsubishi.McProtocol;
using SqliteDatabase.Models;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace NucPos123
{
  public partial class frmMain
  {
    private List<PlcMcProtocolController.PlcController> list_PlcMcProtocolControllers = new List<PlcMcProtocolController.PlcController>();

    //private frmMain _frmMain;
    private double value_chart_OLE_last = 0;
    private double value_chart_OR_last = 0;

    private void Def_OnAppNotifyEvent(object sender, AppCore.eNotifyEvent notifyEvent)
    {
      //throw new NotImplementedException();

      Configuration configuration = list_configurations.FirstOrDefault(s => s.IsUsed > 0);
      if (configuration == null) return;
      //if (configuration.PLC_IPAddress == "192.168.3.14")
      {
        PlcMcProtocolController.PlcController plcController = new PlcMcProtocolController.PlcController(configuration.PLC_IPAddress, configuration.Port);
        plcController.OnSendDataReceived += PlcController_OnSendDataReceived;


        List<DeviceBlock> deviceBlocks = new List<DeviceBlock>() { new DeviceBlock(DeviceType.D, 300, 30), //1
                                                                  new DeviceBlock(DeviceType.D, 330, 30), // 2
                                                                  new DeviceBlock(DeviceType.D, 360, 30), // 3
                                                                  new DeviceBlock(DeviceType.D, 390, 30),  // 4 Kawwa2
                                                                  new DeviceBlock(DeviceType.D, 420, 30), // 5 Packer
                                                                  new DeviceBlock(DeviceType.D, 450, 30),  // 6 Erector
                                                                  new DeviceBlock(DeviceType.D, 3900, 10), //7 DataPlan
                                                                  new DeviceBlock(DeviceType.D, 3922, 10), //8 Code Product
                                                                  new DeviceBlock(DeviceType.D, 3933, 20), //9 OP Name
                                                                  new DeviceBlock(DeviceType.D, 3954, 10), //10 Quality Days
                                                                  new DeviceBlock(DeviceType.D, 3965, 10), //11 Safety Days
                                                                  new DeviceBlock(DeviceType.D, 3987, 5), //12 Target OLE
                                                                  new DeviceBlock(DeviceType.D, 3993, 5), //13 Target OR
                                                                  new DeviceBlock(DeviceType.D, 4000, 60), //13 Name Product
                                                                  new DeviceBlock(DeviceType.D, 4060, 5) // 14 Nominal Speed

                                                                        };
        for (int idx = 0; idx < deviceBlocks.Count; idx++)
        {
          deviceBlocks[idx].Index = (idx + 1);
        }

        //--------------------------------------------------------------------------------------------
        plcController.Init(deviceBlocks);
        list_PlcMcProtocolControllers.Add(plcController);
      }


    }


    private void SetCounterOutInvoke(Label lblpm, Label lblcuc, double cuc, double pm)
    {
      cuc = cuc / 1000;
      try
      {
        lblpm.Invoke(new Action(() =>
        {
          if (lblpm.Text != $"{pm}")
          {
            lblpm.Text = $"{pm}";
          }
        }));
        lblcuc.Invoke(new Action(() =>
        {
          if (lblcuc.Text != $"{cuc}")
          {
            lblcuc.Text = $"{cuc}";
          }
        }));

      }
      catch (Exception ex)
      {
        //Console.WriteLine(ex.ToString());
      }
    }


    private double _last_status = 0;
    private void SetStatusMachine(double status, PictureBox pictureBox)
    {
      if (_last_status != status)
      {
        _last_status = status;
        switch (status)
        {
          case 0:
            pictureBox.Image = new Bitmap(Properties.Resources.Wating);
            break;
          case 1:
            pictureBox.Image = new Bitmap(Properties.Resources.Run);
            break;
          case 2:
            pictureBox.Image = new Bitmap(Properties.Resources.Stop);
            break;
        }
      }
    }

    public static string ConvertIntArrayToString(int[] data)
    {
      string ret = "";
      //int idx = 0;
      foreach (var val in data)
      {
        byte[] buff = BitConverter.GetBytes(val);
        ret += Encoding.UTF8.GetString(new byte[] { buff[0], buff[1] }, 0, 2);
      }
      ret = ret.Trim().Trim('\0').Replace("\0", "");
      return ret;
    }

    private double GetWeights(string nameProduct)
    {
      nameProduct = nameProduct.Replace(" ", "");
      double number = 0;
      string pattern = @"(\d+(\.\d+)?)\s*(g|G|Kg|KG|kg|kG)";
      Match match = Regex.Match(nameProduct, pattern);

      if (match.Success)
      {
        string matchValue = match.Value;

        if (matchValue.Contains("Kg") | matchValue.Contains("kg") | matchValue.Contains("KG") | matchValue.Contains("kG"))
        {
          try
          {
            Match match_weight = Regex.Match(matchValue, @"(\d+(\.\d+)?)");
            number = double.Parse(match_weight.Value) * 1000;  // Quy hàm trả về đơn vị g nếu sản phẩm là Kg
          }
          catch (Exception)
          {
          }
        }

        else if (matchValue.Contains("G") | matchValue.Contains("g"))
        {
          try
          {
            Match match_weight = Regex.Match(matchValue, @"(\d+(\.\d+)?)");
            number = double.Parse(match_weight.Value);
          }
          catch (Exception)
          {
          }
        }
        else
        {
          number = 0;
        }

      }
      return number;
    }


    public double total;
    private double CounterINFill = 0;
    private double CounterOUTFill = 0;
    double pmTotal;
    double cucTotal;
    int dataPlan;
    int dataQualityDay;
    int dataSafetyDay;
    double dataWeiger;
    int dataOLETarger;
    int dataORTarger;
    int nominalSpeed;
    int[] plan = new int[10];
    int[] codeProduct = new int[10];
    int[] titleProduct = new int[60];
    int[] nameStaff = new int[20];
    int[] qualityDay = new int[10];
    int[] safetyDay = new int[10];
    int[] OLETarget = new int[5];
    int[] ORTarget = new int[5];
    int[] NominalSPeed = new int[5];
    double Status;
    double CounterIN;
    double CounterOUT;
    double StateMachine;
    int MachineId;
    double PM;
    double CUC;
    double loss;


    private double _previousCounterOUT = -1;
    private void PlcController_OnSendDataReceived_old1(string ip_address, int blockIdex, int[] data, bool isEndMachine)
    {
      if (this.InvokeRequired)
      {
        this.Invoke(new Action(() =>
        {
          PlcController_OnSendDataReceived(ip_address, blockIdex, data, isEndMachine);
        }));
        return;
      }
      double nominalSpeed = 50;
      double LT = 8;
      //this.lblDateTime.Text =
      Configuration configuration = list_configurations.Find(x => x.PLC_IPAddress == ip_address);
      if (configuration != null)
      {
        try
        {
          if (blockIdex == 4 || blockIdex == 5 || blockIdex == 6)
          {
            CounterIN = data[1] << 16 | data[0];

            CounterOUT = data[3] << 16 | data[2];
            Status = data[23];
            MachineId = data[25];
            StateMachine = data[28];



            total = dataPlan * dataWeiger;

            //------------------------------

            CounterIN = (CounterIN < 0) ? (-1) * CounterIN : CounterIN;
            CounterOUT = (CounterOUT < 0) ? (-1) * CounterOUT : CounterOUT;
            PM = CounterIN - CounterOUT;
            CUC = PM * dataWeiger;


            if (blockIdex == 4)
            {
              CounterINFill = CounterIN;
              pmTotal = CounterINFill - CounterOUT;
              cucTotal = pmTotal * dataWeiger;
              double loss = (cucTotal / total) * 100;
              int OLE = (int)(CounterOUT / (nominalSpeed * 60 * LT)) * 100;





              if (this.lbLossSFGs.Text != cucTotal.ToString())
              {
                this.lbLossSFGs.Text = cucTotal.ToString();
              }
              this.lbLossSFGs.Text = cucTotal.ToString();
              if (this.lbLossPM.Text != $"{pmTotal.ToString()}")
              {
                this.lbLossPM.Text = $"{pmTotal.ToString()}";
              }

              if (CounterOUT.ToString() != this.lblActual.Text)
              {
                this.lblActual.Text = CounterOUT.ToString();
              }
             // this.lbLoss.Text = loss.ToString();
            }

            else if (blockIdex == 5)
            {
              SetCounterOutInvoke(this.lbPackerPM, this.lbPackerSFGs, CUC, PM);
              //SetStatusMachine(StateMachine, this.ptbPacker);
            }
            else if (blockIdex == 6)
            {
              if (this.lbErectorPM.Text != PM.ToString())
              {
                this.lbErectorPM.Text = PM.ToString();
              }
              //SetStatusMachine(StateMachine, this.ptbErector);
            }





          }

          //if (blockIdex == 4)
          //{
          //  CounterINFill = CounterIN;
          //  pmTotal = CounterINFill - CounterOUT;
          //  cucTotal = pmTotal * dataWeiger;
          //  double loss = (cucTotal / total) * 100;
          //  int OLE = (int)(CounterOUT / (nominalSpeed * 60 * LT)) * 100;






          //  this.lbLossSFGs.Text = cucTotal.ToString();
          //  this.lbLossPM.Text = pmTotal.ToString();
          //  this.lblActual.Text = CounterOUT.ToString();
          //  this.lbLoss.Text = loss.ToString();
          //  UpdateGaugeValue(gaugeOLE, OLE, dataOLETarger);


          //  //--- Calcuate OR
          //  int OR = 0;
          //  if (dataPlan > 0)
          //  {
          //    OR = (int)(((double)CounterOUT / dataPlan) * 100);
          //    OR = (OR > 100) ? 100 : OR;

          //    UpdateGaugeValue(gaugeOR, OR, dataORTarger);
          //    this.gaugeOR.Value = OR;
          //  }





          //  SetCounterOutInvoke(this.lbFillerPM, this.lbFillerSFGs, CUC, PM);
          //  SetStatusMachine(StateMachine, this.ptbFill);
          //}
          //else if (blockIdex == 5)
          //{
          //  SetCounterOutInvoke(this.lbPackerPM, this.lbPackerSFGs, CUC, PM);
          //  SetStatusMachine(StateMachine, this.ptbPacker);
          //}
          //else if (blockIdex == 6)
          //{
          //  this.lbErectorPM.Text = PM.ToString();
          //  SetStatusMachine(StateMachine, this.ptbErector);
          //}










        }
        catch
        {
        }
      }
    }

    private void PlcController_OnSendDataReceived(string ip_address, int blockIdex, int[] data, bool isEndMachine)
    {
      if (this.InvokeRequired)
      {
        this.Invoke(new Action(() =>
        {
          PlcController_OnSendDataReceived(ip_address, blockIdex, data, isEndMachine);
        }));
        return;
      }


      //double nominalSpeed = 50;
      //Totol Time Shift
      double LT = 8;
      Configuration configuration = list_configurations.Find(x => x.PLC_IPAddress == ip_address);
      if (configuration.LineName == "FOODS_KAWA2")
      {
        if (configuration != null)
        {
          try
          {
            // Fill_Kawa2;
            if (blockIdex == 4 || blockIdex == 5 || blockIdex == 6)
            {
              CounterIN = data[1] << 16 | data[0];
              CounterOUT = data[3] << 16 | data[2];
              Status = data[23];
              MachineId = data[25];
              StateMachine = data[28];

              total = dataPlan * dataWeiger;

              CounterIN = (CounterIN < 0) ? (-1) * CounterIN : CounterIN;
              CounterOUT = (CounterOUT < 0) ? (-1) * CounterOUT : CounterOUT;
              PM = CounterIN - CounterOUT;
              CUC = PM * dataWeiger;
            }


            if (blockIdex == 4)
            {
              CounterINFill = CounterIN;
              CounterOUTFill = CounterOUT;

              pmTotal = CounterINFill - CounterOUTFill;
              cucTotal = pmTotal * dataWeiger;
              // Correct
              if (total != 0)
              {
                //loss = (cucTotal / total) * 100;
                loss = (pmTotal / dataPlan) * 100;
                loss = Math.Round(loss, 2);
                loss = (loss > 100) ? 100 : loss;
                loss = (loss < 0) ? 0 : loss;
              }

              //--- Calcuate OLE
              double nominalSpeed_as_double = (double)(nominalSpeed * 60 * LT);
              double OLE = 0;
              if (nominalSpeed_as_double > 0)
              {
                OLE = (int)(((double)CounterOUT / nominalSpeed_as_double) * 100);
                OLE = (OLE > 100) ? 100 : OLE;
                OLE = (OLE < 0) ? 0 : OLE;

                if (OLE != value_chart_OLE_last)
                {
                  UpdateDataChart(gaugeOLE, OLE, dataOLETarger, lbProcessingValueOLE, lbTargetOLE);
                  value_chart_OLE_last = OLE;
                }
              }

              //--- Calcuate OR
              double OR = 0;
              if (dataPlan > 0)
              {
                OR = (int)(((double)CounterOUTFill / dataPlan) * 100);
                OR = (OR > 100) ? 100 : OR;
                OR = (OR < 0) ? 0 : OR;

                if (OR != value_chart_OR_last)
                {
                  UpdateDataChart(gaugeOR, OR, dataORTarger, lbProcessingValueOR, lbTargetOR);
                  value_chart_OR_last = OR;
                }


                // Dislay LOSS
                if (this.lbLossSFGs.Text != cucTotal.ToString())
                {
                  cucTotal = cucTotal / 1000; // Đổi sang kg
                  this.lbLossSFGs.Text = cucTotal.ToString();
                }

                if (this.lbLossPM.Text != pmTotal.ToString())
                {
                  this.lbLossPM.Text = pmTotal.ToString();
                }

                if (this.lbLoss.Text != $"{loss}%")
                {
                  this.lbLoss.Text = $"{loss}%";
                }

                // Dislay Actual CounterOUTFill|CounterOUT
                if (this.lblActual.Text != CounterOUTFill.ToString())
                {
                  this.lblActual.Text = CounterOUTFill.ToString();
                }

                SetCounterOutInvoke(this.lbFillerPM, this.lbFillerSFGs, CUC, PM);
                SetStatusMachine(StateMachine, this.ptbFill);
              }
            
              else if (blockIdex == 5)
              {
                SetCounterOutInvoke(this.lbPackerPM, this.lbPackerSFGs, CUC, PM);
                SetStatusMachine(StateMachine, this.ptbPacker);
              }
              else if (blockIdex == 6)
              {
                this.lbErectorPM.Text = PM.ToString();
                SetStatusMachine(StateMachine, this.ptbErector);
              }

              else if (blockIdex == 7)
              {
                ushort[] plan = new ushort[10];
                for (int i = 0; i < 10; i++)
                {
                  plan[i] = (ushort)data[i]; // Chuyển đổi từ int sang ushort
                }
                int[] intPlan = Array.ConvertAll(plan, item => (int)item);


                dataPlan = (ushort)data[0] + (ushort)data[1] * 65536;
                if (lblTarget.Text != dataPlan.ToString() && dataPlan >= 0)
                {
                  lblTarget.Text = dataPlan.ToString();
                }
              }
              else if (blockIdex == 8)
              {
                codeProduct = new int[10];
                for (int i = 0; i < codeProduct.Length; i++)
                {
                  codeProduct[i] = data[i];
                }
                string sCodeProduct = ConvertIntArrayToString(codeProduct);

                if (lbCodeProduct.Text != sCodeProduct)
                {
                  lbCodeProduct.Text = sCodeProduct;
                }

              }
              else if (blockIdex == 9)
              {
                nameStaff = new int[20];
                for (int i = 0; i < nameStaff.Length; i++)
                {
                  nameStaff[i] = data[i];
                }
                string sNameStaff = ConvertIntArrayToString(nameStaff);

                if (lbOperator.Text != sNameStaff)
                {
                  lbOperator.Text = sNameStaff;
                }

              }
              else if (blockIdex == 10)
              {
                qualityDay = new int[10];
                for (int i = 0; i < qualityDay.Length; i++)
                {
                  qualityDay[i] = data[i];
                }
                //string stitle_pre = ConvertIntArrayToString(dataPlan);
                dataQualityDay = qualityDay[0];

                if (lblQualityDay.Text != dataQualityDay.ToString())
                {
                  lblQualityDay.Text = dataQualityDay.ToString();
                  Properties.Settings.Default.NumbersQuality = dataQualityDay;
                  Properties.Settings.Default.Save();
                }

              }
              else if (blockIdex == 11)
              {
                safetyDay = new int[10];
                for (int i = 0; i < safetyDay.Length; i++)
                {
                  safetyDay[i] = data[i];
                }
                //string stitle_pre = ConvertIntArrayToString(dataPlan);
                dataSafetyDay = safetyDay[0];

                if (lblSafetyDay.Text != dataSafetyDay.ToString())
                {
                  lblSafetyDay.Text = dataSafetyDay.ToString();
                  Properties.Settings.Default.NumbersSafety = dataSafetyDay;
                  Properties.Settings.Default.Save();
                }

              }

              else if (blockIdex == 12)
              {
                OLETarget = new int[5];
                for (int i = 0; i < OLETarget.Length; i++)
                {
                  OLETarget[i] = data[i];
                }
                //string stitle_pre = ConvertIntArrayToString(dataPlan);
                dataOLETarger = OLETarget[0];
                //if (lbOLETarget.Text != $"{dataOLETarger.ToString()}%")
                //{
                //  lbOLETarget.Text = $"{dataOLETarger.ToString()}%";
                //}

              }
              else if (blockIdex == 13)
              {
                ORTarget = new int[5];
                for (int i = 0; i < ORTarget.Length; i++)
                {
                  ORTarget[i] = data[i];
                }
                //string stitle_pre = ConvertIntArrayToString(dataPlan);
                dataORTarger = ORTarget[0];
                //if (lbORTarget.Text != $"{dataORTarger.ToString()}%")
                //{
                //  lbORTarget.Text = $"{dataORTarger.ToString()}%";
                //}

              }
              else if (blockIdex == 14)
              {
                titleProduct = new int[60];
                for (int i = 0; i < titleProduct.Length; i++)
                {
                  titleProduct[i] = data[i];
                }
                string stitle_pre = ConvertIntArrayToString(titleProduct);
                //string stitle_g = GetWeight(stitle_pre);

                try
                {
                  //dataWeiger = int.Parse(stitle_g);
                  dataWeiger = GetWeights(stitle_pre);
                }
                catch (Exception)
                {
                }

                if (this.lnNameProduct.Text != stitle_pre)
                {
                  this.lnNameProduct.Text = stitle_pre;
                }
              }
              // Nominal Speed
              else if (blockIdex == 15)
              {
                NominalSPeed = new int[5];
                for (int i = 0; i < NominalSPeed.Length; i++)
                {
                  NominalSPeed[i] = data[i];
                }
                if (nominalSpeed != NominalSPeed[0])
                {
                  nominalSpeed = NominalSPeed[0];
                }
                if (nominalSpeed <= 0)
                {
                  nominalSpeed = 45;
                }


              }
            }
          }
          catch (Exception ex)
          {
            Console.WriteLine(ex.Message);
          }
        }
      }

    }


  }
}

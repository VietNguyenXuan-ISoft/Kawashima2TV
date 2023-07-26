using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Mitsubishi.McProtocol;
using SqliteDatabase.Models;
using System.Windows.Forms.DataVisualization.Charting;
using LiveCharts;
using LiveCharts.Wpf;
using SeriesCollection = LiveCharts.SeriesCollection;
using System.Windows;
using LiveCharts.Configurations;
using static System.Net.WebRequestMethods;
using System.Windows.Media;
using System.Data.SqlTypes;
using Color = System.Drawing.Color;
using System.Text.RegularExpressions;
using System.Net.NetworkInformation;
using Series = System.Windows.Forms.DataVisualization.Charting.Series;
using LiveCharts.Wpf.Charts.Base;
using Chart = System.Windows.Forms.DataVisualization.Charting.Chart;
using Newtonsoft.Json.Linq;

namespace NucPos123
{
  public partial class frmMain : Form
  {
    private Timer timer = new Timer();
    private DateTime currentDate = DateTime.Now;
    private List<Configuration> list_configurations = new List<Configuration>();
    private bool is_load_config_done = false;
    
    public frmMain()
    {
      InitializeComponent();
      Properties.Settings.Default.PropertyChanged += OnSettingChanged;
      timer.Interval = 3000;
      timer.Tick += Timer_Tick;
      timer.Enabled = true;
      DisplayCurrentDateAndShift();

      

      this.Load += FrmMain_Load;
      //this.Load += Form1_LoadAsync;
      this.FormClosing += FrmMain_FormClosing;

      //
      this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
      this.backgroundWorker1.WorkerReportsProgress = true;
      this.backgroundWorker1.WorkerSupportsCancellation = true;
      this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
      this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
      this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);




      SetupLoadConfig();
    }

    

    //private void FrmMain_Load(object sender, EventArgs e)
    //{
    //  throw new NotImplementedException();
    //}

    private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
    {


#if UseMcProtocol
      list_PlcMcProtocolControllers.ForEach(x=>x.DeInit());
#endif
    }

    
    

    private void FrmMain_Load(object sender, EventArgs e)
    {

      if (this.loadconfig_backgroundWorker1.IsBusy == false)
      {
        this.loadconfig_backgroundWorker1.RunWorkerAsync();
      }
     
      AppCore.Def.OnAppNotifyEvent += Def_OnAppNotifyEvent;

      if (this.backgroundWorker1.IsBusy == false)
      {
        this.backgroundWorker1.RunWorkerAsync();
      }

      ChartInit();
    }

    private void DisplayCurrentDateAndShift()
    {
      int eShift = GetShift();
      DateTime datetime = GetDate();
      //
      string shift = ((int)(eShift)).ToString();
      string date = datetime.ToString("dd/MM/yyyy");
      if (lbShift.Text != eShift.ToString())
      {
        lbShift.Text = eShift.ToString();
      }
      //lbDateTime.Text = datetime.ToString();
    }
    private void Timer_Tick(object sender, EventArgs e)
    {
      this.timer.Enabled = false;
      DisplayCurrentDateAndShift();

      int Seconds = DateTime.Now.Second;
      if (Seconds % 30 == 0)
      {
        if (this.backgroundWorker1.IsBusy == false)
        {
          this.backgroundWorker1.RunWorkerAsync();
        }
      }


      //SetPlan(this.lblPlan_Pos1,"10000");
      //SetPlan(this.lblPlan_Pos2, "20000");
      //SetPlan(this.lblPlan_Pos3, "30000");


      this.timer.Enabled = true;
    }


    private int GetShift()
    {
      eShift shift = eShift.Shift_3;
      int hour = DateTime.Now.Hour;

      if ((hour >= 6) && (hour < 14))
      {
        shift = eShift.Shift_1;
      }
      else if ((hour >= 14) && (hour < 22))
      {
        shift = eShift.Shift_2;
      }

      int shiftValue = (int)shift; // Ép kiểu enum thành int

      return shiftValue;
    }

    private DateTime GetDate()
    {
      DateTime datetime = DateTime.Now;
      int eShift = GetShift();
      if (eShift == 3)
      {
        int hour = DateTime.Now.Hour;
        if ((hour >= 0) && (hour < 6))
        {
          datetime = datetime.AddDays(-1);
        }
      }
      return datetime;
    }

    
   

    private string convertAddressToString(int start_address)
    {
      string str = start_address.ToString();
      str = str.PadLeft(4, '0');
      return str;
    }

    private enum eShift
    {
      Shift_1 = 1,
      Shift_2 = 2,
      Shift_3 = 3,
    }

    private enum Line
    {
      Posimat_1,
      Posimat_2,
      Posimat_3,
    }

    public class FX_DATA
    {
      public int address = 0;
      public int value = 0;
      public string device_as_string = "";
      public int max_device = 0;
      //


      public FX_DATA()
      {
      }


    }

    private void ChartInit()
    {
      // Cvt color to brush
      System.Windows.Media.Color colorOLE = System.Windows.Media.Color.FromRgb(255, 255,255);
      SolidColorBrush brushOLE = new SolidColorBrush(colorOLE);

      //gaugeOLE.From = 0;
      //gaugeOLE.To = 100;
      //gaugeOLE.Foreground = brushOLE;
      //gaugeOLE.FromColor = System.Windows.Media.Color.FromRgb(255, 255,0);
      //gaugeOLE.ToColor = System.Windows.Media.Color.FromRgb(255, 255,0); //47, 100, 168
      //gaugeOLE.InnerRadius = 90;
      //gaugeOLE.IsEnabled = false;
      //gaugeOLE.LabelsVisibility = Visibility.Hidden;
      //gaugeOLE.La = false;


      // Cvt color to brush
      System.Windows.Media.Color colorOR = System.Windows.Media.Color.FromRgb(255,255,255);
      SolidColorBrush brushOR = new SolidColorBrush(colorOR);

      //gaugeOR.From = 0;
      //gaugeOR.To = 100;
      //gaugeOR.Foreground = brushOR;
      //gaugeOR.FromColor = System.Windows.Media.Color.FromRgb(255,255,0); //191, 121, 144
      //gaugeOR.ToColor = System.Windows.Media.Color.FromRgb(255,255,0); 
      //gaugeOR.InnerRadius = 90;
      //gaugeOR.IsEnabled = false;
      //gaugeOR.LabelsVisibility = Visibility.Hidden;


      //string nameProduct = "dkvdkfngd 16x200Kg sdvgdfhb";
      ////string nameProduct = "dkvdkfngd 16x200 Kg sdvgdfhb";

      ////string nameProduct = "dkvdkfngd 16x200KG sdvgdfhb";

      ////string nameProduct = "dkvdkfngd 16x200Kg sdvgdfhb";

      ////string nameProduct = "dkvdkfngd 16x200Kg sdvgdfhb";
      //string a = "";
      //string case_1 = "dkvdkfngd 16x1.5Kg sdvgdfhb";
      //double case1 = GetWeights(case_1);

      //string case_2 = "dkvdkfngd 16x1.8kg sdvgdfhb";
      //double case2 = GetWeights(case_2);

      //string case_3 = "dkvdkfngd 16x2KG sdvgdfhb";
      //double case3 = GetWeights(case_3);

      //string case_4 = "dkvdkfngd 16x5.6kG sdvgdfhb";
      //double case4 = GetWeights(case_4);


      //string case_5 = "dkvdkfngd 16x200g sdvgdfhb";
      //double case5 = GetWeights(case_5);

      //string case_6 = "dkvdkfngd 16x400G sdvgdfhb";
      //double case6 = GetWeights(case_6);

      //string case_7 = "dkvdkfngd 16x650 g sdvgdfhb";
      //double case7 = GetWeights(case_7);

      //string case_8 = "dkvdkfngd 16x700 g sdvgdfhb";
      //double case8 = GetWeights(case_8);

      //a += $"{case_1} => {case1} \n" +
      //  $"{case_2} => {case2} \n" +
      //  $"{case_3} => {case3} \n" +
      //  $"{case_4} => {case4} \n" +
      //  $"{case_5} => {case5} \n" +
      //  $"{case_6} => {case6} \n" +
      //  $"{case_7} => {case7} \n" +
      //  $"{case_8} => {case8} \n";

      //System.Windows.Forms.MessageBox.Show(a.ToString());



    }

    //private double GetWeights(string nameProduct)
    //{
    //  nameProduct = nameProduct.Replace(" ", "");
    //  double number = 0;
    //  //string pattern = @"\d+\s*(g|G|Kg|KG|kg)";
    //  string pattern = @"(\d+(\.\d+)?)\s*(g|G|Kg|KG|kg|kG)"; 
    //  Match match = Regex.Match(nameProduct, pattern);

    //  if (match.Success)
    //  {
    //    string matchValue = match.Value;
        
    //    if (matchValue.Contains("Kg") | matchValue.Contains("kg") | matchValue.Contains("KG") | matchValue.Contains("kG"))
    //    {
    //      try
    //      {
    //        Match match_weight = Regex.Match(matchValue, @"(\d+(\.\d+)?)");
    //        number = double.Parse(match_weight.Value) * 1000;  // Quy hàm trả về đơn vị g nếu sản phẩm là Kg
    //      }
    //      catch (Exception)
    //      {
    //      }
    //    }

    //    else if (matchValue.Contains("G") | matchValue.Contains("g"))
    //    {
    //      try
    //      {
    //        Match match_weight = Regex.Match(matchValue, @"(\d+(\.\d+)?)");
    //        number = double.Parse(match_weight.Value);
    //      }
    //      catch (Exception)
    //      {
    //      }
    //    }
    //    else
    //    {
    //      number = 0;
    //    } 
        
    //  }
    //  return number;
    //}



    private void UpdateGaugeValue(Gauge nameGauge,double newValue, double target, Label lbValue)
    {
      if (nameGauge.Value != newValue)
      {
        nameGauge.Value = newValue;
        lbValue.Text = $"{newValue}%";
      }  

      if (newValue > target)
      {
        if (nameGauge.FromColor != System.Windows.Media.Color.FromRgb(0, 255, 0))
        {
          nameGauge.FromColor = System.Windows.Media.Color.FromRgb(0, 255, 0);
        }

        if (nameGauge.ToColor != System.Windows.Media.Color.FromRgb(0, 255, 0))
        {
          nameGauge.ToColor = System.Windows.Media.Color.FromRgb(0, 255, 0);
        }

        if (lbValue.ForeColor != Color.FromArgb(0, 255, 0))
        {
          lbValue.ForeColor = Color.FromArgb(0, 255, 0);
        }

      }
      else
      {
        if (nameGauge.FromColor != System.Windows.Media.Color.FromRgb(255, 255, 0))
        {
          nameGauge.FromColor = System.Windows.Media.Color.FromRgb(255, 255, 0);
        }

        if (nameGauge.ToColor != System.Windows.Media.Color.FromRgb(255, 255, 0))
        {
          nameGauge.ToColor = System.Windows.Media.Color.FromRgb(255, 255, 0);
        }
        if (lbValue.ForeColor != Color.FromArgb(255, 255, 0))
        {
          lbValue.ForeColor = Color.FromArgb(255, 255, 0);
        }
      }

    }

    public void UpdateDataChart(Chart name_chart,double process_value, double set_point, Label name_lable_processing_value, Label name_lable_target_value)
    {
      name_chart.Series.Clear();
      Series series = new Series("Series");
      series.ChartType = SeriesChartType.Doughnut;

      double PV = process_value * 1.8;
      double SP = (process_value < set_point) ? (set_point - process_value) * 1.8 : 0;
      double other = 180 - SP - PV;

      // Thêm data vào series
      DataPoint point_PV = new DataPoint(0, PV);
      DataPoint point_SP = new DataPoint(0, SP);
      DataPoint point_other = new DataPoint(0, other);
      DataPoint point_delete = new DataPoint(0, 180);

      series.Points.Add(point_PV);
      series.Points.Add(point_SP);
      series.Points.Add(point_other);
      series.Points.Add(point_delete);

      // Dislay color series
      point_PV.Color = (process_value < set_point) ? Color.FromArgb(255, 255, 0) : Color.FromArgb(0, 255, 0);
      point_SP.Color = Color.FromArgb(0, 255, 0);
      point_other.Color = Color.FromArgb(10, 50, 119);
      point_delete.Color = Color.Transparent;

      name_chart.Series.Add(series);
      name_chart.Series["Series"]["PieStartAngle"] = "180";
      name_chart.Series["Series"]["DoughnutRadius"] = "30"; //Thay đổi độ rộng chart

      name_lable_processing_value.Text = $"{process_value}%";
      name_lable_target_value.Text = $"Target: {set_point}%";
    }

    private void tmrDateTime_Tick(object sender, EventArgs e)
    {
      tmrDateTime.Stop();

      Random rd = new Random();
      double a = Math.Round(rd.NextDouble() * 100, 0);
      double b = Math.Round(rd.NextDouble() * 100, 0);
      //lbOLETarget.Text = "90%";
      //lbORTarget.Text = "70%";

      //UpdateGaugeValue(gaugeOLE, a, 90, lbCurrentOLE);
      //UpdateGaugeValue(gaugeOR, b, 70, lbCurrentOR);

      UpdateDataChart(gaugeOLE, a, 77, lbProcessingValueOLE, lbTargetOLE);
      UpdateDataChart(gaugeOR, b, 85, lbProcessingValueOR, lbTargetOR);





      DateTime dateSafety = ConverStrToDateTime(Properties.Settings.Default.SafetyDay);
      DateTime dateQuality = ConverStrToDateTime(Properties.Settings.Default.QualityDay);

      int numberOfDaysSafety= -dateSafety.Subtract(DateTime.Now).Days;
      int numberOfDaysQuality = -dateQuality.Subtract(DateTime.Now).Days;

      lblSafetyDay.Text = numberOfDaysSafety.ToString();
      lblQualityDay.Text = numberOfDaysQuality.ToString();

      tmrDateTime.Start();
    }


    private void OnSettingChanged(object sender, PropertyChangedEventArgs e)
    {
      if (e.PropertyName == "NumbersSafety" || e.PropertyName == "NumbersQuality")
      {
        try
        {
          DateTime datetimeSafety = CalculateDateFromDays(Properties.Settings.Default.NumbersSafety);
          DateTime datetimeQuality = CalculateDateFromDays(Properties.Settings.Default.NumbersQuality);

          if (datetimeSafety.ToString() != Properties.Settings.Default.SafetyDay)
          {
            Properties.Settings.Default.SafetyDay = datetimeSafety.ToString();
            Properties.Settings.Default.Save();
          }
          if (datetimeQuality.ToString() != Properties.Settings.Default.QualityDay)
          {
            Properties.Settings.Default.QualityDay = datetimeQuality.ToString();
            Properties.Settings.Default.Save();
          }
        }
        catch (Exception)
        {
        }

      }

    }

    private DateTime CalculateDateFromDays(int numberOfDays)
    {
      DateTime currentDate = DateTime.Now;
      DateTime resultDate = currentDate.AddDays(-numberOfDays);
      return resultDate;
    }

    private DateTime ConverStrToDateTime(string datetime)
    {
      DateTime now = DateTime.Now;
      try
      {
        if (datetime != "")
        {
          now = Convert.ToDateTime(datetime);
        }
      }
      catch
      {
      }
      return now;
    }

    private void tableLayoutPanel13_Paint(object sender, PaintEventArgs e)
    {

    }
  }
}

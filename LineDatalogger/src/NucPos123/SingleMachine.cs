using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace NucPos123
{
  public partial class SingleMachine : UserControl
  {
    private string _machineName;
    private int _counterIn;
    private int _counterOut;
    private int _speed;
    private int _statemachine;
    private DateTime _lastupdate;
    private bool _is_error = false;
    public SingleMachine()
    {
      InitializeComponent();
    }

    public string MachineName
    {
      get { return _machineName; } 
      set { this.lblLineName.Text = value; }
    }

    public int CounterIn
    {
      get { return _counterIn; }
      set { this.lblCounterIn.Text = value.ToString(); }
    }
    public int CounterOut
    {
      get { return _counterOut; }
      set { this.lblCounterOut.Text = value.ToString(); }
    }
    public int Speed
    { get { return _speed; } set { this.lblSpeed.Text = value.ToString(); } 
    }


    public void SetLastUpdate(DateTime dt)
    {
     // this.lblLastUpdate.Text = $"LastUpdate: {value.ToyyyyMMddHHmmss()}";
      lblLastUpdate.Invoke(new Action(() =>
      {
        lblLastUpdate.Text = $"LastUpdate: {dt.ToyyyyMMddHHmmss()}";
      }));
      this._lastupdate = dt;
    }


    public DateTime LastUpdate
    {
      get { return _lastupdate; }    
    }
    public bool IsError
    {
      get { return _is_error; }
      set { this._is_error = value; }
    }


    public void SetStatemachine(int statemachine, int losscode, bool error)
    {
      this._is_error = error;
      if (error == false)
      {        
        Color back_color = (losscode > 0) ? Color.Red : Color.Green;
        Color fore_color = (losscode > 0) ? Color.White : Color.White;
        string text = (losscode > 0) ? "STOP" : "RUN";

        this.lblStatus.Invoke(new Action(() =>
        {
          this.lblStatus.Text = text;
          this.lblStatus.BackColor = back_color;
          this.lblStatus.ForeColor = fore_color;
        }));


        this.lblLineName.Invoke(new Action(() =>
        {
          this.lblLineName.BackColor = back_color;
          this.lblLineName.ForeColor = fore_color;
        }));
        //
        
      }
      else
      {
        this.lblStatus.Invoke(new Action(() =>
        {
          this.lblStatus.Text = "ERROR";
          this.lblStatus.BackColor = Color.Yellow;
          this.lblStatus.ForeColor = Color.Black;
        }));

        this.lblLineName.Invoke(new Action(() =>
        {
          this.lblLineName.BackColor = Color.Yellow;
          this.lblLineName.ForeColor = Color.Black;
        }));

        //
        
      }
    }

  }
}

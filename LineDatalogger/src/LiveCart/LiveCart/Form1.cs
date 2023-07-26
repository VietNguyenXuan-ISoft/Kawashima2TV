using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LiveCart
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();


            solidGauge1.Uses360Mode = true;
            solidGauge1.From = 0;
            solidGauge1.To = 100;
            solidGauge1.Value = 50;




            solidGauge2.Uses360Mode = true;
            solidGauge2.From = 0;
            solidGauge2.To = 100;
            solidGauge2.Value = 50;




            solidGauge3.From = 0;
            solidGauge3.To = 100;
            solidGauge3.Value = 50;



            solidGauge4.From = 0;
            solidGauge4.To = 100;
            solidGauge4.Value = 60;
            solidGauge4.Base.LabelsVisibility = System.Windows.Visibility.Hidden;
            solidGauge4.Base.GaugeActiveFill = new System.Windows.Media.LinearGradientBrush
            {

                GradientStops=new System.Windows.Media.GradientStopCollection
                {
                    new System.Windows.Media.GradientStop(System.Windows.Media.Colors.Green,.5),
                    new System.Windows.Media.GradientStop(System.Windows.Media.Colors.Red,0),
                    new System.Windows.Media.GradientStop (System.Windows.Media.Colors.Blue,1)
                }

            };






        }
    }
}

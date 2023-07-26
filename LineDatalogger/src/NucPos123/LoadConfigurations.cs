using Newtonsoft.Json;
using SqliteDatabase.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NucPos123
{
    public partial class frmMain
    {
        private System.ComponentModel.BackgroundWorker loadconfig_backgroundWorker1;

        private void SetupLoadConfig()
        {
            this.loadconfig_backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.loadconfig_backgroundWorker1.WorkerReportsProgress = true;
            this.loadconfig_backgroundWorker1.WorkerSupportsCancellation = true;
            this.loadconfig_backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.loadconfig_backgroundWorker1_DoWork);
            this.loadconfig_backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.loadconfig_backgroundWorker1_RunWorkerCompleted);
            this.loadconfig_backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.loadconfig_backgroundWorker1_ProgressChanged);

            //

        }

        private void loadconfig_backgroundWorker1_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            string[] configs = Directory.GetFiles(System.Windows.Forms.Application.StartupPath, "*.s3db");
            int id = 1;
            foreach (string config in configs)
            {
                //FileInfo fileInfo = new FileInfo(config);
                string dest = Path.Combine(System.Windows.Forms.Application.StartupPath, config);
                SqliteDatabase.SqliteConfigurationContext contextA = new SqliteDatabase.SqliteConfigurationContext(dest, "");
                List<Configuration> configurations = contextA.Configurations.Where(x => x.IsUsed > 0).ToList();
                foreach (Configuration configuration in configurations)
                {
                    configuration.SetMachines(contextA.Machiness.FindAll(x => x.LineId == configuration.Id));
                    configuration.SetCommId(id);
                    //configuration.
                }


                list_configurations.AddRange(configurations);
                contextA.Close();
                id++;
                //contextA.Machiness.ForEach(x => contextA.Configurations.list_Machine_and_datalogs.Add(MachineAndDatalogs.Copy(x, configuration.LineName, configuration.Factory)));
            }
            int mm = 0;
            //string dest = Path.Combine(System.Windows.Forms.Application.StartupPath, _new_a);
            //SqliteDatabase.SqliteConfigurationContext contextA = new SqliteDatabase.SqliteConfigurationContext(dest, _new_b);
        }

        private void loadconfig_backgroundWorker1_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
      if (e.Cancelled)
      {
      }
      else
      {
        if (e.Error != null)
        {
        }
        else
        {
          int id = 1;
           

          if (list_configurations.Count > 0)
          {
            Configuration configuration = list_configurations[0];

            MapMachine(configuration);
          }

          if (Directory.Exists($"C:\\Dfos") == false)
          {
            Directory.CreateDirectory($"C:\\Dfos");
          }
          else
          {
            foreach (Configuration configuration in list_configurations)
            {
              if (Directory.Exists($"C:\\Dfos\\{configuration.LineName}") == false)
              {
                Directory.CreateDirectory($"C:\\Dfos\\{configuration.LineName}");
              }
            }
          }
          is_load_config_done = true;


          AppCore.Def.StartNotifyEvent(AppCore.eNotifyEvent.LoadConfigurationDone);


        }
      }
    }

        private void MapMachine(Configuration configuration)
        {
            //this.lblLineName.Text = configuration.LineName;
            //for (int i = 0; i < this.flowLayoutPanel1.Controls.Count; i++)
            //{
            //    if (this.flowLayoutPanel1.Controls[i] is SingleMachine)
            //    {
            //        SingleMachine singleMachine = (SingleMachine)(this.flowLayoutPanel1.Controls[i]);
            //        singleMachine.Visible = false;
            //        List<Machines> machines = configuration.GetMachines();
            //        if (i < machines.Count)
            //        {
            //            singleMachine.Visible = machines[i].IsUsed.ToBool();
            //            singleMachine.MachineName = $"{machines[i].id}.{machines[i].MachineName}\r\n{configuration.PLC_IPAddress}";
            //            singleMachine.Tag = new Tuple<Configuration, Machines>(configuration, machines[i]);
            //            singleMachine.CounterIn = machines[i].GetCounterIN();
            //            singleMachine.CounterOut = machines[i].GetCounterOUT();
            //            singleMachine.Speed = machines[i].GetCurrentSpeed();
            //            singleMachine.SetLastUpdate(machines[i].GetLastUpdate());
            //            singleMachine.SetStatemachine(machines[i].GetStateMachine(), machines[i].GetCurrentLossCode(), machines[i].GetError());
            //        }
            //    }/*if (this.flowLayoutPanel1.Controls[i] is SingleMachine)*/
            //}/*for (int i = 0; i < this.flowLayoutPanel1.Controls.Count; i++)*/
        }
        private void Button1_Click(object sender, EventArgs e)
        {
            //for (int i = 0; i < this.flowLayoutPanel2.Controls.Count; i++)
            //{
            //    if (this.flowLayoutPanel2.Controls[i] is System.Windows.Forms.Button)
            //    {
            //        System.Windows.Forms.Button button_config = (System.Windows.Forms.Button)(this.flowLayoutPanel2.Controls[i]);
            //        button_config.BackColor = Color.LightGray;
            //    }
            //}
            //if (sender is System.Windows.Forms.Button)
            //{
            //    System.Windows.Forms.Button button_config = (System.Windows.Forms.Button)(sender);
            //    if (button_config.Tag != null)
            //    {
            //        if (button_config.Tag is Configuration)
            //        {
            //            Configuration configuration = (Configuration)button_config.Tag;
            //            this.lblLineName.Text = configuration.LineName;
            //            MapMachine(configuration);
            //        }
            //    }
            //    button_config.BackColor = Color.Orange;
            //}
        }

        private void loadconfig_backgroundWorker1_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
        }
    }
}

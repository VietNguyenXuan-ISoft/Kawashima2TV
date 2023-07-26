//#define enable_load_excel
using Mitsubishi.McProtocol;
using Newtonsoft.Json;
using PlanData;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.PerformanceData;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NucPos123
{

    public partial class frmMain
    {
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private string plan_output = "";
        private void backgroundWorker1_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            try
            {
                using (Process myProcess = new Process())
                {
                    plan_output = "";
                    string executablePath = String.Format("{0}\\{1}.exe", Application.StartupPath, "Excelxlsb");
                    //  string option_1 = $"-input \"{file_to_load.FullName}\" -stdout";
                    myProcess.StartInfo.UseShellExecute = false;
                    // You can start any process, HelloWorld is a do-nothing example.
                    myProcess.StartInfo.FileName = executablePath;
                    myProcess.StartInfo.CreateNoWindow = true;
                    //myProcess.StartInfo.Arguments = option_1;
                    myProcess.StartInfo.UseShellExecute = false;
                    myProcess.StartInfo.RedirectStandardOutput = true;

                    myProcess.Start();
                    //Synchronously read the standard output of the spawned process.
                    StreamReader reader = myProcess.StandardOutput;
                    plan_output = reader.ReadToEnd();

                    myProcess.WaitForExit();



                    //List<Worksheet> Worksheets = JsonConvert.DeserializeObject<List<Worksheet>>(output);
                }
            }
            catch
            {

            }
            //if ((_configuration.Product_Plan_File != "") && (_file_full_path != null))
            //{
            //  LoadDailyProductionPlan(_configuration, _file_full_path);
            //}/*if ((_configuration.Product_Plan_File != "") && (_file_full_path != null))*/
        }
        private enum DayOfWeekTmp
        {
            Monday = 2,
            Tuesday = 3,
            Wednesday = 4,
            Thursday = 5,
            Friday = 6,
            Saturday = 7,
            Sunday = 8,
        }
        private void SetPlan(Label lblPlan, string plan)
        {
            lblPlan.Invoke(new Action(() =>
            {
                lblPlan.Text = $"{plan}";
            }));
        }


        private void backgroundWorker1_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            //if (e.Cancelled)
            //{
            //}
            //else
            //{
            //    if (e.Error != null)
            //    {
            //    }
            //    else
            //    {
            //        List<List<PlanData.PlanData>> deserializedPlanData = JsonConvert.DeserializeObject<List<List<PlanData.PlanData>>>(plan_output);
            //        if (deserializedPlanData != null)
            //        {
            //            eShift eShift = GetShift();
            //            DateTime datetime = GetDate();
            //            for (int i = 0; i < deserializedPlanData.Count; i++)
            //            {
            //                List<PlanData.PlanData> plans = deserializedPlanData[i];
            //                for (int j = 0; j < plans.Count; j++)
            //                {
            //                    PlanData.PlanData plan = plans[j];
            //                    DayOfWeekTmp dayOfWeek = (DayOfWeekTmp)plan.Day;

            //                    if (datetime.DayOfWeek.ToString() == dayOfWeek.ToString())// && ((int)(eShift)) == plan.sh
            //                    {
            //                        if (eShift == eShift.Shift_1)
            //                        {
            //                            if (plan.Id == 1)
            //                            {
            //                                // this.lblPlan_Pos1.Text = plan.Shift_1.ToString();
            //                                SetPlan(this.lblPlan_Pos1, plan.Shift_1.ToString());
            //                            }
            //                            else if (plan.Id == 2)
            //                            {
            //                                //this.lblPlan_Pos2.Text = plan.Shift_1.ToString();
            //                                SetPlan(this.lblPlan_Pos2, plan.Shift_1.ToString());
            //                            }
            //                            else if (plan.Id == 3)
            //                            {
            //                                // this.lblPlan_Pos3.Text = plan.Shift_1.ToString();
            //                                SetPlan(this.lblPlan_Pos3, plan.Shift_1.ToString());

            //                            }
            //                        }
            //                        else if (eShift == eShift.Shift_2)
            //                        {
            //                            if (plan.Id == 1)
            //                            {
            //                                //this.lblPlan_Pos1.Text = plan.Shift_2.ToString();
            //                                SetPlan(this.lblPlan_Pos1, plan.Shift_2.ToString());
            //                            }
            //                            else if (plan.Id == 2)
            //                            {
            //                                //this.lblPlan_Pos2.Text = plan.Shift_2.ToString();
            //                                SetPlan(this.lblPlan_Pos2, plan.Shift_2.ToString());
            //                            }
            //                            else if (plan.Id == 3)
            //                            {
            //                                //this.lblPlan_Pos3.Text = plan.Shift_2.ToString();
            //                                SetPlan(this.lblPlan_Pos3, plan.Shift_2.ToString());
            //                            }
            //                        }
            //                        else if (eShift == eShift.Shift_3)
            //                        {
            //                            if (plan.Id == 1)
            //                            {
            //                                //this.lblPlan_Pos1.Text = plan.Shift_3.ToString();
            //                                SetPlan(this.lblPlan_Pos1, plan.Shift_3.ToString());
            //                            }
            //                            else if (plan.Id == 2)
            //                            {
            //                                // this.lblPlan_Pos2.Text = plan.Shift_3.ToString();
            //                                SetPlan(this.lblPlan_Pos2, plan.Shift_3.ToString());
            //                            }
            //                            else if (plan.Id == 3)
            //                            {
            //                                // this.lblPlan_Pos3.Text = plan.Shift_3.ToString();
            //                                SetPlan(this.lblPlan_Pos3, plan.Shift_3.ToString());
            //                            }
            //                        }

            //                    }
            //                }
            //            }
            //        }
            //    }
            //}
        }
        private void backgroundWorker1_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
        }
    }
}

//using Aspose.Cells;
//#define enable_writelog
using Aspose.Cells;
using Newtonsoft.Json;
using OfficeOpenXml;
using OfficeOpenXml.FormulaParsing.Excel.Functions.Math;
using OfficeOpenXml.FormulaParsing.Excel.Functions.RefAndLookup;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PlanData;
using OfficeOpenXml.Style;
using System.Threading;

namespace Excelxlsb
{
  internal class Program
  {
    //private const string folder_paths = "C:\\Daily Production Plan"; //C:\Users\NucPos123\Unilever\CU CHI SUPPLY - 2022
    // private const string folder_paths = "C:\\Users\\NucPos123\\Unilever\\CU CHI SUPPLY - 2022";
    private const string folder_paths = "C:\\Users\\NucPos123\\Unilever";//\\CU CHI SUPPLY - CC-HCL\\2023";
    private const string file_path = "HCL Daily Production Plan W39R5.xlsb";
    static void Main(string[] args)
    {
      PareXlsbByAspose(file_path);


      //FileInfo dest_file_info = new FileInfo("HCL Daily Production Plan W39R5.xlsb");
      //ExcelPackage package = new ExcelPackage(dest_file_info);
      //ExcelWorkbook workBook = package.Workbook;
      //if (workBook != null)
      //{
      //  if (workBook.Worksheets.Count > 0)
      //  {
      //    for (int i = 1; i < workBook.Worksheets.Count; i++)
      //    {
      //      Console.WriteLine("Worksheet: " + workBook.Worksheets[i].Name);
      //    }
      //  }
      //}

    }
    private enum eShift
    {
      Shift_1 = 1,
      Shift_2 = 2,
      Shift_3 = 3,
    }
    private static eShift GetShift()
    {
      eShift eShift = eShift.Shift_3;
      int hour = DateTime.Now.Hour;
      if ((hour >= 6) && (hour < 14))
      {
        eShift = eShift.Shift_1;
      }
      else if ((hour >= 14) && (hour < 22))
      {
        eShift = eShift.Shift_2;
      }
      return eShift;
    }

    private static DateTime GetDate()
    {
      DateTime datetime = DateTime.Now;
      eShift eShift = GetShift();
      if (eShift == eShift.Shift_3)
      {
        int hour = DateTime.Now.Hour;
        if ((hour >= 0) && (hour < 6))
        {
          datetime = datetime.AddDays(-1);
        }
      }
      return datetime;
    }

    //private st
    //static getPath
    static void PareXlsbByAspose(string file_path)
    {
      DateTime datetime = GetDate();
      string year = datetime.Year.ToString();
      int week_id = ISOWeek.GetWeekOfYear(datetime);
      string Week = $"W{week_id.ToString().PadLeft(2,'0')}";
      List<string> directories = Directory.GetDirectories(folder_paths).ToList();


      var dir = new DirectoryInfo(folder_paths);
      FileInfo[] files = dir.GetFiles("*.xlsb", SearchOption.AllDirectories);

      using (System.IO.StreamWriter w = System.IO.File.AppendText("log.txt"))
      {
        List<FileInfo> list_file_info = files.ToList().FindAll(x => x.FullName.Contains(Week) && x.FullName.Contains(year));
        if (list_file_info.Count > 0)
        {
          list_file_info.Sort((x, y) => File.GetLastWriteTime(x.FullName).CompareTo(File.GetLastWriteTime(y.FullName)));
          list_file_info.Reverse();
          //----------------------------------
          FileInfo lastUpdatedFile = list_file_info[0];
#if enable_writelog
          w.WriteLine($"3. lastUpdatedFile: {lastUpdatedFile.Name}");
#endif


          //copy file
          string dest_file = String.Format(lastUpdatedFile.Name);
          FileInfo dest_file_info = new FileInfo(dest_file);
          try
          {
            if (dest_file_info.Exists == true)
            {
              File.Delete(dest_file);
            }
            //
            File.Copy(lastUpdatedFile.FullName, dest_file_info.FullName, true);

            //int nCountToExit = 0;
            //while ((File.Exists(dest_file_info.FullName) == false) || (nCountToExit < 100))
            //{
            //  Thread.Sleep(10);
            //  nCountToExit++;
            //}
            //if (dest_file_info.Exists == true)
            //{
            //  Thread.Sleep(500);
            //}
            if (dest_file_info.Exists == true)
            {
              Workbook wb = new Workbook(dest_file_info.FullName);
              WorksheetCollection collection = wb.Worksheets;
              bool is_exit_loop = false;
              for (int worksheetIndex = 0; worksheetIndex < collection.Count && is_exit_loop == false; worksheetIndex++)
              {
                Worksheet worksheet = collection[worksheetIndex];
                // Print worksheet name
                if (worksheet.Name.ToLower() == "bottle")
                {
                  //Console.WriteLine("Worksheet: " + worksheet.Name);
                  // Get number of rows and columns
                  int max_rows = worksheet.Cells.MaxDataRow;
                  int max_cols = worksheet.Cells.MaxDataColumn;
                  // Tìm work_centre
                  int work_center_column = 26;
                  int work_center_name_column = 27;
                  bool is_exit = false;

                  //
                  int row_pos1_start = 0;
                  int row_pos2_start = 0;
                  int row_pos3_start = 0;
                  int row_pos3_end = max_rows;
                  //
                  bool row_pos1_found = false;
                  bool row_pos2_found = false;
                  bool row_pos3_found = false;
                  //

                  bool is_found_Mon = false;
                  bool is_found_Tue = false;
                  bool is_found_Wed = false;
                  bool is_found_Thu = false;
                  bool is_found_Fri = false;
                  bool is_found_Sat = false;
                  bool is_found_Sun = false;

                  //
                  int col_Mon = 0;
                  int col_Tue = 0;
                  int col_Wed = 0;
                  int col_Thu = 0;
                  int col_Fri = 0;
                  int col_Sat = 0;
                  int col_Sun = 0;
                  int col_Sun_end = max_cols;
                  //
                  bool is_found_days_done = false;
                  for (int row = 0; row < max_rows && is_exit == false; row++)
                  {
                    object work_center_column_text = worksheet.Cells[row, work_center_column].Value;
                    object work_center_name_text = worksheet.Cells[row, work_center_name_column].Value;

                    if ((work_center_column_text != null) && (work_center_name_text != null))
                    {
                      if ((work_center_column_text is string) && (work_center_name_text is string))
                      {
                        string work_center_column_text_value = work_center_column_text as string;
                        string work_center_name_text_value = work_center_name_text as string;
                        if ((work_center_name_text_value == "HFF-PSM1") ||
                             (work_center_name_text_value == "HFF-PSM2") ||
                              (work_center_name_text_value == "HFF-PSM3"))
                        {
                          if (work_center_name_text_value == "HFF-PSM1")
                          {
                            row_pos1_found = true;
                            row_pos1_start = row;
                          }
                          else if (work_center_name_text_value == "HFF-PSM2")
                          {
                            row_pos2_found = true;
                            row_pos2_start = row;
                          }
                          else if (work_center_name_text_value == "HFF-PSM3")
                          {
                            row_pos3_found = true;
                            row_pos3_start = row;
                          }
                          //Console.WriteLine($"{work_center_column_text_value} -- {work_center_name_text_value}");
                        }
                        //Console.WriteLine($"bbbbbbbbbbb {work_center_column_text_value}");
                        else if (work_center_column_text_value.ToLower().Contains("work center"))
                        {

                          if ((row_pos1_found == true) && (row_pos2_found == true) && (row_pos3_found == true))
                          {
                            row_pos3_end = row;
                            is_exit = true;
                          }
                        }
                      }
                    }




                    for (int col = 0; col < max_cols && is_found_days_done == false; col++)
                    {
                      object cell_tmp = worksheet.Cells[row, col].Value;
                      if (cell_tmp != null)
                      {
                        if (cell_tmp is string)
                        {
                          string cell_day = (string)cell_tmp;
                          if ((cell_day == "Mon") ||
                              (cell_day == "Tue") ||
                              (cell_day == "Wed") ||
                              (cell_day == "Thu") ||
                              (cell_day == "Fri") ||
                              (cell_day == "Sat") ||
                              (cell_day == "Sun")
                            )
                          {
                            //Console.WriteLine($"cell_day -- {cell_day}");
                            if (cell_day == "Mon")
                            {
                              col_Mon = col;
                              is_found_Mon = true;
                            }
                            else if (cell_day == "Tue")
                            {
                              col_Tue = col;
                              is_found_Tue = true;
                            }
                            else if (cell_day == "Wed")
                            {
                              col_Wed = col;
                              is_found_Wed = true;
                            }
                            else if (cell_day == "Thu")
                            {
                              col_Thu = col;
                              is_found_Thu = true;
                            }
                            else if (cell_day == "Fri")
                            {
                              col_Fri = col;
                              is_found_Fri = true;
                            }
                            else if (cell_day == "Sat")
                            {
                              col_Sat = col;
                              is_found_Sat = true;
                            }
                            else if (cell_day == "Sun")
                            {
                              col_Sun = col;
                              is_found_Sun = true;
                            }
                          }
                          else
                          {
                            if ((is_found_Mon == true) ||
                              (is_found_Tue == true) ||
                              (is_found_Wed == true) ||
                              (is_found_Thu == true) ||
                              (is_found_Fri == true) ||
                              (is_found_Sat == true) ||
                              (is_found_Sun == true)
                            )
                            {
                              col_Sun_end = col;
                              is_found_days_done = true;
                            }
                          }
                        }
                      }
                    }
                  }


                  List<PlanData.PlanData> list_PlanData_Pos1 = GetPlanDatas(worksheet, 1, row_pos1_start, row_pos2_start, work_center_column, col_Mon, col_Tue, col_Wed, col_Thu, col_Fri, col_Sat, col_Sun, col_Sun_end);
                  List<PlanData.PlanData> list_PlanData_Pos2 = GetPlanDatas(worksheet, 2, row_pos2_start, row_pos3_start, work_center_column, col_Mon, col_Tue, col_Wed, col_Thu, col_Fri, col_Sat, col_Sun, col_Sun_end);
                  List<PlanData.PlanData> list_PlanData_Pos3 = GetPlanDatas(worksheet, 3, row_pos3_start, row_pos3_end, work_center_column, col_Mon, col_Tue, col_Wed, col_Thu, col_Fri, col_Sat, col_Sun, col_Sun_end);


                  List<List<PlanData.PlanData>> list_PlanData_all = new List<List<PlanData.PlanData>>() { list_PlanData_Pos1, list_PlanData_Pos2, list_PlanData_Pos3 };
                  string output = JsonConvert.SerializeObject(list_PlanData_all);
                  Console.WriteLine(output);

                  // List<List<PlanData.PlanData>> deserializedPlanData = JsonConvert.DeserializeObject<List<List<PlanData.PlanData>>>(output);
#if enable_writelog
                  w.WriteLine($"3. output: {output}");
#endif

                  is_exit_loop = true;
                }
              }
              //wb.
              //if (dest_file_info.Exists == true)
              //{
              //  File.Delete(dest_file);
              //}
            }
          }
          catch
          {

          }
        }
      }


//      string month = datetime.Month.ToString().PadLeft(2,'0');


//      string year = datetime.Year.ToString();
//      using (System.IO.StreamWriter w = System.IO.File.AppendText("log.txt"))
//      {
//        string path_by_week = directories.FindLast(x => x.Contains(month) && x.Contains(year));
//#if enable_writelog      
//        w.WriteLine($"1. path_by_week: {path_by_week}, path: {folder_paths}");
//#endif
//        List<string> directorieSubs = Directory.GetDirectories(path_by_week).ToList();
//        foreach(string directorie in directorieSubs)
//        {
//#if enable_writelog
//          w.WriteLine($"directorie: {directorie}");
//#endif
//        }
//        path_by_week = directorieSubs.FindLast(x => x.Contains(Week));
//#if enable_writelog
//        w.WriteLine($"2. path_by_week: {path_by_week}");
//#endif

//        if ((path_by_week != null) && (path_by_week != ""))
//        {
//          List<FileInfo> list_file_info = list_file_info = Directory.GetFiles(path_by_week, "*.xlsb").ToList().Select(x => new FileInfo(x)).ToList();
//          if (list_file_info.Count > 0)
//          {
//            list_file_info.Sort((x, y) => File.GetLastWriteTime(x.FullName).CompareTo(File.GetLastWriteTime(y.FullName)));
//            list_file_info.Reverse();
//            //----------------------------------
//            FileInfo lastUpdatedFile = list_file_info[0];
//#if enable_writelog
//             w.WriteLine($"3. lastUpdatedFile: {lastUpdatedFile.Name}");
//#endif


//            //copy file
//            string dest_file = String.Format(lastUpdatedFile.Name);
//            FileInfo dest_file_info = new FileInfo(dest_file);
//            try
//            {
//              if (dest_file_info.Exists == true)
//              {
//                File.Delete(dest_file);
//              }
//              //
//              File.Copy(lastUpdatedFile.FullName, dest_file_info.FullName, true);
//              if (dest_file_info.Exists == true)
//              {
//                Workbook wb = new Workbook(dest_file_info.FullName);
//                WorksheetCollection collection = wb.Worksheets;
//                bool is_exit_loop = false;
//                for (int worksheetIndex = 0; worksheetIndex < collection.Count && is_exit_loop == false; worksheetIndex++)
//                {
//                  Worksheet worksheet = collection[worksheetIndex];
//                  // Print worksheet name
//                  if (worksheet.Name.ToLower() == "bottle")
//                  {
//                    //Console.WriteLine("Worksheet: " + worksheet.Name);
//                    // Get number of rows and columns
//                    int max_rows = worksheet.Cells.MaxDataRow;
//                    int max_cols = worksheet.Cells.MaxDataColumn;
//                    // Tìm work_centre
//                    int work_center_column = 26;
//                    int work_center_name_column = 27;
//                    bool is_exit = false;

//                    //
//                    int row_pos1_start = 0;
//                    int row_pos2_start = 0;
//                    int row_pos3_start = 0;
//                    int row_pos3_end = max_rows;
//                    //
//                    bool row_pos1_found = false;
//                    bool row_pos2_found = false;
//                    bool row_pos3_found = false;
//                    //

//                    bool is_found_Mon = false;
//                    bool is_found_Tue = false;
//                    bool is_found_Wed = false;
//                    bool is_found_Thu = false;
//                    bool is_found_Fri = false;
//                    bool is_found_Sat = false;
//                    bool is_found_Sun = false;

//                    //
//                    int col_Mon = 0;
//                    int col_Tue = 0;
//                    int col_Wed = 0;
//                    int col_Thu = 0;
//                    int col_Fri = 0;
//                    int col_Sat = 0;
//                    int col_Sun = 0;
//                    int col_Sun_end = max_cols;
//                    //
//                    bool is_found_days_done = false;
//                    for (int row = 0; row < max_rows && is_exit == false; row++)
//                    {
//                      object work_center_column_text = worksheet.Cells[row, work_center_column].Value;
//                      object work_center_name_text = worksheet.Cells[row, work_center_name_column].Value;

//                      if ((work_center_column_text != null) && (work_center_name_text != null))
//                      {
//                        if ((work_center_column_text is string) && (work_center_name_text is string))
//                        {
//                          string work_center_column_text_value = work_center_column_text as string;
//                          string work_center_name_text_value = work_center_name_text as string;
//                          if ((work_center_name_text_value == "HFF-PSM1") ||
//                               (work_center_name_text_value == "HFF-PSM2") ||
//                                (work_center_name_text_value == "HFF-PSM3"))
//                          {
//                            if (work_center_name_text_value == "HFF-PSM1")
//                            {
//                              row_pos1_found = true;
//                              row_pos1_start = row;
//                            }
//                            else if (work_center_name_text_value == "HFF-PSM2")
//                            {
//                              row_pos2_found = true;
//                              row_pos2_start = row;
//                            }
//                            else if (work_center_name_text_value == "HFF-PSM3")
//                            {
//                              row_pos3_found = true;
//                              row_pos3_start = row;
//                            }
//                            //Console.WriteLine($"{work_center_column_text_value} -- {work_center_name_text_value}");
//                          }
//                          //Console.WriteLine($"bbbbbbbbbbb {work_center_column_text_value}");
//                          else if (work_center_column_text_value.ToLower().Contains("work center"))
//                          {

//                            if ((row_pos1_found == true) && (row_pos2_found == true) && (row_pos3_found == true))
//                            {
//                              row_pos3_end = row;
//                              is_exit = true;
//                            }
//                          }
//                        }
//                      }




//                      for (int col = 0; col < max_cols && is_found_days_done == false; col++)
//                      {
//                        object cell_tmp = worksheet.Cells[row, col].Value;
//                        if (cell_tmp != null)
//                        {
//                          if (cell_tmp is string)
//                          {
//                            string cell_day = (string)cell_tmp;
//                            if ((cell_day == "Mon") ||
//                                (cell_day == "Tue") ||
//                                (cell_day == "Wed") ||
//                                (cell_day == "Thu") ||
//                                (cell_day == "Fri") ||
//                                (cell_day == "Sat") ||
//                                (cell_day == "Sun")
//                              )
//                            {
//                              //Console.WriteLine($"cell_day -- {cell_day}");
//                              if (cell_day == "Mon")
//                              {
//                                col_Mon = col;
//                                is_found_Mon = true;
//                              }
//                              else if (cell_day == "Tue")
//                              {
//                                col_Tue = col;
//                                is_found_Tue = true;
//                              }
//                              else if (cell_day == "Wed")
//                              {
//                                col_Wed = col;
//                                is_found_Wed = true;
//                              }
//                              else if (cell_day == "Thu")
//                              {
//                                col_Thu = col;
//                                is_found_Thu = true;
//                              }
//                              else if (cell_day == "Fri")
//                              {
//                                col_Fri = col;
//                                is_found_Fri = true;
//                              }
//                              else if (cell_day == "Sat")
//                              {
//                                col_Sat = col;
//                                is_found_Sat = true;
//                              }
//                              else if (cell_day == "Sun")
//                              {
//                                col_Sun = col;
//                                is_found_Sun = true;
//                              }
//                            }
//                            else
//                            {
//                              if ((is_found_Mon == true) ||
//                                (is_found_Tue == true) ||
//                                (is_found_Wed == true) ||
//                                (is_found_Thu == true) ||
//                                (is_found_Fri == true) ||
//                                (is_found_Sat == true) ||
//                                (is_found_Sun == true)
//                              )
//                              {
//                                col_Sun_end = col;
//                                is_found_days_done = true;
//                              }
//                            }
//                          }
//                        }
//                      }
//                    }


//                    List<PlanData.PlanData> list_PlanData_Pos1 = GetPlanDatas(worksheet, 1, row_pos1_start, row_pos2_start, work_center_column, col_Mon, col_Tue, col_Wed, col_Thu, col_Fri, col_Sat, col_Sun, col_Sun_end);
//                    List<PlanData.PlanData> list_PlanData_Pos2 = GetPlanDatas(worksheet, 2, row_pos2_start, row_pos3_start, work_center_column, col_Mon, col_Tue, col_Wed, col_Thu, col_Fri, col_Sat, col_Sun, col_Sun_end);
//                    List<PlanData.PlanData> list_PlanData_Pos3 = GetPlanDatas(worksheet, 3, row_pos3_start, row_pos3_end, work_center_column, col_Mon, col_Tue, col_Wed, col_Thu, col_Fri, col_Sat, col_Sun, col_Sun_end);


//                    List<List<PlanData.PlanData>> list_PlanData_all = new List<List<PlanData.PlanData>>() { list_PlanData_Pos1, list_PlanData_Pos2, list_PlanData_Pos3 };
//                    string output = JsonConvert.SerializeObject(list_PlanData_all);
//                    Console.WriteLine(output);

//                    // List<List<PlanData.PlanData>> deserializedPlanData = JsonConvert.DeserializeObject<List<List<PlanData.PlanData>>>(output);
//#if enable_writelog
//                     w.WriteLine($"3. output: {output}");
//#endif

//                    is_exit_loop = true;
//                  }
//                }
//              }
//            }
//            catch
//            {

//            }
//          }
//        }

//        //-------------
//        w.Close();

//      }




     
    }

    private static List<PlanData.PlanData> GetPlanDatas(Worksheet worksheet, int id, int row_pos1_start, int row_pos2_start, int work_center_column, int col_Mon, int col_Tue, int col_Wed, int col_Thu, int col_Fri, int col_Sat, int col_Sun, int col_Sun_end)
    {

      List<PlanData.PlanData> list_PlanData_Raw_Pos1 = new List<PlanData.PlanData>();
      List<PlanData.PlanData> list_PlanData_Pos1 = new List<PlanData.PlanData>();
      for (int row = row_pos1_start; row < row_pos2_start; row++)
      {
        object fgs_text = worksheet.Cells[row, work_center_column].Value;
        if (fgs_text != null)
        {
          if (fgs_text is int)
          {
            int plan_cs_row = row + 1;

            PlanData.PlanData plan_2 = GetData(worksheet, id, 2, plan_cs_row, col_Mon, col_Tue);
            PlanData.PlanData plan_3 = GetData(worksheet, id, 3, plan_cs_row, col_Tue, col_Wed);
            PlanData.PlanData plan_4 = GetData(worksheet, id, 4, plan_cs_row, col_Wed, col_Thu);
            PlanData.PlanData plan_5 = GetData(worksheet, id, 5, plan_cs_row, col_Thu, col_Fri);
            PlanData.PlanData plan_6 = GetData(worksheet, id, 6, plan_cs_row, col_Fri, col_Sat);
            PlanData.PlanData plan_7 = GetData(worksheet, id, 7, plan_cs_row, col_Sat, col_Sun);
            PlanData.PlanData plan_8 = GetData(worksheet, id, 8, plan_cs_row, col_Sun, col_Sun_end);
            //
            if ((plan_2.Shift_1 > 0) || (plan_2.Shift_2 > 0) || (plan_2.Shift_3 > 0)) list_PlanData_Raw_Pos1.Add(plan_2);
            if ((plan_3.Shift_1 > 0) || (plan_3.Shift_2 > 0) || (plan_3.Shift_3 > 0)) list_PlanData_Raw_Pos1.Add(plan_3);
            if ((plan_4.Shift_1 > 0) || (plan_4.Shift_2 > 0) || (plan_4.Shift_3 > 0)) list_PlanData_Raw_Pos1.Add(plan_4);
            if ((plan_5.Shift_1 > 0) || (plan_5.Shift_2 > 0) || (plan_5.Shift_3 > 0)) list_PlanData_Raw_Pos1.Add(plan_5);
            if ((plan_6.Shift_1 > 0) || (plan_6.Shift_2 > 0) || (plan_6.Shift_3 > 0)) list_PlanData_Raw_Pos1.Add(plan_6);
            if ((plan_7.Shift_1 > 0) || (plan_7.Shift_2 > 0) || (plan_7.Shift_3 > 0)) list_PlanData_Raw_Pos1.Add(plan_7);
            if ((plan_8.Shift_1 > 0) || (plan_8.Shift_2 > 0) || (plan_8.Shift_3 > 0)) list_PlanData_Raw_Pos1.Add(plan_8);
          }
        }
      }
      foreach (PlanData.PlanData plan in list_PlanData_Raw_Pos1)
      {
        PlanData.PlanData plan_found = list_PlanData_Pos1.Find(x => x.Day == plan.Day);

        if (plan_found == null)
        {
          list_PlanData_Pos1.Add(plan);
        }
        else
        {
          plan_found.Shift_1 += plan.Shift_1;
          plan_found.Shift_2 += plan.Shift_2;
          plan_found.Shift_3 += plan.Shift_3;
        }
      }
      return list_PlanData_Pos1;


    }
    private static PlanData.PlanData GetData(Worksheet worksheet, int id, int day, int plan_cs_row, int col_start, int col_end)
    {
      PlanData.PlanData planData = new PlanData.PlanData(id, day);
      planData.Day = day;
      for (int col = col_start; col < col_end; col++)
      {
        int shift = (col - col_start) / 2;
        //Console.WriteLine($"=========================shift: {shift}");
        object plan_cs_value = worksheet.Cells[plan_cs_row, col].Value;
        if (plan_cs_value != null)
        {
          double value = 0;
          value = (plan_cs_value is int) ? (int)(plan_cs_value) : value;
          value = (plan_cs_value is double) ? (double)(plan_cs_value) : value;
          if (value > 0)
          {
            if (shift == 0)
            {
              planData.Shift_1 += value;
            }
            else if (shift == 1)
            {
              planData.Shift_2 += value;
            }
            else if (shift == 2)
            {
              planData.Shift_3 += value;
            }
            // Pos1_Mon_plan += value;
            //Console.WriteLine($"========================= nnn col Mon: {value}: ({plan_cs_value}, {col}, {Pos1_Mon_plan})");
          }
          //else 
        }
      }
      return planData;
    }

    //static Tuple<doube>
    
   // private static List<PlanData.PlanData> list_PlanData = new List<PlanData.PlanData>();
  }
}

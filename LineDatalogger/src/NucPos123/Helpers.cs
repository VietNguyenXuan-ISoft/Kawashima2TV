using SqliteDatabase.Models.Datalog;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NucPos123
{
  public static class Helpers
  {
    public static List<Color> seriescolors = new List<Color>
       { Color.Khaki,
        Color.Brown,
        Color.CornflowerBlue,
        Color.DarkCyan,
        Color.ForestGreen,
        Color.Gold,
        Color.HotPink,
        Color.Indigo};



    public static string ToyyyyMMddHHmmss(this DateTime dateTime)
    {
      return $"{dateTime.ToString("yyyy")}/{dateTime.ToString("MM")}/{dateTime.ToString("dd")} {dateTime.ToString("HH")}:{dateTime.ToString("mm")}:{dateTime.ToString("ss")}";
    }

    public static bool ToBool(this int src)
    {
      return (src != 0);
    }

    public static double ToDouble(this string src)
    {
      double ret = 0.0;
      try
      {
        ret = (src != "") ? Convert.ToDouble(src) : ret;
      }
      catch
      {

      }
      return ret;
    }

    public static int ToInt(this string src)
    {
      return ((int)src.ToDouble());
    }
    public static int ToInt(this bool src)
    {
      return (src == true ? 1 : 0);
    }

    //public static double roundup(this double value)
    //{
    //  string sa = value.ToString("#.##");
    //  var sb = Convert.ToDouble(sa);

    //}
    public static string format2digit(this double value)
    {
      double ret = Math.Round(value, 2); // (double)((int)(value * 100)) / 100.0;
      int ret_as_int = (int)(ret * 100);
      int tmp_a = (int)(ret_as_int / 100);
      int tmp_b = (int)(ret_as_int % 100);

      string result = $"{tmp_a}.{tmp_b.ToString().PadLeft(2, '0')}";
      return result;
    }


    public static double format2digitAsDouble(this double value)
    {
      double ret = Math.Round(value, 2); // (double)((int)(value * 100)) / 100.0;
      int ret_as_int = (int)(ret * 100);
      int tmp_a = (int)(ret_as_int / 100);
      int tmp_b = (int)(ret_as_int % 100);

      double result = (double)tmp_a + ((double)tmp_b / 100);
      return result;
    }


    public static string formatdigits(this double value, int digits)
    {
      double ret = Math.Round(value, digits);
      return ret.ToString();
    }



    public static string ToDataLogFileName(this DateTime datetime)
    {
      return (String.Format("{0}_data_log.s3db", datetime.ToString("yyyyMMdd")));
    }


   
    
    
  }
}

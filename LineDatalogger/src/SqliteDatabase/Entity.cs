using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqliteDatabase
{
  public class Entity
  {
    public static void Log(string logMessage, TextWriter w)
    {
      w.Write("\r\nLog Entry : ");
      w.WriteLine($"{DateTime.Now.ToLongTimeString()} {DateTime.Now.ToLongDateString()}");
      w.WriteLine("  :");
      w.WriteLine($"  :{logMessage}");
      w.WriteLine("-------------------------------");
    }
  }
}

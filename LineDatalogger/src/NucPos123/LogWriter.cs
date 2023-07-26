using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NucPos123
{
  public partial class frmMain
  {
    public static void WriteLog(string strLog)
    {
      string m_exePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
      string logFilePath = Path.Combine(m_exePath, "log.txt");
      FileInfo logFileInfo = new FileInfo(logFilePath);
      DirectoryInfo logDirInfo = new DirectoryInfo(logFileInfo.DirectoryName);
      if (!logDirInfo.Exists) logDirInfo.Create();
      using (FileStream fileStream = new FileStream(logFilePath, FileMode.Append))
      {
        using (StreamWriter log = new StreamWriter(fileStream))
        {
          log.WriteLine(strLog);
        }
      }
    }
  }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanData
{
  public class PlanData
  {
    public int Id { get; set; }
    public int Day { get; set; }
    public double Shift_1 { get; set; }
    public double Shift_2 { get; set; }
    public double Shift_3 { get; set; }

    public PlanData(int id, int day)
    {
      Id = id;
      Day = day;
      Shift_1 = 0;
      Shift_2 = 0;
      Shift_3 = 0;
    }
  }
}

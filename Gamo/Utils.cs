using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gamo
{
  class Utils
  {
    public static float BytesToMBytes(float value)
    {
      return value / 1024;
    }

    public static float BytesToGBytes(float value)
    {
      return value / 1024 / 1024;
    }
  }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GSUKariyer.COMMON
{
    public class AppUtil
    {

        public static string genActivatonCode()
        {
            return "gsu_" + Util.CreateRandomNumber(14);
        }

    }
}

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BokLogg.Helper
{
    public static class DateHelper
    {
        public static string GetSwedishMonthName(int month)
        {
            var cultureInfo = new CultureInfo("sv-SE");
            return cultureInfo.DateTimeFormat.GetMonthName(month);
        }
    }
}

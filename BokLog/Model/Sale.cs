using BokLogg.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BokLogg.Model
{
    public class Sale
    {
        public decimal Amount { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
        public int ItemsSold { get; set; }

        public override string ToString()
        {
            return $"Försäljnings Summa: {Amount} SEK, Månad: {DateHelper.GetSwedishMonthName(Month)}, År: {Year}, Sålda varor: {ItemsSold}";
        }
    }
}


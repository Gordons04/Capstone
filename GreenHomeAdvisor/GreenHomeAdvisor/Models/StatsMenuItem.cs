using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenHomeAdvisor.Models
{
    public class StatsMenuItem
    {
        public string Month { get; set; }
        public string Consumption { get; set; }

        public StatsMenuItem(string month, string consumption)
        {
            this.Month = month;
            this.Consumption = consumption;
        }
    }
}

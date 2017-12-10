using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenHomeAdvisor.Entity
{
    public class HomeConsumption
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public int usage { get; set; }
        public DateTime month { get; set; }

    }
}

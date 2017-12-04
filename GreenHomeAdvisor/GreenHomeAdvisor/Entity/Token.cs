using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenHomeAdvisor.Entity
{
    public class Token
    {
        [PrimaryKey]
        public int ID { get; set; }
        public string AccessToken { get; set; }
        public string Error { get; set; }
        public DateTime expiration { get; set; }

        public Token() { }
    }
}

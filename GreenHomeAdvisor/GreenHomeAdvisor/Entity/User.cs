using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenHomeAdvisor.Entity
{
    public class User
    {
        [PrimaryKey]
        public int ID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public User() { }
        public User(string Username, string Password)
        {
            this.Username = Username;
            this.Password = Password;
        }
        public bool checkCredentials()
        {
            if(this.Username.Equals("") && this.Password.Equals(""))
            {
                return true;
            }
            else
            {
                return false;
            }
        }


    }
}

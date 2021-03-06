﻿using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenHomeAdvisor.Entity
{
    public class User
    {
        [PrimaryKey, AutoIncrement]
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
            //ADD API CALL HERE TO CHECK AGAINST DB

            if(this.Username == null || this.Password == null)
            {
                return false;
            }
            else if(this.Username.Equals("user") && this.Password.Equals("password"))
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

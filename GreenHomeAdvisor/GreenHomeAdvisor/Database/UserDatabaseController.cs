using GreenHomeAdvisor.Entity;
using Java.IO;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace GreenHomeAdvisor.Database
{
    public class UserDatabaseController
    {
        static object locker = new object();

        SQLiteConnection database;

        public UserDatabaseController()
        {
            database = DependencyService.Get<ISQLite>().GetConnection();
            database.CreateTable<User>();
        }
        
        public User getUser()
        {
            lock (locker)
            {
                if(database.Table<User>().Count() == 0)     //If the database is empty return null
                {
                    return null;
                }
                else
                {
                    return database.Table<User>().First();  //Return the first User if the database is not empty
                }
            }

        }

        public void saveUser(User user)              //Insert user if database isn't empty else insert
        {
            lock (locker)
            {
                if(user.ID != 0)
                {
                    database.Update(user);
                    System.Diagnostics.Debug.WriteLine("{0} updated in the database.", user.Username);
                }
                else
                {
                    database.Insert(user);
                    System.Diagnostics.Debug.WriteLine("{0} inserted into the database.", user.Username);
                }
            }
        }

        public int deleteUser(int id)               //Delete user based off id
        {
            lock (locker)
            {
                return database.Delete<User>(id);
            }
        }
    }
}

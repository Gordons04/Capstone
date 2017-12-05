using GreenHomeAdvisor.Entity;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace GreenHomeAdvisor.Database
{
    public class TokenDatabaseController
    {
        static object locker = new object();
        SQLiteConnection database;

        public TokenDatabaseController()
        {
            database = DependencyService.Get<initSQLite>().GetConnection();
            database.CreateTable<Token>();
        }

        public Token getToken()
        {
            lock (locker)
            {
                if (database.Table<Token>().Count() == 0)     //If the database is empty return null
                {
                    return null;
                }
                else
                {
                    return database.Table<Token>().First();  //Return the token
                }
            }

        }

        public int saveToken(Token token)              //Insert token if database isn't empty else insert
        {
            lock (locker)
            {
                if (token.ID != 0)
                {
                    database.Update(token);
                    return token.ID;
                }
                else                                //
                {
                    return database.Insert(token);
                }
            }
        }

        public int deleteToken(int id)               //Delete token based off id
        {
            lock (locker)
            {
                return database.Delete<Token>(id);
            }
        }
    }
}

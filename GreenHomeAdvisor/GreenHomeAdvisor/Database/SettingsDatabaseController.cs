using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using GreenHomeAdvisor.Entity;

namespace GreenHomeAdvisor.Database
{
    public class SettingsDatabaseController
    {
        static object locker = new object();

        SQLiteConnection database;

        public SettingsDatabaseController()
        {
            database = DependencyService.Get<initSQLite>().GetConnection();
            database.CreateTable<Settings>();
        }

        public Settings GetSettings()
        {
            lock (locker)
            {
                if(database.Table<Settings>().Count() == 0)
                {
                    return null;
                }
                else
                {
                    return database.Table<Settings>().First();
                }
            }
        }

        public int SaveSettings(Settings settings)
        {
            lock (locker)
            {
                if(settings.Id != 0)
                {
                    database.Update(settings);
                    return settings.Id;
                }
                else
                {
                    settings.Id = 0;
                    return database.Insert(settings);
                }
            }
        }

        public int DeleteToken(int id)
        {
            lock (locker)
            {
                return database.Delete<Settings>(id);
            }
        }
    }
}

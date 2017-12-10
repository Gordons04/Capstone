using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SQLite;
using Xamarin.Forms;
using GreenHomeAdvisor.Entity;

namespace GreenHomeAdvisor.Database
{
    public class HomeConsumptionDatabaseController
    {
        static object locker = new object();

        SQLiteConnection database;

        public HomeConsumptionDatabaseController()
        {
            database = DependencyService.Get<ISQLite>().GetConnection();
            database.CreateTable<HomeConsumption>();
        }

        public HomeConsumption GetHomeConsumption()
        {
            lock (locker)
            {
                if (database.Table<HomeConsumption>().Count() == 0)
                {
                    return null;
                }
                else
                {
                    return database.Table<HomeConsumption>().First();
                }
            }
        }

    }
}

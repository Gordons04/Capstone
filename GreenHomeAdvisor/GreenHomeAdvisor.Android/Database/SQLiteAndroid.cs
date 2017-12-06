using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using GreenHomeAdvisor.Database;
using System.IO;
using Xamarin.Forms;
using GreenHomeAdvisor.Droid.Database;

[assembly: Dependency(typeof(SQLiteAndroid))]


namespace GreenHomeAdvisor.Droid.Database
{
    public class SQLiteAndroid : ISQLite
    {
        public SQLiteAndroid() { }
        public SQLite.SQLiteConnection GetConnection()
        {
            var sqliteFileName = "database.db3";
            string filePath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            var path = Path.Combine(filePath, sqliteFileName);
            var connection = new SQLite.SQLiteConnection(path);

            return connection;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;
using Xamarin.Forms;
using GreenHomeAdvisor.iOS.Database;
using GreenHomeAdvisor.Database;
using System.IO;

[assembly: Dependency(typeof(SQLiteIOS))]

namespace GreenHomeAdvisor.iOS.Database
{
    public class SQLiteIOS : initSQLite
    {
        public SQLiteIOS() { }
        public SQLite.SQLiteConnection GetConnection()
        {
            var filename = "Testdb.db3";
            var filePath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var libraryPath = Path.Combine(filePath, "..", "Library");
            var path = Path.Combine(libraryPath, filename);
            var connection = new SQLite.SQLiteConnection(path);

            return connection;
        }
    }
}
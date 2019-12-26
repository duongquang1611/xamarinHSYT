using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using ERM_HSYT.Data;
using ERM_HSYT.iOS.Data;
using Foundation;
using SQLite;
using UIKit;
using Xamarin.Forms;

[assembly: Dependency(typeof(SQLite_IOS))]
namespace ERM_HSYT.iOS.Data
{
    public class SQLite_IOS : ISQLite
    {
        public SQLite_IOS()
        {

        }

        public SQLiteConnection GetConnection()
        {
            var fileName = "Testdb.db3";
            var documentPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var libraryPath = Path.Combine(documentPath, "..", "Library");
            var path = Path.Combine(libraryPath, fileName);
            var conn = new SQLite.SQLiteConnection(path);

            return conn;
        }
    }
}
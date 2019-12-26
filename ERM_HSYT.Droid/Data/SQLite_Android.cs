using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using ERM_HSYT.Data;
using ERM_HSYT.Droid.Data;
using SQLite;
using Xamarin.Forms;

[assembly: Dependency(typeof(SQLite_Android))]
namespace ERM_HSYT.Droid.Data
{
    [BroadcastReceiver]
    public class SQLite_Android : BroadcastReceiver, ISQLite
    {
        public SQLite_Android()
        {
        }

        public SQLiteConnection GetConnection()
        {
            var sqliteFileName = "testDb.db3";
            string documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            var path = Path.Combine(documentsPath, sqliteFileName);
            var conn = new SQLite.SQLiteConnection(path);

            return conn;
        }

        public override void OnReceive(Context context, Intent intent)
        {
            Toast.MakeText(context, "Received intent!", ToastLength.Short).Show();
        }
    }
}
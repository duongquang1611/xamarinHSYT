using ERM_HSYT.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace ERM_HSYT.Data
{
    public class BacSiDatabaseController
    {
        static object locker = new object();
        SQLiteConnection database;
        public BacSiDatabaseController()
        {
            database = DependencyService.Get<ISQLite>().GetConnection();
            database.CreateTable<List>();
        }


        public List<List> GetBacSi(string id)
        {
            lock (locker)
            {
                if (database.Table<List>().Count() == 0)
                {
                    return null;
                }
                else if (id == "")
                {
                    return database.Table<List>().ToList<List>();
                }
                else
                {
                    return database.Table<List>().Where(s => s.Id == id).ToList<List>();
                }
            }
        }

        public int SaveBacSi(List<List> listBacSi)
        {
            lock (locker)
            {
                if (listBacSi == null)
                {
                    return 0;
                }
                else
                {
                    return database.InsertAll(listBacSi);
                }
            }
        }

        public int DeleteBacSi(int id)
        {
            lock (locker)
            {
                return database.Delete<KhoaPhong>(id);
            }
        }
    }
}

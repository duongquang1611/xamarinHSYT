using ERM_HSYT.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace ERM_HSYT.Data
{
    public class KhoaPhongDatabaseController
    {
        static object locker = new object();

        SQLiteConnection database;

        public KhoaPhongDatabaseController()
        {
            database = DependencyService.Get<ISQLite>().GetConnection();
            database.CreateTable<KhoaPhong>();

        }

        public List<KhoaPhong> GetAllKhoaPhong()
        {
            lock (locker)
            {
                if (database.Table<KhoaPhong>().Count() == 0)
                {
                    return null;
                }              
                return database.Table<KhoaPhong>().ToList<KhoaPhong>();
              
            }
        }

        public List<KhoaPhong> GetKhoaPhong(string id)
        {
            lock (locker)
            {
                if (database.Table<KhoaPhong>().Count() == 0)
                {
                    return null;
                }
                else if (id == "")
                {
                    return database.Table<KhoaPhong>().ToList<KhoaPhong>();
                }
                else
                {
                    return database.Table<KhoaPhong>().Where(s => s.Id == id).ToList<KhoaPhong>();
                }
            }
        }

        public List<KhoaPhong> GetTenKhoaPhong(string id)
        {
            lock (locker)
            {
                if (database.Table<KhoaPhong>().Count() == 0)
                {
                    return null;
                }
                else if (id == "")
                {
                    return database.Table<KhoaPhong>().ToList<KhoaPhong>();
                }
                else
                {
                    return database.Table<KhoaPhong>().Where(s => s.Id == id).ToList<KhoaPhong>();
                }
            }
        }

        public int SaveKhoaPhong(List<KhoaPhong> khoaPhongs)
        {
            lock (locker)
            {

                if (khoaPhongs == null)
                {
                    return 0;
                }
                else
                {
                    return database.InsertAll(khoaPhongs);
                }
            }
        }

        public int DeleteKhoaPhong(int id)
        {
            lock (locker)
            {
                return database.Delete<KhoaPhong>(id);
            }
        }
    }
}

using ERM_HSYT.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace ERM_HSYT.Data
{
    public class SuccessLoginUserDatabaseController
    {
        static object locker = new object();

        SQLiteConnection database;

        public SuccessLoginUserDatabaseController()
        {
            database = DependencyService.Get<ISQLite>().GetConnection();
            database.CreateTable<SuccessLoginUser>();
        }

        public SuccessLoginUser GetUser()
        {
            lock (locker)
            {
                if (database.Table<SuccessLoginUser>().Count() == 0)
                {
                    return null;
                }
                else
                {
                    return database.Table<SuccessLoginUser>().First();
                }
            }
        }

        public int SaveUser(SuccessLoginUser user)
        {
            lock (locker)
            {
                if (user.Id != 0)
                {
                    database.Update(user);
                    return user.Id;
                }
                else
                {
                    return database.Insert(user);
                }
            }
        }

        public int DeleteUser(int id)
        {
            lock (locker)
            {
                return database.Delete<SuccessLoginUser>(id);
            }
        }

        public void DeleteAllUser()
        {
            database.DeleteAll<SuccessLoginUser>();
        }

        
    }
}

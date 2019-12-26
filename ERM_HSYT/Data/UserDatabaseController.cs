using ERM_HSYT.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace ERM_HSYT.Data
{
    public class UserDatabaseController
    {
        static object locker = new object();

        SQLiteConnection database;

        public UserDatabaseController()
        {
            database = DependencyService.Get<ISQLite>().GetConnection();
            database.CreateTable<LoginUser>();
        }

        public LoginUser GetUser()
        {
            lock (locker)
            {
                if (database.Table<LoginUser>().Count() == 0)
                {
                    return null;
                }
                else
                {
                    return database.Table<LoginUser>().First();
                }
            }
        }

        public int SaveUser(LoginUser user)
        {
            lock (locker)
            {
                if (user.AppId != 0)
                {
                    database.Update(user);
                    return user.AppId;
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
                return database.Delete<LoginUser>(id);
            }
        }

        public void DeleteAllUser()
        {
            lock (locker)
            {
                database.DeleteAll<LoginUser>();
            }
        }
    }
}

using ERM_HSYT.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace ERM_HSYT.Data
{
    public class TokenDatabaseController
    {
        static object locker = new object();

        SQLiteConnection database;

        public TokenDatabaseController()
        {
            database = DependencyService.Get<ISQLite>().GetConnection();
            database.CreateTable<Token>();
        }

        public Token GetToken()
        {
            lock (locker)
            {
                if (database.Table<Token>().Count() == 0)
                {
                    return null;
                }
                else
                {
                    return database.Table<Token>().First();
                }
            }
        }

        public int SaveToken(Token user)
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

        public int DeleteToken(int id)
        {
            lock (locker)
            {
                return database.Delete<Token>(id);
            }
        }

        public void DeleteAllToken()
        {
            lock(locker)
            {
               database.DeleteAll<Token>();
            }
        }
    }
}

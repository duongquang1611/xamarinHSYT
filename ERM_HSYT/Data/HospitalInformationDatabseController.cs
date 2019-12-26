using ERM_HSYT.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace ERM_HSYT.Data
{
    public class HospitalInformationDatabseController
    {
        static object locker = new object();

        SQLiteConnection database;

        public HospitalInformationDatabseController()
        {
            database = DependencyService.Get<ISQLite>().GetConnection();
            database.CreateTable<HospitalInformation>();
            if (database.Table<HospitalInformation>().Count() == 0 )
            {
                Func<string, string, string, string, string, string, HospitalInformation> GetHospitalInfor
                    = (UrlLogin, BaseUrl, clientId, grantType, HospitalImageUrl, HospitalName)
                    => new HospitalInformation(UrlLogin, BaseUrl, clientId, grantType, HospitalImageUrl, HospitalName);

                this.SaveHospital(GetHospitalInfor("https://bvdkdongda.hosoyte.com/oauth/token",
                     "https://bvdkdongda.hosoyte.com/api/01004",
                     "3E46A49F-EE20-4A48-B29C-48B010026E1F",
                     "password",
                     "logo_bvdongda.jpg",
                     "BỆNH VIỆN ĐA KHOA ĐỐNG ĐA"));

                //this.SaveHospital(GetHospitalInfor("xxxx",
                //    "xxxx",
                //    "3E46A49F-EE20-4A48-B29C-48B010026E1F",
                //    "password",
                //    "https://cdn0.iconfinder.com/data/icons/animal-icons-flat/128/cat-256.png",
                //    "Bệnh viện "));

                //this.SaveHospital(GetHospitalInfor("xxxx",
                //   "xxxx",
                //   "3E46A49F-EE20-4A48-B29C-48B010026E1F",
                //   "password",
                //   "https://cdn0.iconfinder.com/data/icons/animal-icons-flat/128/cow-256.png",
                //   "Bệnh viện Z"));
            }
        }

        public HospitalInformation GetHospital()
        {
            lock (locker)
            {
                if (database.Table<HospitalInformation>().Count() == 0)
                {
                    return null;
                }
                else
                {
                    return database.Table<HospitalInformation>().First();
                }
            }
        }

        public List<HospitalInformation> GetAllHospital()
        {
            lock(locker)
            {
                if (database.Table<HospitalInformation>().Count() == 0)
                {
                    return null;
                } else
                {
                    return database.Table<HospitalInformation>().ToList();
                }
            }
        }

        public int SaveHospital(HospitalInformation hospital)
        {
            lock (locker)
            {
                if (hospital.Id != 0)
                {
                    database.Update(hospital);
                    return hospital.Id;
                }
                else
                {
                    return database.Insert(hospital);
                }
            }
        }

        public int DeleteHospital(int id)
        {
            lock (locker)
            {
                return database.Delete<HospitalInformation>(id);
            }
        }
    }
}

using Xamarin.Forms;
using UXDivers.Grial;
using ERM_HSYT.Data;
using ERM_HSYT.Models;
using ERM_HSYT.Views.CustomForm;
using System.Collections.ObjectModel;
using System;
using System.Diagnostics;
using Plugin.FirebasePushNotification;
using Plugin.FirebasePushNotification.Abstractions;
using System.Collections.Generic;

namespace ERM_HSYT
{
    public partial class App : Application
    {
        static TokenDatabaseController tokenDatabase;
        static UserDatabaseController userDatabase;
        static KhoaPhongDatabaseController khoaPhongDatabase;
        static BacSiDatabaseController bacSiDatabase;
        static SuccessLoginUserDatabaseController successLoginUserDatabase;
        static HospitalInformationDatabseController hospitalDatabse;
        public static RestService RestService { get; set; }
        public static bool IsRememberMe { get; set; }

        public static HospitalInformation CurrentHospital { get; set; }

        public App()
        {
            InitializeComponent();

            // Localization:
            //
            // Use "DefaultStringResources" key to define the default Resx type and get
            // the most compact version of the Translation Xaml extension like this:
            //
            // <Label Text="{ grial:Translate MyStringKey }" />
            //
            // Optionally:
            // <Label Text="{ grial:Translate Key=MyStringKey }" />
            //
            // To use another named Resx you can use either:
            // 
            // a) define the namspace of the Resx type, for instance:
            // 	  xmlns:resx="clr-namespace:ERM_HSYT"
            //
            //	  and use it like this:
            //	  <Label Text="{ grial:Translate Key=resx:OtherResources.MyStringKey }" />
            //
            //  b) define a StaticResource as an instance of the Resx type
            //	   <resx:OtherResources x:Key="MyOtherResourcesKey" />
            //
            //	   and use it like this:
            //	   <Label Text="{ grial:Translate Key=MyStringKey, Source={ StaticResource MyOtherResourcesKey } }" />
            //
            // Note: The Extension supports both Converter and StringFormat properties
            // as regular Bindings do. 


            // test


            Resources["DefaultStringResources"] = new Resx.AppResources();

            SamplesCatalog.Initialize();

            MainPage = GetMainPage();
            //MainPage = new ChangePasswordView();

        }

        public static Page GetMainPage()
        {
            //var user = UserDatabase.GetUser();
            //if (user != null)
            //    return new NavigationPage(new DashboardCarouselPage());

            //            SuccessLoginUserDatabase.DeleteAllUser();

            var user = SuccessLoginUserDatabase.GetUser();
            if (user != null && user.RememberMe && TokenDatabase.GetToken() != null)
            {
                return new NavigationPage(new DashboardCarouselPage());
            }
            TokenDatabase.DeleteAllToken();
            return new NavigationPage(new LoginView());
        }

        public static HospitalInformationDatabseController HospitalDatabse
        {
            get
            {
                if (hospitalDatabse == null)
                {
                    hospitalDatabse = new HospitalInformationDatabseController();
                }
                return hospitalDatabse;
            }
        }

        public static SuccessLoginUserDatabaseController SuccessLoginUserDatabase
        {
            get
            {
                if (successLoginUserDatabase == null)
                {
                    successLoginUserDatabase = new SuccessLoginUserDatabaseController();
                }
                return successLoginUserDatabase;
            }
        }

        public static UserDatabaseController UserDatabase
        {
            get
            {
                if (userDatabase == null)
                {
                    userDatabase = new UserDatabaseController();
                }
                return userDatabase;
            }
        }

        public static TokenDatabaseController TokenDatabase
        {
            get
            {
                if (tokenDatabase == null)
                {
                    tokenDatabase = new TokenDatabaseController();
                }
                return tokenDatabase;
            }
        }
        public static KhoaPhongDatabaseController KhoaPhongDatabase
        {
            get
            {
                if (khoaPhongDatabase == null)
                {
                    khoaPhongDatabase = new KhoaPhongDatabaseController();
                }
                return khoaPhongDatabase;
            }
        }

        public static BacSiDatabaseController BacSiDatabase
        {
            get
            {
                if (bacSiDatabase == null)
                {
                    bacSiDatabase = new BacSiDatabaseController();
                }
                return bacSiDatabase;
            }
        }

        protected void sendRegistrationToServer()
        {
            // send device-token to server
        }
        protected override void OnStart()
        {

            // Handle when your app starts

            CrossFirebasePushNotification.Current.Subscribe("general");

            CrossFirebasePushNotification.Current.OnTokenRefresh += (s, p) =>
            {
                Trace.WriteLine($"TOKEN REC: {p.Token}");

                sendRegistrationToServer();
            };

            Trace.WriteLine($"TOKEN: {CrossFirebasePushNotification.Current.Token}");

            CrossFirebasePushNotification.Current.OnNotificationReceived += (s, p) =>
            {
                try
                {
                    System.Diagnostics.Debug.WriteLine("Received");
                    if (p.Data.ContainsKey("body"))
                    {
                        Device.BeginInvokeOnMainThread(() =>
                        {
                            Trace.WriteLine($"{p.Data["body"]}");
                        });

                    }
                }
                catch (Exception ex)
                {

                }

            };

            CrossFirebasePushNotification.Current.OnNotificationOpened += (s, p) =>
            {
                //System.Diagnostics.Debug.WriteLine(p.Identifier);

                System.Diagnostics.Debug.WriteLine("Opened");
                foreach (var data in p.Data)
                {
                    System.Diagnostics.Debug.WriteLine($"{data.Key} : {data.Value}");
                }

                if (!string.IsNullOrEmpty(p.Identifier))
                {
                    Device.BeginInvokeOnMainThread(() =>
                    {
                        Trace.WriteLine(p.Identifier);
                    });
                }
                else if (p.Data.ContainsKey("color"))
                {
                    Device.BeginInvokeOnMainThread(() =>
                    {
                        Trace.WriteLine($"{p.Data["color"]}");                        
                    });

                }
                else if (p.Data.ContainsKey("aps.alert.title"))
                {
                    Device.BeginInvokeOnMainThread(() =>
                    {
                        Trace.WriteLine("CCCCCCCCCCCCCCCCCCCC" + " " + $"{p.Data["aps.alert.title"]}");
                    });

                }
            };

            CrossFirebasePushNotification.Current.OnNotificationAction += (s, p) =>
            {
                System.Diagnostics.Debug.WriteLine("Action");

                if (!string.IsNullOrEmpty(p.Identifier))
                {
                    System.Diagnostics.Debug.WriteLine($"ActionId: {p.Identifier}");
                    foreach (var data in p.Data)
                    {
                        System.Diagnostics.Debug.WriteLine($"{data.Key} : {data.Value}");
                    }

                }

            };

            CrossFirebasePushNotification.Current.OnNotificationDeleted += (s, p) =>
            {
                System.Diagnostics.Debug.WriteLine("Dismissed");
            };

        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }


    }
}

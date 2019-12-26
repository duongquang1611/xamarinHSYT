using System;

using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Graphics.Drawables;
using Xamarin.Forms.Platform.Android;
using Xamarin.Forms;
using System.Threading.Tasks;

using UXDivers.Grial;

using FFImageLoading.Forms.Droid;
using Java.Util;
using Plugin.FirebasePushNotification;
using Firebase;
using Android.Graphics;
using System.Collections.Generic;

namespace ERM_HSYT.Droid
{
    //https://developer.android.com/guide/topics/manifest/activity-element.html
    [Activity(
        Label = "@string/app_name",
        Icon = "@drawable/iconApp",
        Theme = "@style/Theme.Splash",
        MainLauncher = true,
        LaunchMode = LaunchMode.SingleTask,
        ConfigurationChanges = ConfigChanges.Orientation | ConfigChanges.ScreenSize | ConfigChanges.Locale | ConfigChanges.LayoutDirection
        )
    ]
    public class MainActivity : FormsAppCompatActivity
    {
        private Locale _locale;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            // Changing to App's theme since we are OnCreate and we are ready to 
            // "hide" the splash
            base.Window.RequestFeature(WindowFeatures.ActionBar);
            base.SetTheme(Resource.Style.AppTheme);

            ToolbarResource = Resource.Layout.Toolbar;
            TabLayoutResource = Resource.Layout.Tabbar;

            base.OnCreate(savedInstanceState);

            // ggmap 
            Xamarin.FormsMaps.Init(this, savedInstanceState);

            // manually add : setSoftInput
            Window.SetSoftInputMode(Android.Views.SoftInput.AdjustResize);
            AndroidBug5497WorkaroundForXamarinAndroid.assistActivity(this);
            // manually add : setSoftInput
            Window.SetSoftInputMode(Android.Views.SoftInput.AdjustResize);
            AndroidBug5497WorkaroundForXamarinAndroid.assistActivity(this);


            // Initializing FFImageLoading
            FFImageLoading.Forms.Platform.CachedImageRenderer.Init(enableFastRenderer: false);

            Forms.SetFlags("FastRenderers_Experimental");

            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);

            // Initializing Xamarin.Essentials
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);

            // Initializing Popups
            Rg.Plugins.Popup.Popup.Init(this, savedInstanceState);

            GrialKit.Init(this, "ERM_HSYT.Droid.GrialLicense");

#if !DEBUG
            // Reminder to update the project license to production mode before publishing
            if (!UXDivers.Grial.License.IsProductionLicense())
            {
                try
                {
                    AlertDialog.Builder alert = new AlertDialog.Builder(this);
                    alert.SetTitle("Grial UI Kit Reminder");
                    alert.SetMessage("Before publishing this App remember to change the license file to PRODUCTION MODE so it doesn't expire.");
                    alert.SetPositiveButton("OK", (sender, e) => { });

                    var dialog = alert.Create();
                    dialog.Show();
                }
                catch
                {
                }
            }
#endif

            _locale = Resources.Configuration.Locale;

            ReferenceCalendars();

#if GORILLA
            LoadApplication(
                UXDivers.Gorilla.Droid.Player.CreateApplication(
                    this,
                    new UXDivers.Gorilla.Config("Good Gorilla")
                        // Grial Core
                        .RegisterAssemblyFromType<UXDivers.Grial.NegateBooleanConverter>()

                        // // FFImageLoading.Transformations
                        .RegisterAssemblyFromType<FFImageLoading.Transformations.BlurredTransformation>()
                        // FFImageLoading.Forms
                        .RegisterAssemblyFromType<FFImageLoading.Forms.CachedImage>()

                        // Microcharts
                        .RegisterAssemblyFromType<Microcharts.ChartEntry>()
                        .RegisterAssemblyFromType<Microcharts.Forms.ChartView>()

                        // Grial Application .Net Standard
                        .RegisterAssembly(typeof(ERM_HSYT.App).Assembly)

                        .RegisterAssembly(typeof(Xamanimation.AnimationBase).Assembly)

                        .RegisterAssembly(typeof(AnimatedBaseBehavior).Assembly)
                    ));
#else
            var options = new FirebaseOptions.Builder()
                .SetApplicationId("1:652965016874:android:2cf89b5913efba48")
                .SetApiKey("AIzaSyCClGpnCCWhQhr9-S6hIFVfioNHB3g7uVc")
                .SetDatabaseUrl("https://hsyt-55d19.firebaseio.com")
                .SetStorageBucket("hsyt-55d19.appspot.com")
                .SetGcmSenderId("652965016874").Build();

            bool hasBeenInitialized = false;
            IList<FirebaseApp> firebaseApps = FirebaseApp.GetApps(this);
            foreach (FirebaseApp app in firebaseApps)
            {
                if (app.Name.Equals(FirebaseApp.DefaultAppName))
                {
                    hasBeenInitialized = true;
                    //finestayApp = app;
                }
            }

            if (!hasBeenInitialized)
            {
                FirebaseApp.InitializeApp(this, options);
            }
            LoadApplication(new App());
            FirebasePushNotificationManager.ProcessIntent(this, Intent);


#endif
        }

        //
        protected override void OnNewIntent(Intent intent)
        {
            base.OnNewIntent(intent);

            FirebasePushNotificationManager.ProcessIntent(this, intent);
        }



        public override void OnConfigurationChanged(Android.Content.Res.Configuration newConfig)
        {
            base.OnConfigurationChanged(newConfig);

            GrialKit.NotifyConfigurationChanged(newConfig);
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

#if GORILLA
        public override bool OnKeyUp (Android.Views.Keycode keyCode, Android.Views.KeyEvent e)  
        {  
            if ((keyCode == Android.Views.Keycode.F1 || keyCode == Android.Views.Keycode.Menu || keyCode == Android.Views.Keycode.VolumeUp || keyCode == Android.Views.Keycode.VolumeDown || keyCode == Android.Views.Keycode.VolumeMute) && UXDivers.Gorilla.Coordinator.Instance != null) {  
                UXDivers.Gorilla.ActionManager.ShowMenu();
                return true; 
            } 

            return base.OnKeyUp (keyCode, e); 
        }

        private readonly static GestureDetector LongPressDetector = new GestureDetector (new UXDivers.Gorilla.Droid.LongPressGestureListener());

        public override bool DispatchTouchEvent(MotionEvent ev)
        {
            LongPressDetector.OnTouchEvent(ev);
                             
            return base.DispatchTouchEvent(ev);
        }
#endif

        private void ReferenceCalendars()
        {
            // When compiling in release, you may need to instantiate the specific
            // calendar so it doesn't get stripped out by the linker. Just uncomment
            // the lines you need according to the localization needs of the app.
            // For instance, in 'ar' cultures UmAlQuraCalendar is required.
            // https://bugzilla.xamarin.com/show_bug.cgi?id=59077

            new System.Globalization.UmAlQuraCalendar();
            // new System.Globalization.ChineseLunisolarCalendar();
            // new System.Globalization.ChineseLunisolarCalendar();
            // new System.Globalization.HebrewCalendar();
            // new System.Globalization.HijriCalendar();
            // new System.Globalization.IdnMapping();
            // new System.Globalization.JapaneseCalendar();
            // new System.Globalization.JapaneseLunisolarCalendar();
            // new System.Globalization.JulianCalendar();
            // new System.Globalization.KoreanCalendar();
            // new System.Globalization.KoreanLunisolarCalendar();
            // new System.Globalization.PersianCalendar();
            // new System.Globalization.TaiwanCalendar();
            // new System.Globalization.TaiwanLunisolarCalendar();
            // new System.Globalization.ThaiBuddhistCalendar();
        }
        public class AndroidBug5497WorkaroundForXamarinAndroid
        {

            // For more information, see https://code.google.com/p/android/issues/detail?id=5497
            // To use this class, simply invoke assistActivity() on an Activity that already has its content view set.

            // CREDIT TO Joseph Johnson (http://stackoverflow.com/users/341631/joseph-johnson) for publishing the original Android solution on stackoverflow.com

            public static void assistActivity(Activity activity)
            {
                new AndroidBug5497WorkaroundForXamarinAndroid(activity);
            }

            private Android.Views.View mChildOfContent;
            private int usableHeightPrevious;
            private FrameLayout.LayoutParams frameLayoutParams;

            private AndroidBug5497WorkaroundForXamarinAndroid(Activity activity)
            {
                FrameLayout content = (FrameLayout)activity.FindViewById(Android.Resource.Id.Content);
                mChildOfContent = content.GetChildAt(0);
                ViewTreeObserver vto = mChildOfContent.ViewTreeObserver;
                vto.GlobalLayout += (object sender, EventArgs e) => {
                    possiblyResizeChildOfContent();
                };
                frameLayoutParams = (FrameLayout.LayoutParams)mChildOfContent.LayoutParameters;
            }

            private void possiblyResizeChildOfContent()
            {
                int usableHeightNow = computeUsableHeight();
                if (usableHeightNow != usableHeightPrevious)
                {
                    int usableHeightSansKeyboard = mChildOfContent.RootView.Height;
                    int heightDifference = usableHeightSansKeyboard - usableHeightNow;

                    frameLayoutParams.Height = usableHeightSansKeyboard - heightDifference;

                    mChildOfContent.RequestLayout();
                    usableHeightPrevious = usableHeightNow;
                }
            }

            private int computeUsableHeight()
            {
                Rect r = new Rect();
                mChildOfContent.GetWindowVisibleDisplayFrame(r);
                if (Build.VERSION.SdkInt < BuildVersionCodes.Lollipop)
                {
                    return (r.Bottom - r.Top);
                }
                return r.Bottom;
            }

        }
    }
}


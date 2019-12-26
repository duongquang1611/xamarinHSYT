using System.Collections.ObjectModel;
using System.Globalization;
using System.Windows.Input;
using Xamarin.Forms;
using UXDivers.Grial;
using ERM_HSYT.Views;
using ERM_HSYT.Views.CustomForm;
using ERM_HSYT.Views.CustomForm.Templates;
using Xamarin.Essentials;

namespace ERM_HSYT
{
    public class DashboardCarouselViewModel : ObservableObject
    {
        public DashboardCarouselViewModel()
            : base(listenCultureChanges: true)
        {
            LoadData();
        }

        public ObservableCollection<NavigationItemDataWithCommand> Items { get; } = new ObservableCollection<NavigationItemDataWithCommand>();
        public ObservableCollection<NavigationItemDataWithCommand> Headers { get; } = new ObservableCollection<NavigationItemDataWithCommand>();

        protected override void OnCultureChanged(CultureInfo culture)
        {
            LoadData();
        }

        private void LoadData()
        {
            Items.Clear();
            Headers.Clear();
            Headers.Add(new NavigationItemDataWithCommand()
            {
                Name = "",
                Description = "",
                Icon = "bvdd1.png"
            });
            Headers.Add(new NavigationItemDataWithCommand()
            {
                Name = "Hồ sơ y tế cá nhân",
                Description = "",
                Icon = "bvdd2.png",
            });
            Items.Add(new NavigationItemDataWithCommand()
            {
                Name = "Đặt Khám",
                BackgroundColor = "#FFB31250",
                BackgroundImage = "https://s3-us-west-2.amazonaws.com/grial-images/v3.0/category_04.jpg",
                Icon = GrialIconsFont.Carousel,
                ItemCount = 5,
                Badge = 0
            });
            Items.Add(new NavigationItemDataWithCommand()
            {
                Name = "Kết quả CLS",
                BackgroundColor = "#FF56329A",
                BackgroundImage = "https://s3-us-west-2.amazonaws.com/grial-images/v3.0/category_03.jpg",
                Icon = GrialIconsFont.FolderPlus,
                ItemCount = 10,
                Badge = 0
            });
            Items.Add(new NavigationItemDataWithCommand()
            {
                Name = "Đơn thuốc",
                BackgroundColor = "#FF56329A",
                BackgroundImage = "https://s3-us-west-2.amazonaws.com/grial-images/v3.0/category_03.jpg",
                Icon = GrialIconsFont.Briefcase,
                ItemCount = 10,
                Badge = 0
            });
            Items.Add(new NavigationItemDataWithCommand()
            {
                Name = "Sổ khám bệnh",
                BackgroundColor = "#FFCD195E",
                BackgroundImage = "https://s3-us-west-2.amazonaws.com/grial-images/v3.0/category_07.jpg",
                Icon = GrialIconsFont.Book,
                ItemCount = 15,
                Badge = 9
            });
            Items.Add(new NavigationItemDataWithCommand()
            {
                Name = "Lịch khám",
                BackgroundColor = "#FF5F7DD4",
                BackgroundImage = "https://s3-us-west-2.amazonaws.com/grial-images/v3.0/category_08.jpg",
                Icon = GrialIconsFont.Calendar,
                ItemCount = 19,
                Badge = 0
            });
            //Items.Add(new NavigationItemDataWithCommand()
            //{
            //    Name = "Đặt lịch hẹn",
            //    BackgroundColor = "#FF5F7DD4",
            //    BackgroundImage = "https://s3-us-west-2.amazonaws.com/grial-images/v3.0/category_08.jpg",
            //    Icon = "",
            //    ItemCount = 18,
            //    Badge = 0
            //});
            Items.Add(new NavigationItemDataWithCommand()
            {
                Name = "Tin nhắn",
                BackgroundColor = "#FF7C4ECD",
                BackgroundImage = "https://s3-us-west-2.amazonaws.com/grial-images/v3.0/category_02.jpg",
                Icon = GrialIconsFont.MessageCircle,
                ItemCount = 7,
                Badge = 0
            });
            Items.Add(new NavigationItemDataWithCommand()
            {
                Name = "Thông tin",
                BackgroundColor = "#FF921243",
                BackgroundImage = "https://s3-us-west-2.amazonaws.com/grial-images/v3.0/category_05.jpg",
                Icon = GrialIconsFont.User,
                ItemCount = 6,
                Badge = 0
            });
            Items.Add(new NavigationItemDataWithCommand()
            {
                Name = "Bệnh viện",
                BackgroundColor = "#FF525ABB",
                BackgroundImage = "https://s3-us-west-2.amazonaws.com/grial-images/v3.0/category_08.jpg",
                Icon = GrialIconsFont.Globe,
                ItemCount = 3,
                Badge = 0
            });
            Items.Add(new NavigationItemDataWithCommand()
            {
                Name = "Bản đồ",
                BackgroundColor = "#FF7B96E5",
                BackgroundImage = "https://s3-us-west-2.amazonaws.com/grial-images/v3.0/category_01.jpg",
                Icon = GrialIconsFont.Map,
                ItemCount = 4,
                Badge = 0
            });
            //JsonHelper.Instance.LoadViewModel(this, source: "NavigationDashboards.json");
        }

        public class NavigationItemDataWithCommand : NavigationItemData
        {
            public NavigationItemDataWithCommand()
            {
                TapCommand = new Command(() =>
                {
                    if ($"{Name}" == "Thông tin")
                        Application.Current.MainPage.Navigation.PushAsync(new ContactDetailPage());
                    if ($"{Name}" == "Sổ khám bệnh")
                        Application.Current.MainPage.Navigation.PushAsync(new MessagesListPage());
                    if ($"{Name}" == "Hóa đơn điện tử")
                        Application.Current.MainPage.DisplayAlert("Xin lỗi", "Tính năng này chưa được xây dựng", "OK");

                    //if ($"{Name}" == "Lịch hẹn")
                    //   Application.Current.MainPage.Navigation.PushAsync(new DsLichHenTemplate2());
                    if ($"{Name}" == "Lịch khám")
                    {
                        if (Connectivity.NetworkAccess != NetworkAccess.Internet)
                        {
                            App.Current.MainPage.DisplayAlert("Internet", "Không có kết nối Internet", "Oke");

                        }
                        else
                        {
                            Application.Current.MainPage.Navigation.PushAsync(new DsLichHen());
                        }
                    }
                    if ($"{Name}" == "Bệnh viện")
                        Application.Current.MainPage.Navigation.PushAsync(new RichAboutPage());
                    if ($"{Name}" == "Tin nhắn")
                        Application.Current.MainPage.Navigation.PushAsync(new ReportsView());
                    if ($"{Name}" == "Trải nghiệm hồ sơ y tế điện tử")
                        Application.Current.MainPage.Navigation.PushAsync(new WalkthroughPage());
                    if ($"{Name}" == "Bản đồ") 
                        Application.Current.MainPage.Navigation.PushAsync(new GoogleMapView());

                    if ($"{Name}" == "Đặt Khám") 
                        Application.Current.MainPage.Navigation.PushAsync(new DatLichHen());

                    if ($"{Name}" == "Kết quả CLS")
                    {
                        if (Connectivity.NetworkAccess != NetworkAccess.Internet)
                        {
                            App.Current.MainPage.DisplayAlert("Internet", "Không có kết nối Internet", "Oke");

                        }
                        else
                        {
                            Application.Current.MainPage.Navigation.PushAsync(new CLSView());
                        }
                    }
                    if ($"{Name}" == "Đơn thuốc")
                        Application.Current.MainPage.Navigation.PushAsync(new MedicinesView());
                });
            }

            public ICommand TapCommand { get; }
        }
    }
}

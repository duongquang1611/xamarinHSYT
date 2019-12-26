using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ERM_HSYT
{
    public class XemThuoc : ContentPage
    {
        ObservableCollection<XemThuocViewModel> _data { get; set; }

        public XemThuoc()
        {

            _data = new ObservableCollection<XemThuocViewModel>();
            // test 
            _data.Add(new XemThuocViewModel("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", 1, "a", "ok"));
            _data.Add(new XemThuocViewModel("bbbbbbbbbbbbbbbbbbb", 2, "b", "ok"));
            _data.Add(new XemThuocViewModel("c", 3, "c", "okkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkk"));

            // real data goes from here
            //


            // Crete a grid for "title"
            Grid grid = CreateGrid();
            grid.Children.Add(new Label { Text = "Tên thuốc", TextColor = Color.Red, VerticalOptions = LayoutOptions.Center, HorizontalOptions = LayoutOptions.Center }, 0, 1, 0, 1);
            grid.Children.Add(SeparatorV(), 1, 2, 0, 1);
            grid.Children.Add(new Label { Text = "Số lượng", TextColor = Color.Red, VerticalOptions = LayoutOptions.Center, HorizontalOptions = LayoutOptions.Center }, 2, 3, 0, 1);
            grid.Children.Add(SeparatorV(), 3, 4, 0, 1);
            grid.Children.Add(new Label { Text = "Liều lượng", TextColor = Color.Red, VerticalOptions = LayoutOptions.Center, HorizontalOptions = LayoutOptions.Center }, 4, 5, 0, 1);
            grid.Children.Add(SeparatorV(), 5, 6, 0, 1);
            grid.Children.Add(new Label { Text = "Ghi chú", TextColor = Color.Red, VerticalOptions = LayoutOptions.Center, HorizontalOptions = LayoutOptions.Center }, 6, 7, 0, 1);
            grid.Children.Add(SeparatorH(), 0, 7, 1, 2);

            // Create the ListView to visualize my data
            ListView lv = new ListView(ListViewCachingStrategy.RecycleElement) { ItemsSource = _data, ItemTemplate = new DataTemplate(typeof(XemThuocTemplate)), HasUnevenRows = true, SeparatorVisibility = SeparatorVisibility.None };

            StackLayout sl = new StackLayout() { Children = { grid, lv }, Spacing = 0 };

            this.Content = sl;
        }

        static Grid CreateGrid()
        {

            Grid grid = new Grid() { RowSpacing = 0, ColumnSpacing = 0 };

            // Define row 
            RowDefinition rd = new RowDefinition() { Height = new GridLength(1, GridUnitType.Auto) };
            RowDefinition rdSeparator = new RowDefinition() { Height = new GridLength(1, GridUnitType.Auto) };

            // Define columns (one for every property I have to visualize)
            ColumnDefinition cdTenThuoc = new ColumnDefinition() { Width = new GridLength(2, GridUnitType.Star) };
            ColumnDefinition cdSoLuong = new ColumnDefinition() { Width = new GridLength(1, GridUnitType.Star) };
            ColumnDefinition cdLieuDung = new ColumnDefinition() { Width = new GridLength(2, GridUnitType.Star) };
            ColumnDefinition cdGhiChu = new ColumnDefinition() { Width = new GridLength(2, GridUnitType.Star) };

            // Add row and columns to grid
            grid.RowDefinitions.Add(rd);
            grid.RowDefinitions.Add(rdSeparator);

            grid.ColumnDefinitions.Add(cdTenThuoc);
            grid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(2, GridUnitType.Absolute) }); // Separator
            grid.ColumnDefinitions.Add(cdSoLuong);
            grid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(2, GridUnitType.Absolute) }); // Separator
            grid.ColumnDefinitions.Add(cdLieuDung);
            grid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(2, GridUnitType.Absolute) });
            grid.ColumnDefinitions.Add(cdGhiChu);

            return grid;
        }

        static BoxView SeparatorV()
        {

            return new BoxView() { WidthRequest = 2, BackgroundColor = Color.Red };
        }

        static BoxView SeparatorH()
        {

            return new BoxView() { HeightRequest = 2, BackgroundColor = Color.Red };
        }

        class XemThuocTemplate : ViewCell
        {
            public XemThuocTemplate()
            {
                TapGestureRecognizer tgr = new TapGestureRecognizer();
                tgr.Tapped += async (object sender, EventArgs e) => {

                    try
                    {

                        await Application.Current.MainPage.DisplayAlert("Article", ((XemThuocViewModel)this.BindingContext).TenThuoc, "Ok");

                    }
                    catch (Exception ex)
                    {

                        await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "Ok");
                    }

                };


                Label lbTenThuoc = new Label() { TextColor = Color.Black, VerticalOptions = LayoutOptions.Center };
                lbTenThuoc.SetBinding(Label.TextProperty, "Tên thuốc");
                lbTenThuoc.GestureRecognizers.Add(tgr);


                Label lbSoLuong = new Label() { TextColor = Color.Black, VerticalOptions = LayoutOptions.Center, HorizontalOptions = LayoutOptions.Center };
                lbSoLuong.SetBinding(Label.TextProperty, "Số lượng");

                Label lbLieuDung = new Label() { TextColor = Color.Black, VerticalOptions = LayoutOptions.Center, HorizontalOptions = LayoutOptions.Center };
                lbLieuDung.SetBinding(Label.TextProperty, "Liều dùng");

                Label lbGhiChu = new Label() { TextColor = Color.Black, VerticalOptions = LayoutOptions.Center, HorizontalOptions = LayoutOptions.Center };
                lbGhiChu.SetBinding(Label.TextProperty, "Ghi chú");

                // Add controls to the grid
                Grid grid = CreateGrid();
                grid.Children.Add(lbTenThuoc, 0, 1, 0, 1);
                grid.Children.Add(SeparatorV(), 1, 2, 0, 1);
                grid.Children.Add(lbSoLuong, 2, 3, 0, 1);
                grid.Children.Add(SeparatorV(), 3, 4, 0, 1);
                grid.Children.Add(lbLieuDung, 4, 5, 0, 1);
                grid.Children.Add(SeparatorV(), 5, 6, 0, 1);
                grid.Children.Add(lbGhiChu, 6, 7, 0, 1);
                grid.Children.Add(SeparatorH(), 0, 7, 1, 2);

                this.View = grid;

            }
        }
    }
}
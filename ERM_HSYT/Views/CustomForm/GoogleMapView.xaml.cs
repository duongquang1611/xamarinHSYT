using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;

namespace ERM_HSYT.Views.CustomForm
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GoogleMapView : ContentPage
    {
        public GoogleMapView()
        {
            InitializeComponent();
            var bvddPosition = new Position(21.0155443, 105.827184);
            MyMap.MoveToRegion(
                MapSpan.FromCenterAndRadius(
                bvddPosition, Distance.FromMiles(1)));
            MyMap.Pins.Add(new Pin
            {
                Label = "Địa điểm",
                Address = "Bệnh viện đa khoa Đống Đa",
                Position = bvddPosition
            }); 
        }

        public async void OnClickedGGMap(object sender, EventArgs e)
        {
            double latitud = 21.0155443;
            double longitud = 105.827184;
            string placeName = "Bệnh viện đa khoa Đống đa";

            var supportsUri = await Launcher.CanOpenAsync("comgooglemaps://");
            Trace.WriteLine(supportsUri);
            if (supportsUri)
                await Launcher.OpenAsync($"comgooglemaps://?q={latitud},{longitud}({placeName})");
            else
                await Xamarin.Essentials.Map.OpenAsync(21.0155443, 105.827184, new MapLaunchOptions { Name = "Bệnh viện đa khoa Đống Đa" });

        }

    }
}
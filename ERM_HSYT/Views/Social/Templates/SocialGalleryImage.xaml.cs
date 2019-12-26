using System;
using System.Collections.Generic;
using Xamarin.Forms;
using UXDivers.Grial;
using ERM_HSYT.Views.CustomForm;
using System.Diagnostics;

namespace ERM_HSYT
{
    public partial class SocialGalleryImage : ContentView
    {
        public static BindableProperty ImageProperty =
            BindableProperty.Create(
                nameof(Image),
                typeof(ImageSource),
                typeof(SocialGalleryImage),
                null
            );

        public static BindableProperty UrlProperty = BindableProperty.Create(nameof(Url)
            , typeof(String), typeof(String), null);

        public string Url
        {
            get { return (string)GetValue(UrlProperty); }
            set { SetValue(UrlProperty, value); }
        }
        public ImageSource Image
        {
            get { return (ImageSource)GetValue(ImageProperty); }
            set { SetValue(ImageProperty, value); }
        }

        public SocialGalleryImage()
        {
            InitializeComponent();
        }

        private void OnImageTapped(object sender, EventArgs e)
        {
#if !NAVIGATION
            var selectedItem = (SocialGalleryImage)sender;
            //var socialGalleryImagePreview = new SocialGalleryImagePreviewPage(selectedItem.Image);
            //var Url = string.Format("https://ehrdda.hsdt.co/api/v1/HSXPhieuIn/{0}/content", );
            //await Navigation.PushModalAsync(new NavigationPage(socialGalleryImagePreview));
            Navigation.PushAsync(new WebViewPage(selectedItem.Url));
            Debug.Write(selectedItem.Url);
#endif
        }
    }
}


using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using ERM_HSYT.CustomRenderers;
using ERM_HSYT.Droid.CustomRenderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(CustomWebView), typeof(CustomWebViewRenderer))]
namespace ERM_HSYT.Droid.CustomRenderers
{
    [Obsolete]
    public class CustomWebViewRenderer : WebViewRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<WebView> e)
        {
            base.OnElementChanged(e);

            if (Control != null)
            {
                Control.Settings.BuiltInZoomControls = true;
                Control.Settings.DisplayZoomControls = false;

                Control.Settings.LoadWithOverviewMode = true;
                Control.Settings.UseWideViewPort = true;
            }
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (Control != null)
            {
                Control.Settings.BuiltInZoomControls = true;

                //to show the default zoom controls, if you want to use your own button, set this property to false.
                Control.Settings.DisplayZoomControls = true;
            }

            var element = Element as CustomWebView;
            //ZoomIn
            if (e.PropertyName == "ZoomInLevel")
                element.ZoomOutLevel = Control.Settings.TextZoom = element.ZoomInLevel;
            //ZoomOut
            else if (e.PropertyName == "ZoomOutLevel")
                element.ZoomInLevel = Control.Settings.TextZoom = element.ZoomOutLevel;

            base.OnElementPropertyChanged(sender, e);
        }
    }
}
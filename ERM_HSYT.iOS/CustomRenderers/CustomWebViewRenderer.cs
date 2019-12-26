using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ERM_HSYT.CustomRenderers;
using ERM_HSYT.iOS.CustomRenderers;
using Foundation;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
[assembly: ExportRenderer(typeof(CustomWebView), typeof(CustomWebViewRenderer))]
namespace ERM_HSYT.iOS.CustomRenderers
{
    public class CustomWebViewRenderer : WebViewRenderer
    {
        protected override void OnElementChanged(VisualElementChangedEventArgs e)
        {
            base.OnElementChanged(e);

            var view = Element as CustomWebView;
            if (view == null || NativeView == null)
            {
                return;
            }
            this.ScalesPageToFit = true;
        }

    }
}
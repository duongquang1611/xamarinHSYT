using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ERM_HSYT.Views.CustomForm
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WebViewPage : ContentPage
    {
        public UrlWebViewSource UrlWevView = new UrlWebViewSource();
        public HtmlWebViewSource htmlSource = new HtmlWebViewSource();
        private int Clicks { get; set; } = 0;
        public WebViewPage(string _url)
        {
            if (Connectivity.NetworkAccess != NetworkAccess.Internet)
            {
                App.Current.MainPage.DisplayAlert("Internet", "Không có kết nối Internet", "Oke");
                return;

            }
           
                InitializeComponent();
            UrlWevView.Url = _url;
            // Trace.Write(_url);
            // string htmlCode = GetHTMLFromUrl(_url);
            // string htmlCodeRemoveScript = RemoveScript(htmlCode);
            // Trace.Write(htmlCode);
            // Trace.Write(htmlCodeRemoveScript);
            // BindingContext = UrlWevView;

            htmlSource.Html = RemoveScript(GetHTMLFromUrl(_url));
            Trace.WriteLine(GetHTMLFromUrl(_url));
            Trace.WriteLine(htmlSource.Html);
            Wbp.Source = htmlSource;

            //BindingContext = htmlSource;

        }
        private void ZoomIn_Clicked(object sender, EventArgs e)
        {

            if (Clicks++ == 0)
            {
                Wbp.ZoomInLevel = 103;
                return;
            }
            Wbp.ZoomInLevel += 10;
        }

        private void ZoomOut_Clicked(object sender, EventArgs e)
        {
            if (Clicks++ == 0)
            {
                Wbp.ZoomOutLevel = 93;
                return;
            }
            Wbp.ZoomOutLevel -= 10;
        }

        public string GetHTMLFromUrl(string urlAddress)
        {
            //string urlAddress = "http://google.com";

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(urlAddress);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            string data = "";
            if (response.StatusCode == HttpStatusCode.OK)
            {
                Stream receiveStream = response.GetResponseStream();
                StreamReader readStream = null;

                /* if (response.CharacterSet == null)
                {
                    readStream = new StreamReader(receiveStream);
                }
                else
                {
                    readStream = new StreamReader(receiveStream, Encoding.GetEncoding(response.CharacterSet));
                }*/

                readStream = new StreamReader(receiveStream, Encoding.UTF8);

                data = readStream.ReadToEnd();

                response.Close();
                readStream.Close();
            }
            return data;
        }

        public string RemoveScript(string html)
        {
            string output = "";
            Regex rRemScript = new Regex(@"<script[^>]*>[\s\S]*?</script>");
            output = rRemScript.Replace(html, "");

            return output;
        }
    }
}
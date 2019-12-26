using Xamarin.Forms;
using UXDivers.Grial;

namespace ERM_HSYT
{
    public partial class TabControlAndroidSamplePage : ContentPage
    {
        public TabControlAndroidSamplePage()
        {
            InitializeComponent();

            BindingContext = new
            {
                Social = new SocialViewModel(),
                Chat = new ChatMessagesListViewModel()
            };
        }
    }
}
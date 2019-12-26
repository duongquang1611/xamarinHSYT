using Xamarin.Forms;
using UXDivers.Grial;

namespace ERM_HSYT
{
    public partial class TabControlCustomSamplePage : ContentPage
    {
        public TabControlCustomSamplePage()
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
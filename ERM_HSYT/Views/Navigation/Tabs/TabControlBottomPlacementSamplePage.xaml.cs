using Xamarin.Forms;
using UXDivers.Grial;

namespace ERM_HSYT
{
    public partial class TabControlBottomPlacementSamplePage : ContentPage
    {
        public TabControlBottomPlacementSamplePage()
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
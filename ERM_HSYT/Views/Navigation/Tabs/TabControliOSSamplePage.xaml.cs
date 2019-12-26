using Xamarin.Forms;
using UXDivers.Grial;

namespace ERM_HSYT
{
    public partial class TabControliOSSamplePage : ContentPage
    {
        public TabControliOSSamplePage()
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
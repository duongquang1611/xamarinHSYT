using Xamarin.Forms;
using UXDivers.Grial;

namespace ERM_HSYT
{
    public partial class ChatMessagesListPage : ContentPage
    {
        public ChatMessagesListPage()
        {
            InitializeComponent();

            BindingContext = new ChatMessagesListViewModel();
        }
    }
}
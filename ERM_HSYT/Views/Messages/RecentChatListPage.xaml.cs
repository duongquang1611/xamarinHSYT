using Xamarin.Forms;
using UXDivers.Grial;

namespace ERM_HSYT
{
    public partial class RecentChatListPage : ContentPage
    {
        public RecentChatListPage()
        {
            InitializeComponent();

            BindingContext = new ChatMessagesListViewModel(variantPageName: $"{this.GetType().Name}.xaml");
        }
    }
}


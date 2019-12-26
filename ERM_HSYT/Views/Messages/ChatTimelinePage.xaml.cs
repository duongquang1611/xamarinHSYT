using Xamarin.Forms;
using UXDivers.Grial;

namespace ERM_HSYT
{
    public partial class ChatTimelinePage : ContentPage
    {
        public ChatTimelinePage()
        {
            InitializeComponent();

            BindingContext = new ChatMessagesListViewModel(variantPageName: $"{this.GetType().Name}.xaml");
        }
    }
}

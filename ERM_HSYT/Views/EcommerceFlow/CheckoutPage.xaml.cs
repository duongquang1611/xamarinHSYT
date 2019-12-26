using Rg.Plugins.Popup.Services;
using Xamarin.Forms;
using UXDivers.Grial;

namespace ERM_HSYT
{
    public partial class CheckoutPage : ContentPage
    {
        public CheckoutPage()
        {
            InitializeComponent();

            BindingContext = new OrderConfirmationViewModel(null);
        }

        public CheckoutPage(OrderConfirmationViewModel model)
        {
            InitializeComponent();

            BindingContext = model;
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();

            Triggers.Clear();
        }

        private async void OnConfirm(object sender, System.EventArgs e)
        {
            var dialog = new NotificationPopup { Message = Resx.AppResources.OrderPlacedNotification };
            await PopupNavigation.Instance.PushAsync(dialog);

            await Navigation.PopToRootAsync();
        }
    }
}

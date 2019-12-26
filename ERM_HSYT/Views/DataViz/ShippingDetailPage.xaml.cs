using Xamarin.Forms;
using UXDivers.Grial;

namespace ERM_HSYT
{
    public partial class ShippingDetailPage : ContentPage
    {
        public ShippingDetailPage()
        {
            InitializeComponent();

            BindingContext = new ShippingDetailViewModel();
        }
    }
}

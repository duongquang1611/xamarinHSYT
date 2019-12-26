using Xamarin.Forms;
using UXDivers.Grial;

namespace ERM_HSYT
{
    public partial class EcommerceMainPage : ContentPage
    {
        public EcommerceMainPage()
        {
            InitializeComponent();

            BindingContext = new EcommerceMainViewModel();
        }
    }
}

using Xamarin.Forms;
using UXDivers.Grial;

namespace ERM_HSYT
{
    public partial class DashboardCardsPage : ContentPage
    {
        public DashboardCardsPage()
        {
            InitializeComponent();

            BindingContext = new DashboardCardsViewModel();
        }
    }
}
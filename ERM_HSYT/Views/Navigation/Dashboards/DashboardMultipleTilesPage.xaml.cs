using Xamarin.Forms;
using UXDivers.Grial;

namespace ERM_HSYT
{
    public partial class DashboardMultipleTilesPage : ContentPage
    {
        public DashboardMultipleTilesPage()
        {
            InitializeComponent();

            BindingContext = new DashboardMultipleTilesViewModel();
        }
    }
}
using Xamarin.Forms;
using UXDivers.Grial;

namespace ERM_HSYT
{
    public partial class DashboardVariantItemTemplate : DashboardItemTemplateBase
    {
        public DashboardVariantItemTemplate()
        {
            InitializeComponent();
        }

        protected override void OnTapped()
        {
            Application.Current.MainPage.DisplayAlert("Tile Tapped!", "You have tapped a DashboardVariantItemTemplate", "OK");
        }
    }
}
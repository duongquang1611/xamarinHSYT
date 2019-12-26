using Xamarin.Forms;
using UXDivers.Grial;

namespace ERM_HSYT
{
    public partial class DashboardItemTemplate : DashboardItemTemplateBase
    {
        public DashboardItemTemplate()
        {
            InitializeComponent();
        }

        protected override void OnTapped()
        {
            Application.Current.MainPage.DisplayAlert("Item Tapped!", "You have tapped a DashboardItemTemplate", "OK");
        }
    }
}
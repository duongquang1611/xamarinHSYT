using Xamarin.Forms;
using UXDivers.Grial;

namespace ERM_HSYT
{
    public partial class DashboardAppNotificationItemTemplate : DashboardItemTemplateBase
    {
        public DashboardAppNotificationItemTemplate()
        {
            InitializeComponent();
        }

        protected override void OnTapped()
        {
            Application.Current.MainPage.DisplayAlert("Tile Tapped!", "You have tapped a DashboardAppNotificationItemTemplate", "OK");
        }
    }
}
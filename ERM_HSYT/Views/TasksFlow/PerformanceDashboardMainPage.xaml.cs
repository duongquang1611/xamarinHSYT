using Xamarin.Forms;
using UXDivers.Grial;
using UXDivers.Grial;

namespace ERM_HSYT
{
    public partial class PerformanceDashboardMainPage : ContentPage
    {
        public PerformanceDashboardMainPage()
        {
            InitializeComponent();

            BindingContext = new PerformanceDashboardMainViewModel();
        }

        private async void OnItemSelected(object sender, System.EventArgs e)
        {
#if !NAVIGATION
            var page = new EmployeePerformanceDashboardPage(((DataGrid)sender).SelectedItem as FlowEmployeeData);

            await Navigation.PushAsync(page);
#endif
        }
    }
}

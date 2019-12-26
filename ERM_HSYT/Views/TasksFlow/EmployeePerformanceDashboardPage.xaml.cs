using System;
using Xamarin.Forms;
using UXDivers.Grial;

namespace ERM_HSYT
{
    public partial class EmployeePerformanceDashboardPage : ContentPage
    {
        public EmployeePerformanceDashboardPage()
            : this(null)
        {
        }

        public EmployeePerformanceDashboardPage(FlowEmployeeData employee)
        {
            InitializeComponent();

            BindingContext = new EmployeePerformanceDashboardViewModel(employee);
        }

        private async void OnDetail(object sender, EventArgs e)
        {
#if !NAVIGATION
            var page = new EmployeeProfileDashboardPage(
                (((BindableObject)sender).BindingContext as EmployeePerformanceDashboardViewModel)?.Employee);

            await Navigation.PushAsync(page);
#endif
        }
    }
}

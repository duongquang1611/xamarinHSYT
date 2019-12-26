using System;
using Xamarin.Forms;
using UXDivers.Grial;

namespace ERM_HSYT
{
    public partial class PerformanceDashboardNavigationPage
    {
        public PerformanceDashboardNavigationPage()
        {
        }

        public PerformanceDashboardNavigationPage(Page root)
            : base(root)
        {
            InitializeComponent();
        }

        private void OnClose(object sender, EventArgs e)
        {
            Navigation.PopModalAsync();
        }
    }
}

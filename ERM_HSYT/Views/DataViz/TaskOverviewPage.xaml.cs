using Xamarin.Forms;
using UXDivers.Grial;

namespace ERM_HSYT
{
    public partial class TaskOverviewPage : ContentPage
    {
        public TaskOverviewPage()
        {
            InitializeComponent();

            BindingContext = new TaskOverviewViewModel();
        }
    }
}

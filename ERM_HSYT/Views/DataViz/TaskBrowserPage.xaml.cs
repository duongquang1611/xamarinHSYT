using Xamarin.Forms;
using UXDivers.Grial;

namespace ERM_HSYT
{
    public partial class TaskBrowserPage : ContentPage
    {
        public TaskBrowserPage()
        {
            InitializeComponent();

            BindingContext = new TaskBrowserViewModel();
        }
    }
}

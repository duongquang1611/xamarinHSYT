using Xamarin.Forms;
using UXDivers.Grial;

namespace ERM_HSYT
{
    public partial class TimelinePage : ContentPage
    {
        public TimelinePage()
        {
            InitializeComponent();

            BindingContext = new TimelineViewModel();
        }
    }
}


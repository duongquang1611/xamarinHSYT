using Xamarin.Forms;
using UXDivers.Grial;

namespace ERM_HSYT
{
    public partial class DocumentTimelinePage : ContentPage
    {
        public DocumentTimelinePage()
        {
            InitializeComponent ();

            BindingContext = new DocumentTimelineViewModel();
        }
    }
}


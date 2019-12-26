using Xamarin.Forms;
using UXDivers.Grial;

namespace ERM_HSYT
{
    public partial class NavigationListWithImagesPage : ContentPage
    {
        public NavigationListWithImagesPage ()
        {
            InitializeComponent ();

            BindingContext = new NavigationViewModel(variantPageName: $"{this.GetType().Name}.xaml");
        }
    }
}


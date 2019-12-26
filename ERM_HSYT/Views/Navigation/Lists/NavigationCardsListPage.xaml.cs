using Xamarin.Forms;
using UXDivers.Grial;

namespace ERM_HSYT
{
    public partial class NavigationCardsListPage : ContentPage
    {
        public NavigationCardsListPage()
        {
            InitializeComponent();

            BindingContext = new NavigationViewModel(variantPageName: $"{this.GetType().Name}.xaml");
        }
    }
}


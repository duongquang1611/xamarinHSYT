using Xamarin.Forms;
using UXDivers.Grial;

namespace ERM_HSYT
{
    public partial class SocialCardPage : ContentPage
    {
        public SocialCardPage()
        {
            InitializeComponent();

            BindingContext = new SocialViewModel(variantPageName: "SocialCardPage.xaml");
        }
    }
}

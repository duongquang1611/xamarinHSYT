using Xamarin.Forms;
using UXDivers.Grial;

namespace ERM_HSYT
{
    public partial class FeaturedMoviesPage : ContentPage
    {
        public FeaturedMoviesPage()
            : this(null)
        {
        }

        public FeaturedMoviesPage(FeaturedMoviesViewModel context)
        {
            InitializeComponent();

            BindingContext = context ?? new FeaturedMoviesViewModel();
        }
    }
}

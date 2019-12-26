using Xamarin.Forms;
using UXDivers.Grial;

namespace ERM_HSYT
{
    public partial class FeaturedMovieItemTemplate : ContentView
    {
        public FeaturedMovieItemTemplate()
        {
            InitializeComponent();
        }

        private void OnMoveToSecond(object sender, System.EventArgs e)
        {
            carousel.Position = 1;
        }
    }
}

using Xamarin.Forms;
using UXDivers.Grial;

namespace ERM_HSYT
{
    public partial class MovieDetailPage : ContentPage
    {
        public MovieDetailPage()
            : this (null)
        {
        }

        public MovieDetailPage(FlowMovieData movie)
        {
            InitializeComponent();

            BindingContext = new MovieDetailViewModel(movie);
        }
    }
}
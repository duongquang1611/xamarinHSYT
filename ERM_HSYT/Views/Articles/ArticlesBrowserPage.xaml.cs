using Xamarin.Forms;
using UXDivers.Grial;

namespace ERM_HSYT
{
    public partial class ArticlesBrowserPage : ContentPage
    {
        public ArticlesBrowserPage()
        {
            InitializeComponent();

            BindingContext = new ArticlesBrowserViewModel();
        }
    }
}

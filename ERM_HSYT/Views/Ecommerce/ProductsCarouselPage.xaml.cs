using Xamarin.Forms;
using UXDivers.Grial;

namespace ERM_HSYT
{
    public partial class ProductsCarouselPage : CarouselPage
    {
        public ProductsCarouselPage()
        {
            InitializeComponent();

            var model = new ProductsCatalogViewModel();

            for (var i = 0; i < model.List.Count; i++)
            {
                Children.Add(new ProductItemViewPage(model.List[i]));
            }
        }
    }
}
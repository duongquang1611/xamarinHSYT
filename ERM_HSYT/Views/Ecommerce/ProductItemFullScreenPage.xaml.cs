using Xamarin.Forms;
using UXDivers.Grial;

namespace ERM_HSYT
{
    public partial class ProductItemFullScreenPage : ContentPage
    {
        public ProductItemFullScreenPage()
            : this(null)
        {
        }

        public ProductItemFullScreenPage(ProductData product)
        {
            InitializeComponent();

            BindingContext = new ProductItemViewViewModel(product?.Id, variantPageName: $"{this.GetType().Name}.xaml");
        }
    }
}
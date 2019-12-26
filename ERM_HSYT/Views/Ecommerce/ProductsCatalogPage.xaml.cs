using Xamarin.Forms;
using UXDivers.Grial;

namespace ERM_HSYT
{
    public partial class ProductsCatalogPage : ContentPage
    {
        public ProductsCatalogPage()
        {
            InitializeComponent();

            BindingContext = new ProductsCatalogViewModel();
        }

        public async void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
#if !NAVIGATION
            var selectedItem = ((ListView)sender).SelectedItem;
            var productPage = new ProductItemViewPage(selectedItem as ProductData);

            await Navigation.PushAsync(productPage);
#endif
        }
    }
}
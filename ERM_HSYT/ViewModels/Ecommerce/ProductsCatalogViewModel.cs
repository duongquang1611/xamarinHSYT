using System.Collections.ObjectModel;
using System.Globalization;
using UXDivers.Grial;

namespace ERM_HSYT
{
    public class ProductsCatalogViewModel : ObservableObject
    {
        private readonly string _variantPageName;

        public ProductsCatalogViewModel(string variantPageName = null)
            : base(listenCultureChanges: true)
        {
            _variantPageName = variantPageName;

            LoadData();
        }

        public ObservableCollection<ProductData> List { get; } = new ObservableCollection<ProductData>();

        protected override void OnCultureChanged(CultureInfo culture)
        {
            LoadData();
        }

        private void LoadData()
        {
            List.Clear();

            JsonHelper.Instance.LoadViewModel(this, pageName: _variantPageName, source: "Ecommerce.json");
        }
    }
}

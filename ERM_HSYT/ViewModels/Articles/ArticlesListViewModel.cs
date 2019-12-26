using System.Collections.ObjectModel;
using System.Globalization;
using UXDivers.Grial;

namespace ERM_HSYT
{
    public class ArticlesListViewModel : ObservableObject
    {
        private readonly string _variantPageName;

        public ArticlesListViewModel(string variantPageName = null)
            : base(listenCultureChanges: true)
        {
            _variantPageName = variantPageName;

            LoadData();
        }

        public ObservableCollection<ArticleData> List { get; } = new ObservableCollection<ArticleData>();

        protected override void OnCultureChanged(CultureInfo culture)
        {
            LoadData();
        }

        private void LoadData()
        {
            List.Clear();

            JsonHelper.Instance.LoadViewModel(this, pageName: _variantPageName, source: "Articles.json");
        }
    }
}

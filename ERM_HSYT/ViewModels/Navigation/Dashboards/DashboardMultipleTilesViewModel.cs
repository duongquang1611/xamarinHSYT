using System.Collections.ObjectModel;
using System.Globalization;
using UXDivers.Grial;

namespace ERM_HSYT
{
    public class DashboardMultipleTilesViewModel : ObservableObject
    {
        public DashboardMultipleTilesViewModel()
            : base(listenCultureChanges: true)
        {
            LoadData();
        }

        public ObservableCollection<DashboardMultipleTileItemData> Items { get; } = new ObservableCollection<DashboardMultipleTileItemData>();

        protected override void OnCultureChanged(CultureInfo culture)
        {
            LoadData();
        }

        private void LoadData()
        {
            Items.Clear();

            JsonHelper.Instance.LoadViewModel(this, source: "NavigationDashboards.json");
        }
    }
}
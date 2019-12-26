using System.Collections.ObjectModel;
using System.Globalization;
using UXDivers.Grial;

namespace ERM_HSYT
{
    public class TaskOverviewViewModel : ObservableObject
    {
        private BrowserTaskOverviewData _urgent, _maintenance, _closed;
        private string _period;

        public TaskOverviewViewModel()
            : base(listenCultureChanges: true)
        {
            LoadData();
        }

        protected override void OnCultureChanged(CultureInfo culture)
        {
            LoadData();
        }

        public ObservableCollection<BrowserPeopleTaskOverviewData> People { get; } = new ObservableCollection<BrowserPeopleTaskOverviewData>();

        public string Period
        {
            get { return _period; }
            set { SetProperty(ref _period, value); }
        }

        public BrowserTaskOverviewData Urgent
        {
            get { return _urgent; }
            set { SetProperty(ref _urgent, value); }
        }

        public BrowserTaskOverviewData Maintenance
        {
            get { return _maintenance; }
            set { SetProperty(ref _maintenance, value); }
        }

        public BrowserTaskOverviewData Closed
        {
            get { return _closed; }
            set { SetProperty(ref _closed, value); }
        }

        private void LoadData()
        {
            People.Clear();

            JsonHelper.Instance.LoadViewModel(this, source: "DataViz.json");
        }
    }
}

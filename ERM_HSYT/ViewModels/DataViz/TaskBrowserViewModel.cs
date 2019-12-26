using System.Collections.ObjectModel;
using System.Globalization;
using UXDivers.Grial;

namespace ERM_HSYT
{
    public class TaskBrowserViewModel : ObservableObject
    {
        private string _date;

        public TaskBrowserViewModel()
            : base(listenCultureChanges: true)
        {
            LoadData();
        }

        protected override void OnCultureChanged(CultureInfo culture)
        {
            LoadData();
        }

        public ObservableCollection<TaskOverviewGroupData> Workspaces { get; } = new ObservableCollection<TaskOverviewGroupData>();
        public ObservableCollection<TaskOverviewGroupData> Projects { get; } = new ObservableCollection<TaskOverviewGroupData>();

        public string Date
        {
            get { return _date; }
            set { SetProperty(ref _date, value); }
        }

        private void LoadData()
        {
            Workspaces.Clear();
            Projects.Clear();

            JsonHelper.Instance.LoadViewModel(this, source: "DataViz.json");
        }
    }
}

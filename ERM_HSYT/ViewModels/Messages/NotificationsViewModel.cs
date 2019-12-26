using System.Collections.ObjectModel;
using System.Globalization;
using UXDivers.Grial;

namespace ERM_HSYT
{
    public class NotificationsViewModel : ObservableObject
    {
        public NotificationsViewModel()
            : base(listenCultureChanges: true)
        {
            LoadData();
        }

        public ObservableCollection<NotificationData> Notifications { get; } = new ObservableCollection<NotificationData>();

        protected override void OnCultureChanged(CultureInfo culture)
        {
            LoadData();
        }

        private void LoadData()
        {
            Notifications.Clear();

            JsonHelper.Instance.LoadViewModel(this, source: "Messages.json");
        }
    }
}
using System;
using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using UXDivers.Grial;

namespace ERM_HSYT
{
    public partial class SimpleDialog : PopupPage
    {
        public SimpleDialog(string id = "")
        {
            InitializeComponent();
            cls.Source = "https://ehrdda.hsdt.co/api/v1/HSXPhieuIn/" + id + "/content";
        }

        private void OnClose(object sender, EventArgs e)
        {
            PopupNavigation.Instance.PopAsync();
        }
    }
}

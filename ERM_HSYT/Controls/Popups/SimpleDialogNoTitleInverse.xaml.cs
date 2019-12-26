using System;
using System.Collections.Generic;
using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;
using UXDivers.Grial;

namespace ERM_HSYT
{
    public partial class SimpleDialogNoTitle : PopupPage
    {
        public SimpleDialogNoTitle()
        {
            InitializeComponent();
        }


        private void OnClose(object sender, EventArgs e)
        {
            PopupNavigation.Instance.PopAsync();
        }
    }
}

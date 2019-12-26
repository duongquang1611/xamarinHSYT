using System;
using Xamarin.Forms;
using UXDivers.Grial;

namespace ERM_HSYT
{
    public partial class ChatNavigationPage
    {
        public ChatNavigationPage()
        {
        }

        public ChatNavigationPage(Page root)
            : base(root)
        {
            InitializeComponent();
        }

        private void OnClose(object sender, EventArgs e)
        {
            Navigation.PopModalAsync();
        }
    }
}

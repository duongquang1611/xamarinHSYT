using System;
using System.Collections.Generic;
using Xamarin.Forms;
using UXDivers.Grial;

namespace ERM_HSYT
{
    public partial class NotificationsPage : ContentPage
    {
        public NotificationsPage()
        {
            InitializeComponent();

            BindingContext = new NotificationsViewModel();
        }
    }
}


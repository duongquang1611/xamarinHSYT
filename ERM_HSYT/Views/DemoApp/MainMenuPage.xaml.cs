using System;
using Xamarin.Forms;
using UXDivers.Grial;

namespace ERM_HSYT
{
    public partial class MainMenuPage : ContentPage
    {
        public MainMenuPage(Action<Page> openPageAsRoot)
        {
            InitializeComponent();

            BindingContext = new MainMenuViewModel(Navigation, openPageAsRoot);
        }
    }
}
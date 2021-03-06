using System;
using ERM_HSYT.Resx;
using Xamarin.Forms;
using UXDivers.Grial;

namespace ERM_HSYT
{
    public partial class CardArticlePage : ContentPage
    {
        public CardArticlePage()
        {
            InitializeComponent();

            BindingContext = new ComplexArticleDetailViewModel(pageName: $"{this.GetType().Name}.xaml");
        }

        public void OnPrimaryActionButtonClicked(object sender, EventArgs e)
        {
            DisplayAlert(AppResources.StringButtonTapped, AppResources.ButtonAddComment, AppResources.StringOK);
        }
    }
}

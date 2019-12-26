using System;
using Xamarin.Forms;
using UXDivers.Grial;

namespace ERM_HSYT
{
    public partial class ArticlesListPage : ContentPage
    {
        public ArticlesListPage ()
        {
            InitializeComponent ();

            BindingContext = new ArticlesListViewModel();
        }

        private async void OnItemTapped(object sender, EventArgs e)
        {
#if !NAVIGATION
            var selectedItem = ((ListView)sender).SelectedItem;
            var articlePage = new ArticleDetailPage(selectedItem as ArticleData);

            await Navigation.PushAsync(articlePage);
#endif
        }
    }
}


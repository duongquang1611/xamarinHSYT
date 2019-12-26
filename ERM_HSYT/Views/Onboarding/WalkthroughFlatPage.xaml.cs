using UXDivers.Grial;
namespace ERM_HSYT
{
    public partial class WalkthroughFlatPage : WalkthroughBasePage
    {
        public WalkthroughFlatPage()
        {
            InitializeComponent();

            BindingContext = new WalkthroughViewModel(Close, MoveNext);
        }
    }
}


using UXDivers.Grial;
namespace ERM_HSYT
{
    public partial class WalkthroughVariantPage : WalkthroughBasePage
    {
        public WalkthroughVariantPage()
        {
            InitializeComponent();

            BindingContext = new WalkthroughViewModel(Close, MoveNext);
        }
    }
}
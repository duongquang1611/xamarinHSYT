using UXDivers.Grial;
namespace ERM_HSYT
{
    public partial class WalkthroughIllustrationPage : WalkthroughBasePage
    {
        public WalkthroughIllustrationPage()
        {
            InitializeComponent();

            BindingContext = new WalkthroughViewModel(Close, MoveNext);
        }
    }
}

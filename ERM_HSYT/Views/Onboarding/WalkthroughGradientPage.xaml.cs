using UXDivers.Grial;
namespace ERM_HSYT
{
    public partial class WalkthroughGradientPage : WalkthroughBasePage
    {
        public WalkthroughGradientPage()
        {
            InitializeComponent();

            BindingContext = new WalkthroughViewModel(Close, MoveNext);
        }
    }
}

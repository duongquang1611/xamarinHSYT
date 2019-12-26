using UXDivers.Grial;
namespace ERM_HSYT
{
    public partial class WalkthroughMinimalPage : WalkthroughBasePage
    {
        public WalkthroughMinimalPage()
        {
            InitializeComponent();

            BindingContext = new WalkthroughViewModel(Close, MoveNext);
        }
    }
}
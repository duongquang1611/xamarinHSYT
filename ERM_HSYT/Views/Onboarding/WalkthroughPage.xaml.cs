using UXDivers.Grial;
namespace ERM_HSYT
{
    public partial class WalkthroughPage : WalkthroughBasePage
    {
        public WalkthroughPage()
        {
            InitializeComponent();

            BindingContext = new WalkthroughViewModel(Close, MoveNext);
        }
    }
}
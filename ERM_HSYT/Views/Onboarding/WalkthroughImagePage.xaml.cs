using UXDivers.Grial;
namespace ERM_HSYT
{
    public partial class WalkthroughImagePage : WalkthroughBasePage
    {
        public WalkthroughImagePage()
        {
            InitializeComponent();

            BindingContext = new WalkthroughViewModel(Close, MoveNext);
        }
    }
}

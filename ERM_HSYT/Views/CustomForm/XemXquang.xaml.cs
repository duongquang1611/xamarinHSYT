using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ERM_HSYT
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class XemXQuang : WalkthroughBasePage
    {
        public XemXQuang()
        {
            InitializeComponent();
            BindingContext = new WalkthroughViewModel(Close, MoveNext);
        }
    }
}
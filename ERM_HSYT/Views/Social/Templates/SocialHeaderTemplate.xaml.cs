using Xamarin.Forms;
using UXDivers.Grial;

namespace ERM_HSYT
{
    public partial class SocialHeaderTemplate : ContentView
    {
        public SocialHeaderTemplate()
        {
            InitializeComponent();
        }

        public static BindableProperty TextProperty =
            BindableProperty.Create(
                nameof(Text),
                typeof(string),
                typeof(SocialHeaderTemplate),
                string.Empty,
                propertyChanged: (bindable, oldValue, newValue) =>
                {
                    var ctrl = (SocialHeaderTemplate)bindable;
                    ctrl.HeaderLabel.Text = (string)newValue;
                }
            );

        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        /* ICON */

        public static BindableProperty IconTextProperty =
            BindableProperty.Create(
                nameof(IconText),
                typeof(string),
                typeof(SocialHeaderTemplate),
                string.Empty,
                propertyChanged: (bindable, oldValue, newValue) =>
                {
                    var ctrl = (SocialHeaderTemplate)bindable;
                    ctrl.HeaderIcon.Text = (string)newValue;
                }
            );

        public string IconText
        {
            get { return (string)GetValue(IconTextProperty); }
            set { SetValue(IconTextProperty, value); }
        }
    }
}


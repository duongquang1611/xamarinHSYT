using ERM_HSYT.ViewModels.Custom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ERM_HSYT.Views.CustomForm
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ChangePasswordView : ContentPage
    {
        public ChangePasswordView()
        {
            InitializeComponent();
            BindingContext = new ChangePasswordViewModel();
        }

        void InitStates()
        {
            var stateGroup = new VisualStateGroup
            {
                Name = "StrengthStates",
                TargetType = typeof(Label)
            };
            stateGroup.States.Add(CreateState("Blank", "\uf023 \uf023 \uf023 \uf023 \uf023", Color.Gray));
            stateGroup.States.Add(CreateState("VeryWeak", "\uf023", Color.Red));
            stateGroup.States.Add(CreateState("Weak", "\uf023 \uf023", Color.Orange));
            stateGroup.States.Add(CreateState("Medium", "\uf023 \uf023 \uf023", Color.Yellow));
            stateGroup.States.Add(CreateState("String", "\uf023 \uf023 \uf023 \uf023", Color.Blue));
            stateGroup.States.Add(CreateState("VeryStrong", "\uf023 \uf023 \uf023 \uf023 \uf023", Color.ForestGreen));

            VisualStateManager.SetVisualStateGroups(this.StrengthIndicator, new VisualStateGroupList { stateGroup });

        }


        void Handle_TextChanged(object sender, TextChangedEventArgs e)
        {
            var strength = PasswordAdvisor.CheckStrength(e.NewTextValue);
            var strengthName = Enum.GetName(typeof(PasswordScore), strength);
            VisualStateManager.GoToState(this.StrengthIndicator, strengthName);
        }

        enum PasswordScore
        {
            Blank = 0,
            VeryWeak = 1,
            Weak = 2,
            Medium = 3,
            Strong = 4,
            VeryStrong = 5
        }

        class PasswordAdvisor
        {
            public static PasswordScore CheckStrength(string password)
            {
                int score = 0;

                if (password.Length > 4)
                    score++;

                if (password.Length >= 8)
                    score++;
                if (password.Length >= 12)
                    score++;
                if (Regex.Match(password, @"^(?=.*\d).+$", RegexOptions.ECMAScript).Success)
                    score++;
                if (Regex.Match(password, @"^(?=.*[a-z]).+$", RegexOptions.ECMAScript).Success &&
                                    Regex.Match(password, @"^(?=.*[A-Z]).+$", RegexOptions.ECMAScript).Success)
                    score++;
                if (Regex.Match(password, @"^(?=.*[!,@,#,$,%,^,&,*,?,_,~,-,£,(,)]).+$", RegexOptions.ECMAScript).Success)
                    score++;

                return (PasswordScore)score;
            }
        }


        string strength;

        public string Strength
        {
            get => strength;
            set
            {
                strength = value;
                OnPropertyChanged(nameof(Strength));
            }
        }

        static VisualState CreateState(string strength, string text, Color color)
        {
            var textSetter = new Setter { Value = text, Property = Label.TextProperty };
            var colorSetter = new Setter { Value = color, Property = Label.TextColorProperty };

            return new VisualState
            {
                Name = strength,
                TargetType = typeof(Label),
                Setters = { textSetter, colorSetter }
            };
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            this.StrengthIndicator.Text = "\uf023 \uf023 \uf023 \uf023 \uf023";
            this.StrengthIndicator.TextColor = Color.LightGray;
            InitStates();
        }
        private async void OnLoginTapped(object sender, EventArgs e)
        {
#if !NAVIGATION
            await Navigation.PushAsync(new LoginPage());
#endif
        }

        private async void OnCloseButtonClicked(object sender, EventArgs args)
        {
            await Navigation.PopModalAsync();
        }
    }
}
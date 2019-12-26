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
    public partial class ChangeInfoUserView : ContentPage
    {
        IList<Color> Colors = new List<Color>() { Color.White, Color.Orange, Color.Blue, Color.Green, Color.DarkViolet, Color.DarkRed };

        public ChangeInfoUserView()
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
            String lockSign = GrialIconsFont.Lock;
            Func<String, int, String> GetStr = (str, n) => new StringBuilder(str.Length * n).Insert(0, str, n).ToString();
            stateGroup.States.Add(CreateState("Blank", GetStr(lockSign, 0), Colors[0]));
            stateGroup.States.Add(CreateState("VeryWeak", GetStr(lockSign, 1), Colors[1]));
            stateGroup.States.Add(CreateState("Weak", GetStr(lockSign, 2), Colors[2]));
            stateGroup.States.Add(CreateState("Medium", GetStr(lockSign, 3), Colors[3]));
            stateGroup.States.Add(CreateState("String", GetStr(lockSign, 4), Colors[4]));
            stateGroup.States.Add(CreateState("VeryStrong", GetStr(lockSign, 5), Colors[5]));

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

                if (password.Length > 5)
                    score++;

                if (password.Length >= 8)
                    score++;
                if (password.Length >= 12)
                    score++;
                if (password.Length > 5 && Regex.Match(password, @"^(?=.*\d).+$", RegexOptions.ECMAScript).Success)
                    score++;
                if (password.Length > 5 && Regex.Match(password, @"^(?=.*[a-z]).+$", RegexOptions.ECMAScript).Success &&
                                    Regex.Match(password, @"^(?=.*[A-Z]).+$", RegexOptions.ECMAScript).Success)
                    score++;
                if (password.Length > 5 && Regex.Match(password, @"^(?=.*[!,@,#,$,%,^,&,*,?,_,~,-,£,(,)]).+$", RegexOptions.ECMAScript).Success)
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
            this.StrengthIndicator.Text = "";
            this.StrengthIndicator.TextColor = Color.White;
            InitStates();
        }

        public async void onTabChangeUserInfo(object sender, EventArgs e)
        {
            await App.Current.MainPage.DisplayAlert("ok", "Chức năng này chưa được đưa vào sử dụng", "ok");
        }
    }
}
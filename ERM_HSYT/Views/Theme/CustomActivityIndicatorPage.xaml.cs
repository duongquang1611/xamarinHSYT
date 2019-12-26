using System;
using System.Collections.Generic;

using Xamarin.Forms;
using UXDivers.Grial;

namespace ERM_HSYT
{
	public partial class CustomActivityIndicatorPage : ContentPage
	{
		public CustomActivityIndicatorPage()
		{
			InitializeComponent();
		}

		protected override void OnAppearing()
		{
			base.OnAppearing();

			Indicator.Start();
		}

		protected override void OnDisappearing()
		{
			base.OnDisappearing();

			Indicator.Stop();
		}
	}
}


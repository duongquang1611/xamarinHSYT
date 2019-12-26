using ERM_HSYT.ViewModels;
using ERM_HSYT.ViewModels.Custom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ERM_HSYT.Views.CustomForm
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MedicinesDetailView : ContentPage
    {
        public MedicinesDetailView(List<HSDonThuocModel> dsThuoc)
        {
            InitializeComponent();
            BindingContext = new MedicinesDetailViewModel(dsThuoc);
           
        }

        
        
    }
}
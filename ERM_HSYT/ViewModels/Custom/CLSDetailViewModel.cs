using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using static ERM_HSYT.ViewModels.Custom.CLSViewModel;

namespace ERM_HSYT.ViewModels.Custom
{
    
    public class CLSDetailViewModel
    {
        public List<HSPhieuChiDinhModel> DsCLS { get; set; }

        public string Date { get; set; }

        public CLSDetailViewModel(List<HSPhieuChiDinhModel> dscd, string date)
        {
            DsCLS = dscd;
            Date = date;
            Trace.WriteLine("KKKKKKKKKKKKKK " + DsCLS[0].PhieuIn);
        }

    }
}

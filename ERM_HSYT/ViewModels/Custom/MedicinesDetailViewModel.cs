using System;
using System.Collections.Generic;
using System.Text;

namespace ERM_HSYT.ViewModels.Custom
{
    public class MedicinesDetailViewModel
    {
        public IList<HSDonThuocModel> DsThuoc { get; set; }
        public MedicinesDetailViewModel(List<HSDonThuocModel> dsThuoc)
        {
            DsThuoc = dsThuoc;
            int stt = 1;
            foreach (HSDonThuocModel ds in DsThuoc)
            {
                ds.STT = stt++;
            }
        }

    }

}

using System;
using System.Collections.Generic;
using System.Text;

namespace ERM_HSYT.Models
{
    public class LanKham
    {
        public Guid Id { get; set; }
        public string Ma { get; set; }
        public DateTime NgayKham { get; set; }
        public string TenBenhNhan { get; set; }
        public string TenBacSi { get; set; }
        public string TenPhongKham { get; set; }
        public string NoiDungKham { get; set; }
        public string ChanDoan { get; set; }
        public string MaICD { get; set; }
        public bool IsKetQuaCLS { get; set; }
        public bool IsUuTien { get; set; }
        public bool IsBHYT { get; set; }
    }
}

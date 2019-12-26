using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERM_HSYT.Models
{
    public class KhoaPhong
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Domain { get; set; }
        public string IdHospital { get; set; }
        public string IdParent { get; set; }
        public string Level { get; set; }
        public string IdLoai { get; set; }
        public string sMaLoai { get; set; }
        public string sMaLoaiLever { get; set; }
        public string UuTien { get; set; }
        public string IdKho { get; set; }
        public string GhiChu { get; set; }
        public string MaBH { get; set; }
        public string MaLoaiBenhAn { get; set; }
        public string MaLIS { get; set; }
        public string Id { get; set; }
        public bool Active { get; set; }
        public int State { get; set; }
    }
}

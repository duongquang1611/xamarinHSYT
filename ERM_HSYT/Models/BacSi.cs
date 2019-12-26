using System;
using System.Collections.Generic;
using System.Text;

namespace ERM_HSYT.Models
{
    public class List
    {
        public string Domain { get; set; }
        public string IdChucDanh { get; set; }
        public string IdChucVu { get; set; }
        public string HoTen { get; set; }
        public string HoTenKhongDau { get; set; }
        public string CCHN { get; set; }
        public string ChuKy { get; set; }
        public bool IsActive { get; set; }
        public string JoinDate { get; set; }
        public string Email { get; set; }
        public bool EmailConfirmed { get; set; }
        public string PasswordHash { get; set; }
        public string SecurityStamp { get; set; }
        public string PhoneNumber { get; set; }
        public bool PhoneNumberConfirmed { get; set; }
        public bool TwoFactorEnabled { get; set; }
        public string LockoutEndDateUtc { get; set; }
        public string LockoutEnabled { get; set; }
        public string AccessFailedCount { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Level { get; set; }
        public string IdNodes { get; set; }
        public string IdDonVi { get; set; }
        public string ListIdKhoa { get; set; }
        public string ListIdPhong { get; set; }
        public string ListGroup { get; set; }
        public string sChucDanh { get; set; }
        public string sChucVu { get; set; }
        public string LstKhoaKham { get; set; }
        public string LstPhongKham { get; set; }
        public string IdKhoa { get; set; }
        public string IdPhong { get; set; }
        public string IdGroup { get; set; }
        public string IdKho { get; set; }
        public string MaLIS { get; set; }
        public string Id { get; set; }
        public bool Active { get; set; }
        public int State { get; set; }
    }
    public class RootBacSi
    {
        public string total { get; set; }
        public string sum { get; set; }
        public List<List> List { get; set; }
    }
}

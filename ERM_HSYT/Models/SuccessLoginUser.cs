using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERM_HSYT.Models
{
    public class SuccessLoginUser
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Username { get; set; }
        public int IndexHospitalImage { get; set; }
        public bool RememberMe { get; set; }

        public SuccessLoginUser() { }
        public SuccessLoginUser(string username, int index, bool remember)
        {
            Username = username;
            IndexHospitalImage = index;
            RememberMe = remember;
        }
    }
}

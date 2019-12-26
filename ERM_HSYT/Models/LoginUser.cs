using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace ERM_HSYT.Models
{
    public class LoginUser
    {
        public Guid Id { get; set; }
        [PrimaryKey, AutoIncrement]
        public int AppId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public LoginUser()
        {
        }
        public LoginUser(string username, string password)
        {
            Username = username;
            Password = password;
        }

        public bool CheckInformation()
        {
            if (this.Username == null || this.Password == null || this.Username.Equals("") || this.Password.Equals("")) return false;
            return true;
        }
    }
}

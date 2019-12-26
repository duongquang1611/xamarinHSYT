using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERM_HSYT.Models
{
    class LogoutUser
    {
       
        public Guid Id { get; set; }
        [PrimaryKey, AutoIncrement]
        public int AppId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public LogoutUser()
        {
        }
        public LogoutUser(int id)
        {
            AppId = id;  
        }
    }
}

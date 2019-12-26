using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace ERM_HSYT.Models
{
    public class Token
    {
        [PrimaryKey, AutoIncrement]
        public int AppId { get; set; }
        public string access_token { get; set; }
        public string refresh_token { get; set; }
        public bool useRefreshTokens { get; set; }
        public string userName { get; set; }
        public string Domain { get; set; }
        public string HoTen { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime expires { get; set; }
        public int expires_in { get; set; }
        public Token()
        {
        }
    }
}

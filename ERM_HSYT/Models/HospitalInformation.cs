using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace ERM_HSYT.Models
{
    public class HospitalInformation
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string LoginUrl { get; set; }
        public string BaseUrl { get; set; }
        public string clientId { get; set; }
        public string grantType { get; set; }

        private string _hospitalInformation;
        public string HospitalImageUrl
        {
            get
            {
                return _hospitalInformation;
            }
            set
            {
                _hospitalInformation = value;
                NotifyPropertyChanged(nameof(HospitalImageUrl));
            }
        }
        private string _hospitalName;
        public string HospitalName
        {
            get
            {
                return _hospitalName;
            }
            set
            {
                _hospitalName = value;
                NotifyPropertyChanged(nameof(HospitalName));
            }
        }
        public HospitalInformation() { }
        public HospitalInformation(string LoginUrl, string BaseUrl, string clientId, string grantType, string HospitalImageUrl, string HospitalName)
        {
            this.LoginUrl = LoginUrl;
            this.BaseUrl = BaseUrl;
            this.clientId = clientId;
            this.grantType = grantType;
            this.HospitalImageUrl = HospitalImageUrl;
            this.HospitalName = HospitalName;
        }

        public HospitalInformation Clone()
        {
            return new HospitalInformation(LoginUrl, BaseUrl, clientId, grantType, HospitalImageUrl, HospitalName);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}


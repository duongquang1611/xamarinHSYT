using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace ERM_HSYT
{
    class XemThuocViewModel : INotifyPropertyChanged
    {
        private string _tenThuoc;
        private int _soLuong;
        private string _lieuLuong;
        private string _ghiChu;

        public string TenThuoc
        {
            get { return _tenThuoc; }
            set
            {
                _tenThuoc = value;
                RaisePropertyChanged("TenThuoc");
            }
        }

        public int SoLuong
        {
            get { return _soLuong; }
            set
            {
                _soLuong = value;
                RaisePropertyChanged("SoLuong");
            }
        }

        public string LieuLuong
        {
            get { return _lieuLuong; }
            set
            {
                _lieuLuong = value;
                RaisePropertyChanged("LieuLuong");
            }
        }

        public string GhiChu
        {
            get { return _ghiChu; }
            set
            {
                _ghiChu = value;
                RaisePropertyChanged("GhiChu");
            }
        }

        public XemThuocViewModel() { }

        public XemThuocViewModel(string tenThuoc, int soLuong, string lieuLuong, string ghiChu)
        {
            TenThuoc = tenThuoc;
            SoLuong = soLuong;
            LieuLuong = lieuLuong;
            GhiChu = ghiChu;

        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void RaisePropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }


    }
}

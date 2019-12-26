using ERM_HSYT.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace ERM_HSYT.ViewModels.Custom
{
    public class ReportsViewModel
    {
        public ReportsViewModel()            
        {
            LoadData();
        }

        public ObservableCollection<ReportData> Reports { get; } = new ObservableCollection<ReportData>();


        private void LoadData()
        {
            Reports.Clear();
            for (int i = 0; i < 5; i++)
            {
                Reports.Add(new ReportData
                {
                    Ngay = "6/8/2019",
                    Title = "Thông báo lịch hẹn",
                    Content = "Bạn có lịch hẹn khám sức khỏe vào tháng tới",
                    IsRead = i % 2 == 1 ? false : true,
                    WordColor = i % 2 == 0 ? "Black" : "DarkGray",
                    WordType = i % 2 == 0 ? "Bold" : "None",
                    StarColor = i % 2 == 0 ? "Red" : "DarkGray"
                }); 
            }
            
        }
    }
}


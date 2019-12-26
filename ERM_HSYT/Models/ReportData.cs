using System;
using System.Collections.Generic;
using System.Text;

namespace ERM_HSYT.Models
{
    public class ReportData
    {
        public String Ngay { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public bool IsRead { get; set; }
        public string WordColor { get; set; }
        public string WordType { get; set; }

        public string StarColor { get; set; }
    }
}

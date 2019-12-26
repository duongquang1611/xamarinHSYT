using System;
using System.Collections.Generic;
using System.Text;

namespace ERM_HSYT.Models
{
    public class Constants
    {
        public static bool IsDev { get; set; }

        //------ Login -----
        //public static string LoginUrl = "http://42.113.207.234:9030/oauth/token";
        //public static string BaseUrl = "http://42.113.207.234:9030/api/01004";

        public static string LoginUrl = "https://bvdkdongda.hosoyte.com/oauth/token";
        public static string BaseUrl = "https://bvdkdongda.hosoyte.com/api/01004/";
        public static string clientId = "3E46A49F-EE20-4A48-B29C-48B010026E1F";
        public static string grantType = "password";


        // api dong da
        public static string BaseUrlDongDa = "https://bvdkdongda.hosoyte.com/api/01004/";
        public static string BaseUrlLichHenDongDa = "https://bvdkdongda.hosoyte.com/api/01004/hsyt/lichhens";

        /*
        Nội dung    Api link demo
        Ds bác sĩ   https://bvdkdongda.hosoyte.com/api/01004/canbos/showByDomain
        Ds khoa phòng https://bvdkdongda.hosoyte.com/api/01004/khoaphongs
        Ds lịch hẹn https://bvdkdongda.hosoyte.com/api/01004/hsyt/lichhens?iState=-1
        Ds lịch hẹn theo ngày https://bvdkdongda.hosoyte.com/api/01004/hsyt/lichhens/theongay?from=2019-01-01&to=2019-03-01&iState=-1
        Ds lịch hẹn theo bệnh nhân  https://bvdkdongda.hosoyte.com/api/01004/hsyt/benhnhans/F1E1D641-A912-412F-9316-D6C3C3156EF9/lichhens
        Tạo lịch hẹn https://bvdkdongda.hosoyte.com/api/01004/hsyt/lichhens
        Xóa lịch hẹn https://bvdkdongda.hosoyte.com/api/01004/hsyt/lichhens
            */
    }
}

using ERM_HSYT.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERM_HSYT.Models
{
    public class LichHenView
    {
        public Guid Ma { get; set; }
        //public string Domain { get; set; }
        public int STT { get; set; }
        //public DateTime NgayHen { get; set; }
        public string Room { get; set; }
        public BenhNhan BenhNhan { get; set; }
        public string Ngay { get; set; }
        public string Gio { get; set; }
        public byte? ITrangThai { get; set; }
        public string GhiChu { get; set; }

    }

    public class BenhNhan
    {
        public string Name { get; set; }
        public string Avatar { get; set; }
    }

    public class LichHenData
    {
        public Guid id { get; set; }
        public string title { get; set; }
        public string start { get; set; }
        public detailLichHen meta { get; set; }
    }

    public class detailLichHen : detailLichHenPost
    {
        public string idPatient { get; set; }

        public detailLichHen(string user, string patientName, string patientMobile, string room, string doctor, string phone, string note, string creator, string idPatient) : base(user, patientName, patientMobile, room, doctor, phone, note, creator)
        {
            this.idPatient = idPatient;
        }
    }

    [Serializable]
    public class detailLichHenPost
    {
        public string user { get; set; }
        public string patientName { get; set; }
        public string patientMobile { get; set; }
        public string room { get; set; }
        public string doctor { get; set; }
        public string phone { get; set; }
        public string note { get; set; }
        public string creator { get; set; }

        public detailLichHenPost(string user, string patientName, string patientMobile, string room, string doctor, string phone, string note, string creator)
        {
            this.user = user;
            this.patientName = patientName;
            this.patientMobile = patientMobile;
            this.room = room;
            this.doctor = doctor;
            this.phone = phone;
            this.note = note;
            this.creator = creator;
        }
    }

    [Serializable]
    public class Color
    {
        public string primary { get; set; }
        public string secondary { get; set; }

        public Color(string primary, string secondary)
        {
            this.primary = primary;
            this.secondary = secondary;
        }
    }

    [Serializable]
    public class LichHenPost
    {
        public string title { get; set; }
        public string start { get; set; }
        public detailLichHenPost meta { get; set; }
        public readonly Color color = new Color("#1e90ff", "#D1E8FF");

        public LichHenPost(string title, string start, detailLichHenPost meta)
        {
            this.title = title;
            this.start = start;
            this.meta = meta;
        }

        public LichHenPost()
        {
        }
    }
}

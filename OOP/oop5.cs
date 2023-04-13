using System;
using System.Collections.Generic;

namespace OOP5
{
    class Nguoi
    {
        public string HoTen { get; set; }
        public int Tuoi { get; set; }
        public string SCMND { get; set; }
        public Nguoi(string _HoTen, int _Tuoi, string _SCMND)
        {
            HoTen = _HoTen;
            Tuoi = _Tuoi;
            SCMND = _SCMND;
        }
    }
    class KhachSan
    {
        public int SoNgayThue { get; set; }
        public string LoaiPhong { get; set; }
        public List<Nguoi> nguoiThuePhong { get; set; }
        public KhachSan()
        {
            nguoiThuePhong = new List<Nguoi>();
        }
        public void ThemMoi(int _SoNgayThue, string _LoaiPhong, Nguoi nguoi)
        {
            SoNgayThue= _SoNgayThue;
            LoaiPhong= _LoaiPhong;
            nguoiThuePhong.Add(nguoi);
        }
        public void XoaTheoCMND(string _SCMND)
        {
            foreach(var item in nguoiThuePhong)
            {
                if(item.SCMND == _SCMND)
                {
                    nguoiThuePhong.Remove(item);
                }
            }
        }
        public string TienThuePhong()
        {
            int tongSoTien = 0;
                if(LoaiPhong == "A")
                {
                    tongSoTien = 500 * SoNgayThue;
                }
                else if(LoaiPhong == "B")
                {
                    tongSoTien = 300 * SoNgayThue;
                }
                else if(LoaiPhong == "C")
                {
                    tongSoTien = 100 * SoNgayThue;
                }
            return $"{tongSoTien}$";
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            KhachSan a = new KhachSan();
            a.ThemMoi(10, "A", new Nguoi("Nguyen A", 19, "ACRXS"));
            Console.WriteLine(a.TienThuePhong());
        }
    }
}

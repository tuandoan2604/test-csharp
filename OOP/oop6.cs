using System;
using System.Collections.Generic;

namespace OOP6
{
    class HocSinh
    {
        public string HoTen;
        public int Tuoi;
        public string QueQuan;
        public HocSinh(string _HoTen, int _Tuoi, string _QueQuan)
        {
            HoTen = _HoTen;
            Tuoi = _Tuoi;
            QueQuan = _QueQuan;
        }
    }
    class QLHS
    {
        public List<HocSinh> hocSinh;
        public QLHS()
        {
            hocSinh = new List<HocSinh>();
        }
        public void ThemHocSinh(HocSinh h)
        {
            hocSinh.Add(h);
        }
        public void HienThiThongTinHocSinh()
        {
            foreach(var item in hocSinh)
            {
                Console.WriteLine($"Ho ten: {item.HoTen} - Tuoi: {item.Tuoi} - Que quan: {item.QueQuan}");
            }
        }
        public void HienThiHocSinh20Tuoi()
        {
            foreach(var item in hocSinh)
            {
                if(item.Tuoi == 20)
                {
                    Console.WriteLine($"Ho ten: {item.HoTen} - Tuoi: {item.Tuoi} - Que quan: {item.QueQuan}");
                }
            }
        }
        public int HocSinhCoTuoi23QueDN()
        {
            int count = 0;
            foreach (var item in hocSinh)
            {
                if (item.Tuoi == 23 && item.QueQuan == "DN")
                {
                    count++;
                }
            }
            return count;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            QLHS qlhs = new QLHS();
            qlhs.ThemHocSinh(new HocSinh("Nguyen A", 20, "DN"));
            qlhs.ThemHocSinh(new HocSinh("Nguyen B", 23, "DN"));
            qlhs.HienThiThongTinHocSinh();
            qlhs.HienThiHocSinh20Tuoi();
            Console.WriteLine(qlhs.HocSinhCoTuoi23QueDN());
        }
    }
}

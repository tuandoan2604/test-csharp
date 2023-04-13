using System;
using System.Collections.Generic;

namespace OOP7
{
    class Nguoi
    {
        public string HoTen;
        public int Tuoi;
        public string QueQuan;
        public string MaSoNhanVien;
        public Nguoi(string _HoTen, int _Tuoi, string _QueQuan, string _MaSoNhanVien)
        {
            HoTen = _HoTen;
            Tuoi = _Tuoi;
            QueQuan = _QueQuan;
            MaSoNhanVien = _MaSoNhanVien;
        }
    }
    class GV
    {
        public int LuongCung;
        public int LuongThuong;
        public int TienPhat;
        public int LuongThucLinh;
        public Nguoi thongTinCaNhan;
        public GV(int _LuongCung, int _LuongThuong, int _TienPhat, Nguoi _thongTinCaNhan)
        {
            LuongCung = _LuongCung;
            LuongThuong = _LuongThuong;
            TienPhat = _TienPhat;
            thongTinCaNhan = _thongTinCaNhan;
        }
        public int LuongThucLinhGV()
        {
            return LuongCung + LuongThuong - TienPhat;
        }
    }
    class CBGV
    {
        public List<GV> GiaoVien;
        public CBGV()
        {
            GiaoVien = new List<GV>();
        }
        public void themCBGV(GV giaoVien)
        {
            GiaoVien.Add(giaoVien);
        }
        public void XoaCanBo(string _MaSoNhanVien)
        {
            foreach (var item in GiaoVien)
            {
                if (item.thongTinCaNhan.MaSoNhanVien == _MaSoNhanVien)
                {
                    GiaoVien.Remove(item);
                    break;
                }
                
            }
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            CBGV a = new CBGV();
            a.themCBGV(new GV(1000, 200, 300, new Nguoi("Nguyen A", 19, "Ha noi", "123zxcA")));
            a.themCBGV(new GV(1200, 500, 400, new Nguoi("Nguyen B", 20, "Hai Phong", "124zxcA")));
            a.XoaCanBo("124zxcA");
            foreach(var item in a.GiaoVien)
            {
                Console.WriteLine(item.LuongThucLinhGV());
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Threading.Tasks.Sources;

namespace OOP8
{
    class SinhVien
    {
        public string HoTen;
        public int Tuoi;
        public string Lop;
        public SinhVien(string _HoTen, int _Tuoi, string _Lop)
        {
            HoTen = _HoTen;
            Tuoi = _Tuoi;
            Lop = _Lop;
        }
    }
    class TheMuon
    {
        public string MaPhieuMuon;
        public string NgayMuon;
        public string HanTra;
        public string SoHieuSach;
        public SinhVien thongTinSinhVien;
        public TheMuon(string _MaPhieuMuon, string _NgayMuon, string _HanTra, string _SoHieuSach, SinhVien _thongTinSinhVien)
        {
            MaPhieuMuon= _MaPhieuMuon;
            NgayMuon= _NgayMuon;
            HanTra= _HanTra;
            SoHieuSach= _SoHieuSach;
            thongTinSinhVien = _thongTinSinhVien;
        }
    }
    class QuanLyTheMuon
    {
        public List<TheMuon> the;
        public QuanLyTheMuon()
        {
            the = new List<TheMuon>();
        }
        public void Them(TheMuon a)
        {
            the.Add(a);
        }
        public void Xoa(string maTheMuon)
        {
            foreach(var item in the)
            {
                if(item.MaPhieuMuon == maTheMuon)
                {
                    the.Remove(item);
                    break;
                }
            }
        }
        public void HienThiThongTin()
        {
            foreach(var item in the)
            {
                Console.WriteLine($"Ma phieu muon: {item.MaPhieuMuon} - Ngay muon: {item.NgayMuon}" +
                    $"- Han tra: {item.HanTra} - So hieu sach: {item.SoHieuSach}" +
                    $"Ho ten: {item.thongTinSinhVien.HoTen} - Tuoi: {item.thongTinSinhVien.Tuoi} - Lop: {item.thongTinSinhVien.Lop}");
            }
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            QuanLyTheMuon a = new QuanLyTheMuon();
            a.Them(new TheMuon("z456x", "25/12/2022", "25/12/2023", "fzcdd", new SinhVien("Nguyen A", 19, "a")));
            a.Them(new TheMuon("z456y", "24/12/2022", "24/12/2023", "fzcddz", new SinhVien("Nguyen B", 23, "b")));
            a.HienThiThongTin();
            a.Xoa("z456x");
            a.HienThiThongTin();
        }
    }
}

using System;
using System.Collections.Generic;

namespace OOP12
{
    class PhuongTien
    {
        public int ID;
        public string HangSanXuat;
        public int NamSanXuat;
        public int GiaBan;
        public string MauXe;
        public PhuongTien(int _ID, string _HangSanXuat, int _NamSanXuat, int _GiaBan, string _MauXe)
        {
            ID = _ID;
            HangSanXuat= _HangSanXuat;
            NamSanXuat=_NamSanXuat;
            GiaBan= _GiaBan;
            MauXe= _MauXe;
        }
    }
    class Oto: PhuongTien
    {
        public int soChoNgoi;
        public string kieuDongCo;
        public Oto(int _soChoNgoi, string _kieuDongCo, int _ID, string _HangSanXuat, int _NamSanXuat, int _GiaBan, string _MauXe): base(_ID, _HangSanXuat, _NamSanXuat, _GiaBan, _MauXe)
        {
            soChoNgoi= _soChoNgoi;
            kieuDongCo= _kieuDongCo;
        }
    }
    class XeMay: PhuongTien {
        public int congSuat;
        public XeMay(int _congSuat, int _ID, string _HangSanXuat, int _NamSanXuat, int _GiaBan, string _MauXe) : base(_ID, _HangSanXuat, _NamSanXuat, _GiaBan, _MauXe)
        {
            congSuat = _congSuat;
        }
    }
    class XeTai: PhuongTien {
        public int trongTai;
        public XeTai(int _trongTai, int _ID, string _HangSanXuat, int _NamSanXuat, int _GiaBan, string _MauXe) : base(_ID, _HangSanXuat, _NamSanXuat, _GiaBan, _MauXe)
        {
            trongTai = _trongTai;
        }
    }
    class QLPTGT
    {
        public List<PhuongTien> vehicles;
        public QLPTGT()
        {
            vehicles = new List<PhuongTien>();
        }
        public void ThemPhuongTien(PhuongTien vehicel)
        {
            vehicles.Add(vehicel);
        }
        public void XoaTheoID(int id)
        {
            for(int i = 0; i < vehicles.Count; i++) {
                if (vehicles[i].ID == id)
                {
                    vehicles.Remove(vehicles[i]);
                }
            }
        }
        public void XoaTheoHang(string hangxe)
        {
            for (int i = 0; i < vehicles.Count; i++)
            {
                if (vehicles[i].HangSanXuat == hangxe)
                {
                    vehicles.Remove(vehicles[i]);
                }
            }
        }
        public void XoaTheoMau(string mauxe)
        {
            for (int i = 0; i < vehicles.Count; i++)
            {
                if (vehicles[i].MauXe == mauxe)
                {
                    vehicles.Remove(vehicles[i]);
                }
            }
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            QLPTGT a = new QLPTGT();
            a.ThemPhuongTien(new Oto(2, "may", 1, "sdf", 9999, 34555, "xanh"));
            a.ThemPhuongTien(new XeMay(99, 2, "sdfds", 8888, 345345, "đỏ"));
            a.ThemPhuongTien(new XeTai(99, 3, "fdsf", 3423, 435435,"vàng"));
            a.XoaTheoMau("xanh");
        }
    }
}

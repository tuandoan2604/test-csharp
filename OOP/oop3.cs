using System;
using System.Collections.Generic;

namespace OOP3
{
    class ThiSinh
    {
        public string HoTen { get; set; }
        public string DiaChi { get; set; }
        public string MucUuTien { get; set; }
        public string SoBaoDanh { get; set; }
        public ThiSinh(string _HoTen, string _DiaChi, string _MucUutien, string _SoBaoDanh)
        {
            HoTen = _HoTen;
            DiaChi = _DiaChi;
            MucUuTien = _MucUutien;
            SoBaoDanh = _SoBaoDanh;
        }
    }
    class ThiSinhKhoiA: ThiSinh
    {
        public string KhoiThi { get; set; }
        public ThiSinhKhoiA(string _KhoiThi, string _HoTen, string _DiaChi, string _MucUutien, string _SoBaoDanh):base(_HoTen,  _DiaChi, _MucUutien, _SoBaoDanh)
        {
            KhoiThi = _KhoiThi;
        }
    }
    class ThiSinhKhoiB: ThiSinh
    {
        public string KhoiThi { get; set; }
        public ThiSinhKhoiB(string _KhoiThi, string _HoTen, string _DiaChi, string _MucUutien, string _SoBaoDanh) : base(_HoTen, _DiaChi, _MucUutien, _SoBaoDanh)
        {
            KhoiThi = _KhoiThi;
        }
    }
    class ThiSinhKhoiC : ThiSinh
    {
        public string KhoiThi { get; set; }
        public ThiSinhKhoiC(string _KhoiThi, string _HoTen, string _DiaChi, string _MucUutien, string _SoBaoDanh) : base(_HoTen, _DiaChi, _MucUutien, _SoBaoDanh)
        {
            KhoiThi = _KhoiThi;
        }
    }
    class TuyenSinh
    {
        public List<ThiSinh> thiSinh;
        public TuyenSinh()
        {
            thiSinh = new List<ThiSinh>();   
        }
        public void ThemMoiThiSinh(ThiSinh a)
        {
            thiSinh.Add(a);
        }
        public void HienThiThongTinThiSinh()
        {
            foreach(var item in thiSinh)
            {
                if(item is ThiSinhKhoiA)
                {
                    Console.WriteLine($"Khoi thi: {((ThiSinhKhoiA)item).KhoiThi}- So bao danh: {item.SoBaoDanh} - Ho ten: {item.HoTen} - Dia chi: {item.DiaChi} - Muc uu tien: {item.MucUuTien}");
                }
                else if(item is ThiSinhKhoiB)
                {
                    Console.WriteLine($"Khoi thi: {((ThiSinhKhoiB)item).KhoiThi} - So bao danh: {item.SoBaoDanh} - Ho ten: {item.HoTen} - Dia chi: {item.DiaChi} - Muc uu tien: {item.MucUuTien}");
                }
                else if (item is ThiSinhKhoiC)
                {
                    Console.WriteLine($"Khoi thi: {((ThiSinhKhoiC)item).KhoiThi} - So bao danh: {item.SoBaoDanh} - Ho ten: {item.HoTen} - Dia chi: {item.DiaChi} - Muc uu tien: {item.MucUuTien}");
                }
            }
        }
        public ThiSinh TimKiemTheoSoBaoDanh(string _sobaodanh)
        {
            foreach(var item in thiSinh)
            {
                if(item.SoBaoDanh == _sobaodanh)
                {
                    if (item is ThiSinhKhoiA)
                    {
                        Console.WriteLine($"Khoi thi: {((ThiSinhKhoiA)item).KhoiThi}- So bao danh: {item.SoBaoDanh} - Ho ten: {item.HoTen} - Dia chi: {item.DiaChi} - Muc uu tien: {item.MucUuTien}");
                    }
                    else if (item is ThiSinhKhoiB)
                    {
                        Console.WriteLine($"Khoi thi: {((ThiSinhKhoiB)item).KhoiThi} - So bao danh: {item.SoBaoDanh} - Ho ten: {item.HoTen} - Dia chi: {item.DiaChi} - Muc uu tien: {item.MucUuTien}");
                    }
                    else if (item is ThiSinhKhoiC)
                    {
                        Console.WriteLine($"Khoi thi: {((ThiSinhKhoiC)item).KhoiThi} - So bao danh: {item.SoBaoDanh} - Ho ten: {item.HoTen} - Dia chi: {item.DiaChi} - Muc uu tien: {item.MucUuTien}");
                    }
                    return item;
                }
            }
            return null;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            TuyenSinh a = new TuyenSinh();
            a.ThemMoiThiSinh(new ThiSinhKhoiA("A", "nguyen a", "Ha Noi", "2", "dsfdsf"));
            a.ThemMoiThiSinh(new ThiSinhKhoiB("B", "nguyen c", "ha nam", "2", "dsfdsfxvc"));
            a.ThemMoiThiSinh(new ThiSinhKhoiC("C", "nguyen d", "phu ly", "2", "fdxcvcxvdf"));
            a.HienThiThongTinThiSinh();
            a.TimKiemTheoSoBaoDanh("dsfdsf");
        }
    }
}

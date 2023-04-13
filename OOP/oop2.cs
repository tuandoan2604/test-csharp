using System;
using System.Collections.Generic;

namespace OOP2
{
    class TaiLieu
    {
        public string MaTaiLieu { get; set; }
        public string TenNhaSanXuat { get; set; }
        public int SoBanPhatHanh { get; set; }
        public TaiLieu(string _MaTaiLieu, string _TenNhaSanXuat, int _SoBanPhatHanh) {
            MaTaiLieu= _MaTaiLieu;
            TenNhaSanXuat = _TenNhaSanXuat;
            SoBanPhatHanh= _SoBanPhatHanh;
        }
    }
    class Sach: TaiLieu
    {
        public string TenTacGia { get; set; }
        public int SoTrang { get; set; }
        public Sach(string _MaTaiLieu, string _TenNhaSanXuat, int _SoBanPhatHanh, 
        string _TenTacGia, int _SoTrang) : base(_MaTaiLieu, _TenNhaSanXuat, _SoBanPhatHanh)
        {
            TenTacGia = _TenTacGia;
            SoTrang = _SoTrang;
        }

    }
    class TapChi: TaiLieu
    {
        public int SoPhatHanh { get; set; }
        public int ThangPhatHanh { get; set; }
        public TapChi(string _MaTaiLieu, string _TenNhaSanXuat, int _SoBanPhatHanh,
        int _SoPhatHanh, int _ThangPhatHanh) : base(_MaTaiLieu, _TenNhaSanXuat, _SoBanPhatHanh)
        {
            SoPhatHanh = _SoPhatHanh;
            ThangPhatHanh = _ThangPhatHanh;
        }
    }
    class Bao: TaiLieu
    {
        public int NgayPhatHanh { get; set; }
        public Bao(string _MaTaiLieu, string _TenNhaSanXuat, int _SoBanPhatHanh,
        int _NgayPhatHanh) : base(_MaTaiLieu, _TenNhaSanXuat, _SoBanPhatHanh)
        {
            NgayPhatHanh = _NgayPhatHanh;
        }
    }
    class QuanLySach
    {
        public List<TaiLieu> documents { get; set; }
        public QuanLySach()
        {
            documents = new List<TaiLieu>();
        }
        public void ThemTaiLieu(TaiLieu _document)
        {
            documents.Add(_document);
        }
        
        public void XoaTaiLieuTheoMaTaiLieu(string _maTaiLieu)
        {
            foreach(var item in documents)
            {
                if(item.MaTaiLieu == _maTaiLieu)
                {
                    documents.Remove(item);
                }
            }
        }
        public void HienThiThongTinVeTaiLieu()
        {
            foreach (var item in documents)
            {
                if(item is Sach)
                {
                    Console.WriteLine($"Tên tác giả: {((Sach)item).TenTacGia} - So trang: {((Sach)item).SoTrang} - Ma tai lieu: {((Sach)item).MaTaiLieu}" +
                        $"Ten nha san xuat: {((Sach)item).TenNhaSanXuat} - So ban phat hanh: {((Sach)item).SoBanPhatHanh}");
                }
                if(item is TapChi)
                {
                    Console.WriteLine($"So phat hanh: {((TapChi)item).SoPhatHanh} - Thang phat hanh: {((TapChi)item).ThangPhatHanh} - Ma tai lieu: {((TapChi)item).MaTaiLieu}" +
                        $"Ten nha san xuat: {((TapChi)item).TenNhaSanXuat} - So ban phat hanh: {((TapChi)item).SoBanPhatHanh}");
                }
                if(item is Bao)
                {
                    Console.WriteLine($"Ngay phat hanh: {((Bao)item).NgayPhatHanh} - Ma tai lieu: {((Bao)item).MaTaiLieu}" +
                        $"Ten nha san xuat: {((Bao)item).TenNhaSanXuat} - So ban phat hanh: {((Bao)item).SoBanPhatHanh}");
                }
            }
            
        }
        public List<Sach> TimKiemSach()
        {
            List<Sach> book = new List<Sach>();
            foreach(var item in documents)
            {
                if(item is Sach)
                {
                    book.Add((Sach)item);
                }
            }
            return book;
        }
        public List<TapChi> TimKiemTapChi()
        {
            List<TapChi> data = new List<TapChi>();
            foreach (var item in documents)
            {
                if (item is TapChi)
                {
                    data.Add((TapChi)item);
                }
            }
            return data;
        }
        public List<Bao> TimKiemBao()
        {
            List<Bao> data = new List<Bao>();
            foreach (var item in documents)
            {
                if (item is Bao)
                {
                    data.Add((Bao)item);
                }
            }
            return data;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}

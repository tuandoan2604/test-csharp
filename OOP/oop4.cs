using System;
using System.Collections.Generic;

namespace OOP4
{
    class Nguoi {
        public Nguoi(string _HoTen, int _Tuoi, string _NgheNghiep, string _SCMND)
        {
            HoTen = _HoTen;
            Tuoi = _Tuoi;
            NgheNghiep= _NgheNghiep;
            SCMND = _SCMND;
        }
      
        public string HoTen { get; set; }
        public int Tuoi { get; set; }
        public string NgheNghiep { get; set; }
        public string SCMND { get; set; }
    }
    class HoGiaDinh {
        public HoGiaDinh(int _soThanhVien, int _soNha, List<Nguoi> _thongTinMoiCaNhan)
        {
            thongTinMoiCaNhan = _thongTinMoiCaNhan;
            soThanhVien = _soThanhVien;
            soNha = _soNha;
        }
        public int soThanhVien { get; set; }
        public int soNha { get; set; }
        public List<Nguoi> thongTinMoiCaNhan { get; set; }
    }
    class KhuPho
    {
        public List<HoGiaDinh> hoGiaDinh { get; set;}
        public KhuPho()
        {
            hoGiaDinh = new List<HoGiaDinh>();
        }
        public void ThemHoGiaDinh(HoGiaDinh _hoGiaDinh)
        {
            hoGiaDinh.Add(_hoGiaDinh);
            Console.WriteLine();
        }
        public void HienThiThongTin()
        {
            foreach(var item in hoGiaDinh)
            {
                foreach(var value in item.thongTinMoiCaNhan)
                {
                    Console.WriteLine($"So thanh vien: {item.soThanhVien} - So nha: {item.soNha} - " +
                        $"Ho ten: {value.HoTen} - Tuoi: {value.Tuoi} - Nghe nghiep: {value.NgheNghiep} - CMND: {value.SCMND}");
                }
            }
        }
    }
    internal class Program
    {
        
        static void Main(string[] args)
        {
            int soThanhVien, soNha;
            string HoTen, NgheNghiep, SCMND;
            int Tuoi;
            List<Nguoi> thongTinMoiThanhVienTrongGiaDinh = new List<Nguoi>();
            Console.WriteLine("Nhap so ho dan:");
            int n = Int32.Parse(Console.ReadLine());
            KhuPho a = new KhuPho();
            for(int i = 0; i < n; i++)
            {
                Console.WriteLine($"Nhap thong tin ho dan thu {i + 1}");
                Console.WriteLine("Nhap so thanh vien trong gia dinh:");
                soThanhVien = Int32.Parse(Console.ReadLine());
                Console.WriteLine("Nhap so nha:");
                soNha = Int32.Parse(Console.ReadLine());
                for(int j = 0; j < soThanhVien; j++)
                {
                    Console.WriteLine($"Nhap ho ten thanh vien thu {j + 1}:");
                    HoTen = Console.ReadLine();
                    Console.WriteLine($"Nhap nghe nghiep thanh vien thu {j + 1}:");
                    NgheNghiep = Console.ReadLine();
                    Console.WriteLine($"Nhap so chung minh nhan dan thanh vien thu {j + 1}:");
                    SCMND = Console.ReadLine();
                    Console.WriteLine($"Nhap tuoi thanh vien thu {j + 1}: ");
                    Tuoi = Int32.Parse(Console.ReadLine());
                    thongTinMoiThanhVienTrongGiaDinh.Add(new Nguoi(HoTen, Tuoi, NgheNghiep, SCMND));
                    
                }
                a.ThemHoGiaDinh(new HoGiaDinh(soThanhVien, soNha, thongTinMoiThanhVienTrongGiaDinh));
                if(i < n - 1)
                    thongTinMoiThanhVienTrongGiaDinh.RemoveRange(0, thongTinMoiThanhVienTrongGiaDinh.Count);
            }

            a.HienThiThongTin();
        }
    }
}

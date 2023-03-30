using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NguoiNS
{
    internal class Nguoi
    {
        public string hoTen { set; get; }
        public int tuoi { set; get; }
        public string ngheNghiep { set; get; }
        public int CCCD { set; get; }
        public Nguoi(string _hoten, int _tuoi, string _nghenghiep, int _CCCD) 
        {
            this.hoTen = _hoten;
            this.tuoi = _tuoi;
            this.ngheNghiep = _nghenghiep;
            this.CCCD = _CCCD;
        }
    }
    class HoGiaDinh
    {
        public List<Nguoi> gd { set; get; }
        public HoGiaDinh() 
        {
            gd = new List<Nguoi>()
            {
                /*new Nguoi("anh", 32, "a", 0909),
                new Nguoi("tuan", 12, "b", 0919),
                new Nguoi("pham", 13, "c", 1909),*/
            };
        }
        public void ThemNguoi()
        {
            char oke = 'y';
            do
            {
                string hoten = NhapLieu("họ tên");
                int tuoi = int.Parse(NhapLieu("tuổi"));
                string nghe = NhapLieu("nghề nghiệp");
                int cccd = int.Parse(NhapLieu("CCCD"));
                Nguoi n = new Nguoi(hoten, tuoi, nghe, cccd);
                gd.Add(n);

                oke = char.Parse(NhapLieu("tiếp tục hộ gia đình này ? (y/n)"));  
            } while (oke == 'y');
        }
        public void ThongTinGD()
        {
            Console.WriteLine("Thông tin về hộ gia đình:");
            foreach (Nguoi n in gd) 
            {
                Console.WriteLine($"{n.hoTen} | {n.tuoi} | {n.ngheNghiep} | {n.CCCD}");
            }
        }
        public string NhapLieu(string mes)
        {
            Console.Write($"Nhập {mes}:");
            return Console.ReadLine();
        }
    }
    class KhuPho
    {
        public List<HoGiaDinh> kp { set; get; }
        public KhuPho() 
        {
            kp = new List<HoGiaDinh>();
        }
        public void ThemGD()
        {
            int n = int.Parse(NhapLieu("số lượng hộ gia đình"));
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("Nhập thông tin hộ gia đình thứ {0}", i + 1);
                HoGiaDinh gd = new HoGiaDinh();
                gd.ThemNguoi();
                kp.Add(gd);

            }    
        }
        public void ThongTinKP()
        {
            Console.WriteLine("Thông tin về khu phố: ");
            foreach(HoGiaDinh gd in kp)
            {
                gd.ThongTinGD();   
            }    
        }
        public string NhapLieu(string mes)
        {
            Console.Write($"Nhập {mes}:");
            return Console.ReadLine();
        }
    }
}

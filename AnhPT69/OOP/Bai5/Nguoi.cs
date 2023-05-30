using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KhachSanNS
{
    public class Nguoi
    {
        public string hoTen { set; get; }
        public int tuoi { set; get; }
        public int CCCD { set; get; }
        public Nguoi() { }
        public Nguoi(string _hoten, int _tuoi, int _CCCD) 
        {
            this.hoTen = _hoten;
            this.tuoi = _tuoi;
            this.CCCD = _CCCD;
        }
    }
    class Phong : Nguoi
    {
        public string loaiPhong { set; get; }
        public DateTime ngayDat { set; get; }
        public Phong() { }
        public Phong(string _hoten, int _tuoi, int _CCCD, string _loaiphong, DateTime _ngaydat)
        {
            this.hoTen = _hoten;
            this.tuoi = _tuoi;
            this.CCCD = _CCCD;
            this.loaiPhong = _loaiphong;
            this.ngayDat = _ngaydat;
        }

    }
    class KhachSan
    {
        public List<Phong> ks { set; get; }
        public KhachSan()
        {
            ks = new List<Phong>()
            {
            };
        }
        public void ThemKhach()
        {
                string hoten = NhapLieu("họ tên");
                int tuoi = int.Parse(NhapLieu("tuổi"));
                int cccd = int.Parse(NhapLieu("CCCD"));
                string loaiphong = NhapLieu("loại phòng");
                DateTime ngayDat = DateTime.Now;
                Phong p = new Phong(hoten, tuoi, cccd, loaiphong, ngayDat);
                ks.Add(p);

        }
        public Phong XoaTheoCCCD(int cccd)
        {
            int n = ks.Count;
            bool check = false;
            Phong temp = new Phong();
            for(int i = 0; i < n; i++) 
            {
                if (ks[i].CCCD == cccd)
                {
                    temp = ks[i];
                    ks.RemoveAt(i);
                    check = true;
                    break;
                    
                }    
            }

            if (check) 
            {
                Console.WriteLine("Đã xóa khách có cccd {0}", cccd);
            }
            else
            {
                Console.WriteLine("Không có khách mang cccd {0}", cccd);
            }
            
            return temp;
        }
        public float TinhTien(int cccd) 
        {
            float tien = 0;
            Phong p = XoaTheoCCCD(cccd);

            TimeSpan ts = DateTime.Now - p.ngayDat;
            
            switch (p.loaiPhong)
            {
                case "A":
                    {
                        tien = ts.Days * 500;
                    }
                    break;
                case "B":
                    {
                        tien = ts.Days * 300;
                    }
                    break;
                case "C":
                    {
                        tien = ts.Days * 100;
                    }
                    break;
            }

            Console.WriteLine($"Số tiền khách có cccd {p.CCCD} phải trả là: {tien}");

            return tien;
        }
        public string NhapLieu(string mes)
        {
            Console.Write($"Nhập {mes}:");
            return Console.ReadLine();
        }
    }


}

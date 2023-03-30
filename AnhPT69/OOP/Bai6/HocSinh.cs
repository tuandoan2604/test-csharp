using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace HocSinhNS
{
    internal class HocSinh
    {
        public string hoTen { set; get; }
        public int tuoi { set; get; }
        public string queQuan { set; get; }
        public HocSinh() 
        {
            this.hoTen = string.Empty;
            this.tuoi = 0;
            this.queQuan = string.Empty;
        }
        public HocSinh(string _hoten, int _tuoi, string _quequan) 
        {
            this.hoTen = _hoten;
            this.tuoi = _tuoi;
            this.queQuan = _quequan;
        }
    }
    class Lop
    {
        public string tenLop { set; get; }
        public List<HocSinh> ds;
        public Lop(string tenlop) 
        {
            this.tenLop = tenlop;
            ds = new List<HocSinh>();
        }
        public void ThemHS()
        {
            char oke = 'y';
            do
            {
                string hoten = NhapLieu("họ tên");
                int tuoi = int.Parse(NhapLieu("tuổi"));
                string que = NhapLieu("quê quán");
                HocSinh hs = new HocSinh(hoten, tuoi, que);
                ds.Add(hs);

                oke = char.Parse(NhapLieu("tiếp tục nhập lớp này ? (y/n)"));
            } while (oke == 'y');
        }
        public void ThongTinHS()
        {
            Console.WriteLine($"Lớp {tenLop}");
            foreach (HocSinh hs in ds)
            {
                Console.WriteLine($"{hs.hoTen} | {hs.tuoi} | {hs.queQuan}");
            }
        }
        public string NhapLieu(string mes)
        {
            Console.Write($"Nhập {mes}:");
            return Console.ReadLine();
        }
    }
    class Truong
    {
        public List<Lop> truong;
        public Truong()
        {
            truong = new List<Lop>();
        }
        public void ThemLop() 
        {
            char oke = 'y';
            do
            {
                string tenlop = NhapLieu("tên lớp");
                Lop lop = new Lop(tenlop);
                lop.ThemHS();
                truong.Add(lop);

                oke = char.Parse(NhapLieu("tiếp tục lớp tiếp theo ? (y/n)"));

            } while (oke == 'y');
        }
        public void ThemHSVaoLop(string tenlop) 
        {
            int n = truong.Count;
            for (int i = 0; i < n; i++) 
            {
                if (truong[i].tenLop == tenlop)
                {
                    truong[i].ThemHS();
                    break;
                }    
            }
        }
        public void TimKiemHS(int tuoi)
        {
            List<Lop> kq = new List<Lop>();

            foreach (Lop lop in truong)
            {
                Lop temp = new Lop(lop.tenLop);
                foreach (HocSinh hs in lop.ds)
                {
                    if (hs.tuoi == tuoi)
                    {
                        temp.ds.Add(hs); 
                    }    
                }

                if(temp.ds.Count != 0)
                {
                    kq.Add(temp);
                }    
            }
            
            if (kq.Count != 0) 
            {
                Console.WriteLine($"Danh sách học sinh có tuổi {tuoi}:");
                foreach (Lop i in kq)
                {
                    i.ThongTinHS();    
                }
            }
            else
            {
                Console.WriteLine($"Không có học sinh có tuổi {tuoi}");
            }
            
        }

        public void TimKiemSoLuong(int tuoi, string que)
        {
            int nHS = 0;

            foreach (Lop lop in truong)
            {
                foreach (HocSinh hs in lop.ds)
                {
                    if (hs.tuoi == tuoi && hs.queQuan == que)
                    {
                        nHS++;
                    }
                }
            }

            if (nHS != 0)
            {
                Console.WriteLine($"Số lượng học sinh tuổi {tuoi} và quê ở {que} là: {nHS}");
            }
            else
            {
                Console.WriteLine($"Không tìm thấy học sinh nào");
            }

        }
        public string NhapLieu(string mes)
        {
            Console.Write($"Nhập {mes}:");
            return Console.ReadLine();
        }
    }
}

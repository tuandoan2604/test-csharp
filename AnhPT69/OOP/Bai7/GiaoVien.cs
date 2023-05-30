using KhachSanNS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiaoVienNS
{
    internal class Nguoi
    {
        public string hoTen { set; get; }
        public int tuoi { set; get; }
        public string queQuan { set; get; }
        public string maGV { set; get; }
        public float lCung { set; get; }
        public float lThuong { set; get; }
        public float lPhat { set; get; }
        public Nguoi()
        {
            this.hoTen = string.Empty;
            this.tuoi = 0;
            this.queQuan = string.Empty;
            this.maGV = string.Empty;
        }
        public Nguoi(string _hoten, int _tuoi, string _quequan, string _magv)
        {
            this.hoTen = _hoten;
            this.tuoi = _tuoi;
            this.queQuan = _quequan;
            this.maGV = _magv;
        }
        public void GhiLuong(float _lcung, float _lthuong, float _lphat)
        {
            this.lCung = _lcung;
            this.lThuong = _lthuong;
            this.lPhat = _lphat;
        }
    }
    class CBGV
    {
        public List<Nguoi> ds = new List<Nguoi>();

        public void ThemCBGV()
        {
            string hoten = NhapLieu("họ tên");
            int tuoi = int.Parse(NhapLieu("tuổi"));
            string que = NhapLieu("quê quán");
            string magv = NhapLieu("mã giáo viên");
            Nguoi n = new Nguoi(hoten, tuoi, que, magv);
            ds.Add(n);
        }
        public void XoaCBGV(string magv)
        {
            (int i, bool check) = TimKiem(magv);
            if (check)
            {
                ds.RemoveAt(i);
                Console.WriteLine("Đã xóa giáo viên có mã {0}", magv);                
            }      
            else
                Console.WriteLine("Không có mã giáo viên {0}", magv);              
        }
        public void NhapLuong(string magv)
        {
            (int i, bool check) = TimKiem(magv);
            if (check)
            {
                float lcung = float.Parse(NhapLieu("lương cứng"));
                float lthuong = float.Parse(NhapLieu("lương thưởng"));
                float lphat = float.Parse(NhapLieu("tiền phạt"));
                ds[i].GhiLuong(lcung, lthuong, lphat);
            }
            else
            {
                Console.WriteLine("Không có mã giáo viên {0}", magv);
            }    
            
        }
        public void TinhLuong(string magv)
        {
            (int i, bool check) = TimKiem(magv);
            if (check)
            {
                float luong = ds[i].lCung + ds[i].lThuong - ds[i].lPhat;
                Console.WriteLine("Lương của giáo viên {0} là: {1}", magv, luong);
            }
            else
            {
                Console.WriteLine("Không có mã giáo viên {0}", magv);
            }
        }
        public Tuple<int,bool> TimKiem(string magv) 
        {
            int i = 0;
            bool check = false;
            for(i = 0; i < ds.Count; i++)
            {
                if (ds[i].maGV == magv)
                {
                    check = true;
                    break;
                }
            }
            return Tuple.Create(i, check);
        }
        public string NhapLieu(string mes)
        {
            Console.Write($"Nhập {mes}:");
            return Console.ReadLine();
        }

    }
}

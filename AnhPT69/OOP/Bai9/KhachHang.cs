using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace TienDienNS
{
    internal class KhachHang
    {
        private string hoTen;
        private string soNha;
        public string maCongTo { set; get; }
        private int chiSoCu;
        private int chiSoMoi;
        public KhachHang() { }
        public void SuaTT(string _hoten, string _sonha, string _macongto)
        {
            hoTen = _hoten;
            soNha = _sonha;
            maCongTo = _macongto;
        }
        public void NhapChiSo(int _chisocu, int _chisomoi)
        {
            chiSoCu = _chisocu;
            chiSoMoi = _chisomoi;            
        }
        public double TienDien()
        {
            double soTien = (chiSoMoi - chiSoCu) * 5;
            return soTien;
        }

    }
    class BienLai 
    {
        List<KhachHang> ds;
        public BienLai() 
        {
            ds = new List<KhachHang>();
        }
        public void ThemKH()
        {
            string hoten = NhapLieu("họ tên");
            string sonha = NhapLieu("số nhà");
            string mact = NhapLieu("mã công tơ");

            KhachHang kh = new KhachHang();

            kh.SuaTT(hoten, sonha, mact);

            ds.Add(kh);
        }
        public void SuaKH(string mact)
        {
            (int i, bool check) = TimKiem(mact);
            if (check)
            {
                string hoten = NhapLieu("họ tên");
                string sonha = NhapLieu("số nhà");

                char c = char.Parse(NhapLieu("mã công tơ mới ? (y/n)"));
                if (c == 'y')
                {
                    string _mact = NhapLieu("mã công tơ mới");
                    ds[i].SuaTT(hoten, sonha, _mact);
                }
                else
                {
                    ds[i].SuaTT(hoten, sonha, mact);
                }     
            }
            else
                Console.WriteLine("Không có mã công tơ {0}", mact);
        }
        public void XoaKH(string mact)
        {
            (int i, bool check) = TimKiem(mact);
            if (check)
            {
                ds.RemoveAt(i);
                Console.WriteLine("Đã xóa khách hàng có mã công tơ {0}", mact);
            }
            else
                Console.WriteLine("Không có mã công tơ {0}", mact);
        }
        public void NhapChiSo(string mact)
        {
            (int i, bool check) = TimKiem(mact);
            if (check)
            {
                int cu = int.Parse(NhapLieu("chỉ số cũ"));
                int moi = int.Parse(NhapLieu("chỉ số mới"));

                ds[i].NhapChiSo(cu, moi);

            }
            else
                Console.WriteLine("Không có mã công tơ {0}", mact);
        }
        public void TienDien(string mact)
        {
            (int i, bool check) = TimKiem(mact);
            if (check)
            {
                Console.WriteLine("Tiền điện của khách hàng có mã công tơ {0}: {1}", mact, ds[i].TienDien());
            }
            else
                Console.WriteLine("Không có mã công tơ {0}", mact);
        }
        public Tuple<int, bool> TimKiem(string mact)
        {
            int i = 0;
            bool check = false;
            for (i = 0; i < ds.Count; i++)
            {
                if (ds[i].maCongTo == mact)
                {
                    check = true;
                    break;
                }
            }
            return Tuple.Create(i, check);
        }
        string NhapLieu(string mes)
        {
            Console.Write("Nhập {0}:", mes);
            return Console.ReadLine();
        }
    }
}

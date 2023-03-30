using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThuVienNS
{
    internal class SinhVien
    {
        public string hoTen { set; get; }
        public int tuoi { set; get; }
        public string lop { set; get; }
        public SinhVien(string _hoten, int _tuoi, string _lop)
        {
            this.hoTen = _hoten;
            this.tuoi = _tuoi;
            this.lop = _lop;
        }
    }
    class TheMuon
    {
        public string maPhieuMuon { set; get; }
        public int ngayMuon { set; get; }
        public int hanTra { set; get; }
        public string soHieuSach { set; get; }
        public SinhVien sv;
        public TheMuon() { }
        public TheMuon(string _maphieumuon, int _ngaymuon, int _hantra, string _sohieusach, SinhVien _sv) 
        { 
            this.maPhieuMuon = _maphieumuon;
            this.ngayMuon = _ngaymuon;
            this.hanTra = _hantra;
            this.soHieuSach = _sohieusach;
            this.sv = _sv;
        }
        public TheMuon ThemThe()
        {
            string ma = NhapLieu("mã phiếu mượn");
            int ngay = int.Parse(NhapLieu("ngày mượn"));
            int han = int.Parse(NhapLieu("hạn trả"));
            string so = NhapLieu("số hiệu sách");

            Console.WriteLine("Thông tin sinh viên mượn sách: ");
            string hoten = NhapLieu("họ tên");
            int tuoi = int.Parse(NhapLieu("tuổi"));
            string lop = NhapLieu("lớp");

            sv = new SinhVien(hoten, tuoi, lop);

            TheMuon tm = new TheMuon(ma, ngay, han, so, sv);
            return tm;
        }
        public void ThongTinThe()
        {
            HienThi("Mã phiếu mượn", maPhieuMuon);
            HienThi("Ngày mượn", ngayMuon.ToString());
            HienThi("Hạn trả", hanTra.ToString());
            HienThi("Số hiệu sách", soHieuSach);
            HienThi("Họ tên sinh viên", sv.hoTen);
            HienThi("Tuổi", sv.tuoi.ToString());
            HienThi("Lớp", sv.lop);
        }
        public void HienThi(string title, string info)
        {
            Console.WriteLine("{0}: {1}", title, info);
        }
        public string NhapLieu(string mes)
        {
            Console.Write($"Nhập {mes}:");
            return Console.ReadLine();
        }
    }
    class QLTV
    {
        List<TheMuon> tv;
        public QLTV()
        {
            tv = new List<TheMuon>();
        }
        public void ThemTheTV()
        {
            TheMuon tm = new TheMuon();
            tm = tm.ThemThe();

            tv.Add(tm);
        }
        public void XoaThe(string matm)
        {
            (int i, bool check) = TimKiem(matm);
            if (check)
            {
                tv.RemoveAt(i);
                Console.WriteLine("Đã xóa thẻ có mã {0}", matm);
            }
            else
                Console.WriteLine("Không có mã thẻ {0}", matm);
        }
        public void ThongTinTheMuon(string matm)
        {
            (int i, bool check) = TimKiem(matm);
            if (check)
            {
                tv[i].ThongTinThe();
            }
            else
                Console.WriteLine("Không có mã thẻ {0}", matm);
        }
        public Tuple<int, bool> TimKiem(string matm)
        {
            int i = 0;
            bool check = false;
            for (i = 0; i < tv.Count; i++)
            {
                if (tv[i].maPhieuMuon == matm)
                {
                    check = true;
                    break;
                }
            }
            return Tuple.Create(i, check);
        }

    }
}

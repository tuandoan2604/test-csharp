using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaiLieuNS
{
    class TaiLieu
    {
        public string maTaiLieu { set; get; }
        public string nhaXuatBan { set; get; }
        public int soBan { set; get; }

        public TaiLieu() 
        {
            this.maTaiLieu = string.Empty;
            this.nhaXuatBan = string.Empty;
            this.soBan = 0;
        }
    }

    class Sach : TaiLieu
    {
        public string tacGia { set; get; }
        public int soTrang { set; get; }
        public Sach() 
        {
            this.tacGia = string.Empty;
            this.soTrang = 0;
        }
        public Sach(string _matailieu, string _nhaxuatban, int _soban, string _tacgia, int _sotrang)
        {
            this.maTaiLieu = _matailieu;
            this.nhaXuatBan = _nhaxuatban;
            this.soBan = _soban;
            this.tacGia = _tacgia;
            this.soTrang = _sotrang;
        }
    }

    class TapChi : TaiLieu
    {
        public int soPhatHanh { set; get; }
        public int thangPhatHanh { set; get; }
        public TapChi() 
        {
            this.soPhatHanh = 0;
            this.thangPhatHanh = 0;
        }
        public TapChi(string _matailieu, string _nhaxuatban, int _soban, int _sophathanh, int _thangphathanh)
        {
            this.maTaiLieu = _matailieu;
            this.nhaXuatBan = _nhaxuatban;
            this.soBan = _soban;
            this.soPhatHanh = _sophathanh;
            this.thangPhatHanh = _thangphathanh;
        }
    }
    class Bao : TaiLieu
    {
        public int ngayPhatHanh { set; get; }
        public Bao() 
        {
            this.ngayPhatHanh = 0;
        }
        public Bao(string _matailieu, string _nhaxuatban, int _soban, int _ngayphathanh)
        {
            this.maTaiLieu = _matailieu;
            this.nhaXuatBan = _nhaxuatban;
            this.soBan = _soban;
            this.ngayPhatHanh= _ngayphathanh;
        }
    }
}

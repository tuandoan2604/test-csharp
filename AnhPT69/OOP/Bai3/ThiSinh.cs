using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThiSinhNS
{
    internal class ThiSinh
    {
        public int soBaoDanh { set; get; }
        public string hoTen { set; get; }
        public string diaChi { set; get; }
        public int mucUuTien { set; get; }
        public string khoiThi { set; get; }
        public ThiSinh(int _sbd, string _hoten, string _diachi, int _mucuutien, string _khoithi) 
        {
            this.soBaoDanh = _sbd;
            this.hoTen = _hoten;
            this.diaChi = _diachi;
            this.mucUuTien = _mucuutien;
            this.khoiThi = _khoithi;
        }
    }

}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanBoNS
{
    public class CanBo
    {
        //Data
        private string hoTen;
        private int tuoi;
        private string gioiTinh;
        private string diaChi;

        //Propertise
        public string HoTen
        {
            set { hoTen = value; }

            get { return hoTen; }
        }

        public int Tuoi
        {
            set { tuoi = value; }

            get { return tuoi; }
        }

        public string GioiTinh
        {
            set { gioiTinh = value; }

            get { return gioiTinh; }
        }

        public string DiaChi
        {
            set { diaChi = value; }

            get { return diaChi; }
        }

        //Initial Method
        public CanBo() 
        {
            this.hoTen = string.Empty;
            this.tuoi = 0;
            this.gioiTinh= string.Empty;
            this.diaChi = string.Empty;
        }
    }
    public class CongNhan : CanBo
    {
        //Data
        private int bac;

        //Propertise
        public int Bac
        {
            set { bac = value; }
            get { return bac; }
        }

        //Contructor
        public CongNhan() 
        {
            this.bac = 0;
        }
        public CongNhan(string _hoten, int _tuoi, string _gioitinh, string _diachi, int _bac)
        {
            this.HoTen = _hoten;
            this.Tuoi = _tuoi;
            this.GioiTinh = _gioitinh;
            this.DiaChi = _diachi;
            this.Bac = _bac;
        }
    }
    public class KySu : CanBo
    {
        //Data
        private string nganh;

        //Propertise
        public string Nganh
        {
            set { nganh = value; }
            get { return nganh; }
        }

        //Contructor
        public KySu() 
        {
            this.nganh = string.Empty;
        }
        public KySu(string _hoten, int _tuoi, string _gioitinh, string _diachi, string _nganh)
        {
            this.HoTen = _hoten;
            this.Tuoi = _tuoi;
            this.GioiTinh = _gioitinh;
            this.DiaChi = _diachi;
            this.Nganh = _nganh;
        }
    }
    public class NhanVien : CanBo
    {
        //Data
        private string congViec;

        //Propertise
        public string CongViec
        {
            set { congViec = value; }
            get { return congViec; }
        }

        //Contructor
        public NhanVien() 
        {
            this.congViec = string.Empty;
        }
        public NhanVien(string _hoten, int _tuoi, string _gioitinh, string _diachi, string _congviec)
        {
            this.HoTen = _hoten;
            this.Tuoi = _tuoi;
            this.GioiTinh = _gioitinh;
            this.DiaChi = _diachi;
            this.CongViec = _congviec;
        }

    }
}

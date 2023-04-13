using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace OOP1
{
    public class CanBo
    {
        public CanBo(string _HoTen, int _Tuoi, string _GioiTinh, string _DiaChi)
        {
           HoTen= _HoTen;
           Tuoi = _Tuoi;
           GioiTinh= _GioiTinh;
           DiaChi= _DiaChi;
        }
        public string HoTen { get; set; }
        public int Tuoi { get; set; }
        public string GioiTinh { get; set; }
        public string DiaChi { get; set; }
    }
    public class CongNhan: CanBo
    {
        public CongNhan(string HoTen, int Tuoi, string GioiTinh, string DiaChi, int _Bac): base(HoTen, Tuoi, GioiTinh, DiaChi)
        {
            Bac = _Bac;
        }
        public int Bac { get; set; }
    }
    public class KySu: CanBo
    {
        public KySu(string HoTen, int Tuoi, string GioiTinh, string DiaChi, string _NganhDaoTao) : base(HoTen, Tuoi, GioiTinh, DiaChi)
        {
            NganhDaoTao = _NganhDaoTao;
        }
        public string NganhDaoTao { get; set; }
    }
    public class NhanVien: CanBo
    {
        public NhanVien(string HoTen, int Tuoi, string GioiTinh, string DiaChi, string _CongViec) : base(HoTen, Tuoi, GioiTinh, DiaChi)
        {
            CongViec = _CongViec;
        }
        public string CongViec { get; set; }
    }
    public class QLCB
    {
        public List<CanBo> _canbo = new List<CanBo>();
        public void ThemMoiCanBo(CanBo canBo)
        {
            _canbo.Add(canBo);
        }
        public List<CanBo> TimKiemTheoHoTen(string hoten)
        {
            List<CanBo> dscb = new List<CanBo>();
            foreach(var item in _canbo)
            {
                if (item.HoTen.Contains(hoten))
                {
                    dscb.Add(item);
                }
            }
            return dscb;
        }
        public void HienThongTinDanhSachCanBo()
        {
            foreach(var item in _canbo)
            {
                Console.WriteLine($"Ho Ten: {item.HoTen} - Tuoi: {item.Tuoi} - Gioi Tinh: {item.GioiTinh} - Dia Chi: {item.DiaChi}");
            }
        }
        public void Exit()
        {
            return;

        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            QLCB a = new QLCB();
            a.ThemMoiCanBo(new CanBo("Nguyen Van A", 19, "Nam", "Ha Noi"));
            a.ThemMoiCanBo(new CanBo("Nguyen Van B", 19, "Nam", "Ha Noi"));
            a.ThemMoiCanBo(new CanBo("Nguyen Van C", 19, "Nam", "Ha Noi"));
            a.ThemMoiCanBo(new CanBo("Nguyen Van D", 19, "Nam", "Ha Noi"));
            a.HienThongTinDanhSachCanBo();
            foreach(var item in a.TimKiemTheoHoTen("Nguyen"))
            {
                Console.WriteLine($"Ho Ten: {item.HoTen} - Tuoi: {item.Tuoi} - Gioi Tinh: {item.GioiTinh} - Dia Chi: {item.DiaChi}");

            }

        }
    }
}

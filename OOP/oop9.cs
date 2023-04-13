using System;
using System.Collections.Generic;

namespace OOP9
{
    class KhachHang
    {
        public string HoTenChuHo;
        public int SoNha;
        public string MaCongToDien;
        public KhachHang(string _HoTenChuHo, int _SoNha, string _MaCongToDien) {
            HoTenChuHo= _HoTenChuHo;
            SoNha= _SoNha;
            MaCongToDien= _MaCongToDien;
        }
    }
    class HoDan: KhachHang {
        public int ChiSoDienCu;
        public int ChiSoDienMoi;
        public int SoTienPhaiTra;
        public HoDan(int _ChiSoDienCu, int _ChiSoDienMoi, int _SoTienPhaiTra, string _HoTenChuHo,
        int _SoNha, string _MaCongToDien): base(_HoTenChuHo, _SoNha, _MaCongToDien)
        {
            ChiSoDienCu= _ChiSoDienCu;
            ChiSoDienMoi= _ChiSoDienMoi;
            SoTienPhaiTra= _SoTienPhaiTra;
        }
        public int TinhTienDien()
        {
            return ChiSoDienMoi - ChiSoDienCu;
        }
    }
    class BienLai
    {
        public List<HoDan> HoDan { get; set; }
        public BienLai()
        {
            HoDan = new List<HoDan>();
        }
        public void Them(ref HoDan a)
        {
            HoDan.Add(a);
        }
        public void Xoa(ref HoDan a)
        {
            HoDan.Remove(a);
        }
        public void Sua(ref HoDan hodancu, HoDan hodanmoi)
        {
            for(int i = 0; i < HoDan.Count; i++)
            {
                if (HoDan[i] == hodancu)
                {
                    HoDan[i] = hodanmoi;
                    break;
                }
            }
        }
        
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            BienLai a = new BienLai();
            HoDan hodan = new HoDan(10, 100, 10000, "Nguyen A", 22, "fdsss");
            a.Them(ref hodan);
            a.Sua(ref hodan, new HoDan(20, 100, 10000, "Nguyen A", 22, "fdsss"));
            foreach(var item in a.HoDan)
            {
                Console.WriteLine(item.TinhTienDien());
            }
        }
    }
}

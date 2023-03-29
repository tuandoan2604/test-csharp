using CanBoNS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaiLieuNS;

namespace QuanLySachNS
{
    internal class QuanLySach
    {
        private List<TaiLieu> list = new List<TaiLieu>()
        {
            new  Sach("abc", "xyz", 1, "AZX", 100),
            new TapChi("cad", "yhg", 2, 10, 12),
            new Bao("rfa", "ụh", 9, 31)
        };
        

        public void ThemMoi()
        {
            Console.Write("Nhập loại tài liệu (s, tc, b): "); string loai = Console.ReadLine();
            Console.Write("Nhập mã tài liệu: "); string matailieu = Console.ReadLine();
            Console.Write("Nhập nhà xuất bản: "); string nhaxuatban = Console.ReadLine();
            Console.Write("Nhập số bản phát hành: "); int soban = int.Parse(Console.ReadLine());
            switch (loai)
            {
                case "s":
                    {
                        Console.Write("Nhập tên tác giả: "); string tentacgia = Console.ReadLine();
                        Console.Write("Nhập số trang: "); int sotrang = int.Parse(Console.ReadLine());
                        Sach s = new Sach(matailieu, nhaxuatban, soban, tentacgia, sotrang);
                        list.Add(s);
                    }
                    break;

                case "tc":
                    {
                        Console.Write("Nhập số phát hành: "); int sophathanh = int.Parse(Console.ReadLine());
                        Console.Write("Nhập tháng phát hành: "); int thangphathanh = int.Parse(Console.ReadLine());
                        TapChi tc = new TapChi(matailieu, nhaxuatban, soban, sophathanh, thangphathanh);
                        list.Add(tc);
                    }
                    break;

                case "b":
                    {
                        Console.Write("Nhập ngày phát hành: "); int ngayphathanh = int.Parse(Console.ReadLine());
                        Bao b = new Bao(matailieu, nhaxuatban, soban, ngayphathanh);
                        list.Add(b);
                    }
                    break;

                default:
                    break;
            }
        }
        public void XoaTaiLieu(string matailieu)
        {
            int n = list.Count;
            bool check = false;
            for (int i = 0; i < n; i++) 
            {
                if (list[i].maTaiLieu == matailieu) 
                {
                    list.RemoveAt(i);
                    check = true;
                    break;
                }
            }

            if (check)
            {
                Console.WriteLine("Tài liệu có mã {0} đã được xóa ", matailieu);
            }
            else
            {
                Console.WriteLine("Không có mã tài liệu trên ");
            }
        }
        public void HienThiTaiLieu()
        {
            foreach (var tl in list)
            {
                Console.WriteLine("Mã tài liệu: {0}", tl.maTaiLieu); 
                Console.WriteLine("Nhà xuất bản: {0}", tl.nhaXuatBan); 
                Console.WriteLine("Số bản phát hành: {0}", tl.soBan); 
                switch (tl)
                {
                    case Sach:
                        {
                            Sach temp = (Sach)tl;
                            Console.WriteLine("Tên tác giả: {0}", temp.tacGia);
                            Console.WriteLine("Số trang: {0}", temp.soTrang);
                        }
                        break;

                    case TapChi:
                        {
                            TapChi temp = (TapChi)tl;
                            Console.WriteLine("Số phát hành: {0}", temp.soPhatHanh);
                            Console.WriteLine("Tháng phát hành: {0}", temp.thangPhatHanh);
                        }
                        break;

                    case Bao:
                        {
                            Bao temp = (Bao)tl;
                            Console.WriteLine("Ngày phát hành: {0}", temp.ngayPhatHanh);
                        }
                        break;
                }

                Console.WriteLine("------------------------------------");

            }
        }
        public void HienThiTaiLieu(List<TaiLieu> _list)
        {
            foreach (var tl in _list)
            {
                Console.WriteLine("Mã tài liệu: {0}", tl.maTaiLieu);
                Console.WriteLine("Nhà xuất bản: {0}", tl.nhaXuatBan);
                Console.WriteLine("Số bản phát hành: {0}", tl.soBan);
                switch (tl)
                {
                    case Sach:
                        {
                            Sach temp = (Sach)tl;
                            Console.WriteLine("Tên tác giả: {0}", temp.tacGia);
                            Console.WriteLine("Số trang: {0}", temp.soTrang);
                        }
                        break;

                    case TapChi:
                        {
                            TapChi temp = (TapChi)tl;
                            Console.WriteLine("Số phát hành: {0}", temp.soPhatHanh);
                            Console.WriteLine("Tháng phát hành: {0}", temp.thangPhatHanh);
                        }
                        break;

                    case Bao:
                        {
                            Bao temp = (Bao)tl;
                            Console.WriteLine("Ngày phát hành: {0}", temp.ngayPhatHanh);
                        }
                        break;
                }

                Console.WriteLine("------------------------------------");

            }
        }
        public List<TaiLieu> TimKiemTheoLoai(string _loai)
        {
            List<TaiLieu> result = new List<TaiLieu>();
            string loai = "";
            switch (_loai)
            {
                case "s":
                    loai = "TaiLieuNS.Sach";
                    break;
                case "tc":
                    loai = "TaiLieuNS.TapChi";
                    break;
                case "b":
                    loai = "TaiLieuNS.Bao";
                    break;           
            }

            foreach (var tl in list)
            {
                if (tl.GetType().ToString() == loai)
                {
                    result.Add(tl);
                }
            }
            return result;
        }
    }
}

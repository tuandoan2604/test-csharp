using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using CanBoNS;

namespace QLCBNS
{
    public class QLCB
    {
        private List<CanBo> list = new List<CanBo>() { };

        public QLCB() 
        {
            CongNhan cn1 = new CongNhan("Nguyễn Văn A", 25, "Nam", "Hà Nội", 2);
            KySu ks1 = new KySu("Nguyễn Văn B", 30, "Nam", "Thái Nguyên", "Cơ Điện Tử");
            NhanVien nv1 = new NhanVien("Nguyễn Thị C", 29, "Nữ", "Hà Nội", "Kế Toán");

            list.Add(cn1);
            list.Add(ks1);
            list.Add(nv1);
        }
        //Method
        public void ThemCanBo()
        {
            Console.Write("Nhập loại cán bộ (cn, ks, nv): "); string loai = Console.ReadLine();
            Console.Write("Nhập họ tên: "); string hoten = Console.ReadLine();
            Console.Write("Nhập tuổi: "); int tuoi = int.Parse(Console.ReadLine());
            Console.Write("Nhập giới tính: "); string gioitinh = Console.ReadLine();
            Console.Write("Nhập địa chỉ: "); string diachi = Console.ReadLine(); 
            switch (loai)
            {
                case "cn":
                    {
                        Console.Write("Nhập bậc công nhân: "); int bac = int.Parse(Console.ReadLine());
                        CongNhan cn = new CongNhan(hoten, tuoi, gioitinh, diachi, bac);
                        list.Add(cn);
                    }
                    break;

                case "ks":
                    {
                        Console.Write("Nhập ngành kỹ sư: "); string nganh = Console.ReadLine();
                        KySu ks = new KySu(hoten, tuoi, gioitinh, diachi, nganh);
                        list.Add(ks);
                    }
                    break;

                case "nv":
                    {
                        Console.Write("Nhập công việc nhân viên: "); string congviec = Console.ReadLine();
                        NhanVien nv = new NhanVien(hoten, tuoi, gioitinh, diachi, congviec);
                        list.Add(nv);
                    }
                    break;

                default:
                    break;
            }    

        }

        public List<CanBo> TimKiemTheoHoTen(string _hoten) 
        {
            List<CanBo> result = new List<CanBo>();

            foreach (var cb in list) 
            {
                if(cb.HoTen.Contains(_hoten))
                {
                    result.Add(cb);
                }    
            }

            return result;
        }

        public void ThongTinCanBo() 
        {
            Console.OutputEncoding = UTF8Encoding.UTF8;
            foreach (var c in list)
            {
                Console.WriteLine("Tên: {0}", c.HoTen);
                Console.WriteLine("Tuổi: {0}", c.Tuoi);
                Console.WriteLine("Giới tính: {0}", c.GioiTinh);
                Console.WriteLine("Địa chỉ: {0}", c.DiaChi);
                switch (c)
                {
                    case CongNhan:
                        {
                            CongNhan temp = (CongNhan)c;
                            Console.WriteLine("Cấp bậc: {0}", temp.Bac);
                        }
                        break;

                    case KySu:
                        {
                            KySu temp = (KySu)c;
                            Console.WriteLine("Chuyên ngành: {0}", temp.Nganh);
                        }
                        break;

                    case NhanVien:
                        {
                            NhanVien temp = (NhanVien)c;
                            Console.WriteLine("Công việc: {0}", temp.CongViec);
                        }
                        break;
                }

                Console.WriteLine("------------------------------------");

            }
        }

        public void ThongTinCanBo(List<CanBo> _list)
        {
            
            foreach (var c in _list)
            {
                Console.WriteLine("Tên: {0}", c.HoTen);
                Console.WriteLine("Tuổi: {0}", c.Tuoi);
                Console.WriteLine("Giới tính: {0}", c.GioiTinh);
                Console.WriteLine("Địa chỉ: {0}", c.DiaChi);
                switch (c)
                {
                    case CongNhan:
                        {
                            CongNhan temp = (CongNhan)c;
                            Console.WriteLine("Cấp bậc: {0}", temp.Bac);
                        }
                        break;

                    case KySu:
                        {
                            KySu temp = (KySu)c;
                            Console.WriteLine("Chuyên ngành: {0}", temp.Nganh);
                        }
                        break;

                    case NhanVien:
                        {
                            NhanVien temp = (NhanVien)c;
                            Console.WriteLine("Công việc: {0}", temp.CongViec);
                        }
                        break;
                }

                Console.WriteLine("------------------------------------");

            }
        }

        public void ThoatChuongTrinh()
        {

        }
    }
}

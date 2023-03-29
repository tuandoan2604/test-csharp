using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaiLieuNS;
using ThiSinhNS;

namespace TuyenSinhNS
{
    internal class TuyenSinh
    {
        List<ThiSinh> list = new List<ThiSinh>()
        {
            new ThiSinh(9121, "ABC", "QAZ", 3, "A"),
            new ThiSinh(9151, "BFG", "JHN", 1, "B"),
            new ThiSinh(9586, "RDC", "IKM", 2, "C")
        };
        public void ThemMoi()
        {
            int sbd = int.Parse(NhapLieu("số báo danh"));
            string hoten = NhapLieu("họ tên");
            string diachi = NhapLieu("địa chỉ");
            int muc = int.Parse(NhapLieu("mức ưu tiên"));
            string khoithi = NhapLieu("khối thi");
            
            ThiSinh ts = new ThiSinh(sbd, hoten, diachi, muc, khoithi);
            
            list.Add(ts);
        }
        public void HienThi()
        {
            foreach (ThiSinh ts in list) 
            {
                string temp = (ts.khoiThi == "A") ? "Toán, Lý, Hóa" :
                                (ts.khoiThi == "B") ? "Toán, Hóa, Sinh" : "Văn, Sử, Địa";

                Console.Write($"{ts.soBaoDanh} | {ts.hoTen} | {ts.diaChi} | {ts.mucUuTien} | Khối thi: {ts.khoiThi} - {temp}\n");
            }
        }

        public void TimKiemSBD(int _sbd)
        {
            foreach(ThiSinh ts in list) 
            {
                if (ts.soBaoDanh == _sbd)
                {
                    string temp = (ts.khoiThi == "A") ? "Toán, Lý, Hóa" :
                                (ts.khoiThi == "B") ? "Toán, Hóa, Sinh" : "Văn, Sử, Địa";

                    Console.Write($"{ts.soBaoDanh} | {ts.hoTen} | {ts.diaChi} | {ts.mucUuTien} | Khối thi: {ts.khoiThi} - {temp}\n");

                    break;
                }    
            }
        }

        string NhapLieu(string nd)
        {
            Console.Write("Nhập {0}: ", nd);
            return Console.ReadLine();
        }
    }
}

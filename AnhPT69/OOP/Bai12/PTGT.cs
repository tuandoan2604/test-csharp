using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTGTNS
{
    internal class PhuongTien
    {
        public string loaiPT { set; get; }
        public int ID { set; get; }
        public string hangSX { set; get; }
        public int namSX { set; get;}
        public double giaBan { set; get; }
        public string mauXe { set; get; }
        public PhuongTien() { }
        public void Extend()
        {

        }
    }
    class OTO : PhuongTien
    {
        private int soChoNgoi;
        private string kieuDC;
        public OTO() { }
        public OTO(string _loaipt, int _id, string _hangsx, int _namsx, double _giaban, string _mauxe, int _socho, string _kieudc) 
        {
            loaiPT = _loaipt;
            ID = _id;
            hangSX = _hangsx;
            namSX = _namsx;
            giaBan = _giaban;
            mauXe = _mauxe;
            soChoNgoi = _socho;
            kieuDC = _kieudc;
        }
        public void ThongTinOTO()
        {
            HienThi("Loại phương tiện", loaiPT);
            HienThi("ID", ID.ToString());
            HienThi("Hãng sản xuất", hangSX);
            HienThi("Năm sản xuất", namSX.ToString());
            HienThi("Giá bán", giaBan.ToString());
            HienThi("Màu xe", mauXe);
            HienThi("Số chỗ ngồi", soChoNgoi.ToString());
            HienThi("Kiểu động cơ", kieuDC.ToString());
        }
        public void HienThi(string title, string content)
        {
            Console.WriteLine($"{title}: {content}");
        }
    }
    class XeMay : PhuongTien
    {
        private int congSuat;
        public XeMay() { }
        public XeMay(string _loaipt, int _id, string _hangsx, int _namsx, double _giaban, string _mauxe, int _congsuat)
        {
            loaiPT = _loaipt;
            ID = _id;
            hangSX = _hangsx;
            namSX = _namsx;
            giaBan = _giaban;
            mauXe = _mauxe;
            congSuat = _congsuat;
        }
        public void ThongTinXeMay()
        {
            HienThi("Loại phương tiện", loaiPT);
            HienThi("ID", ID.ToString());
            HienThi("Hãng sản xuất", hangSX);
            HienThi("Năm sản xuất", namSX.ToString());
            HienThi("Giá bán", giaBan.ToString());
            HienThi("Màu xe", mauXe);
            HienThi("Công suất", congSuat.ToString());
        }
        public void HienThi(string title, string content)
        {
            Console.WriteLine($"{title}: {content}");
        }
    }
    class XeTai : PhuongTien
    {
        private int trongTai;
        public XeTai() { }
        public XeTai(string _loaipt, int _id, string _hangsx, int _namsx, double _giaban, string _mauxe, int _trongtai)
        {
            HienThi("Loại phương tiện", loaiPT);
            loaiPT = _loaipt;
            ID = _id;
            hangSX = _hangsx;
            namSX = _namsx;
            giaBan = _giaban;
            mauXe = _mauxe;
            trongTai = _trongtai;
        }
        public void ThongTinXeTai()
        {
            HienThi("ID", ID.ToString());
            HienThi("Hãng sản xuất", hangSX);
            HienThi("Năm sản xuất", namSX.ToString());
            HienThi("Giá bán", giaBan.ToString());
            HienThi("Màu xe", mauXe);
            HienThi("Trọng tải", trongTai.ToString());
        }
        public void HienThi(string title, string content)
        {
            Console.WriteLine($"{title}: {content}");
        }
    }
    class QLPTGT
    {
        public List<PhuongTien> pt;
        public QLPTGT()
        {
            pt = new List<PhuongTien>();
        }
        public void ThemPT()
        {
            string loaipt = NhapLieu("loại phương tiện (ot, xm, xt)");
            int id = int.Parse(NhapLieu("id"));
            string hang = NhapLieu("hãng sản xuất");
            int nam = int.Parse(NhapLieu("năm sản xuất"));
            double gia = double.Parse(NhapLieu("giá bán"));
            string mau = NhapLieu("màu xe");
            switch(loaipt) 
            {
                case "ot":
                    {
                        int socho = int.Parse(NhapLieu("số chỗ ngồi"));
                        string kieudc = NhapLieu("kiểu động cơ");
                        OTO ot = new OTO("Ô Tô", id, hang, nam, gia, mau, socho, kieudc);
                        pt.Add(ot);
                    }
                    break;
                case "xm":
                    {
                        int cs = int.Parse(NhapLieu("công suất"));
                        XeMay xm = new XeMay("Xe Máy", id, hang, nam, gia, mau, cs);
                        pt.Add(xm);
                    }
                    break;
                case "xt":
                    {
                        int tt = int.Parse(NhapLieu("trọng tải"));
                        XeTai xt = new XeTai("Xe Tải", id, hang, nam, gia, mau, tt);
                        pt.Add(xt);
                    }
                    break;
                default:
                    break;
            }
        }
        public void XoaPT(int id)
        {
            (int i, bool check) = TimKiemID(id);
            if (check)
            {
                pt.RemoveAt(i);
                Console.WriteLine("Đã xóa phương tiện có ID: {0}", id);
            }
            else
                Console.WriteLine("Không có phương tiện mang ID: {0}", id);
        }
        public void TimKiemPT(string hangsx = "", string mauxe = "")
        {
            List<PhuongTien> list = new List<PhuongTien>();

            foreach(PhuongTien i in pt)
            {
                if (hangsx == "")
                {
                    if (i.mauXe == mauxe)
                    {
                        list.Add(i);
                    }    
                }
                else if (mauxe == "")
                {
                    if (i.hangSX == hangsx)
                    {
                        list.Add(i);
                    }
                }
                else
                {
                    if (i.hangSX == hangsx && i.mauXe == mauxe)
                    {
                        list.Add(i);
                    }
                }    
            }  
            
            if(list.Count > 0)
            {
                foreach(PhuongTien j in list)
                {
                    if (j.loaiPT == "Ô Tô")
                    {
                        OTO temp = (OTO)j;
                        temp.ThongTinOTO();
                    }
                    else if (j.loaiPT == "Xe Máy")
                    {
                        XeMay temp = (XeMay)j;
                        temp.ThongTinXeMay();
                    }
                    else
                    {
                        XeTai temp = (XeTai)j;
                        temp.ThongTinXeTai();
                    }    
                }    
            }    
        }
        public Tuple<int, bool> TimKiemID(int id)
        {
            int i = 0;
            bool check = false;
            for (i = 0; i < pt.Count; i++)
            {
                if (pt[i].ID == id)
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace SoPhucNS
{
    internal class SoPhuc
    {
        private double phanThuc;
        private double phanAo;
        public SoPhuc() 
        {
            phanThuc = 0;
            phanAo = 0;
        }
        public SoPhuc(double _phanthuc, double _phanao)
        {
            phanThuc = _phanthuc;
            phanAo = _phanao;
        }
        public void NhapSoPhuc()
        {
            double thuc = double.Parse(NhapLieu("phần thực"));
            double ao = double.Parse(NhapLieu("phần ảo"));
            
            phanThuc = thuc;
            phanAo = ao;

            Console.WriteLine($"Số phức bạn vừa nhập là {phanThuc}+{phanAo}i");
        }
        public void HienThiSoPhuc()
        {
            Console.WriteLine($"Số phức này là {phanThuc}+{phanAo}i");
        }
        public static SoPhuc operator +(SoPhuc a, SoPhuc b)
        {
            SoPhuc  p = new SoPhuc();
            p.phanThuc = a.phanThuc + b.phanThuc;
            p.phanAo = a.phanAo + b.phanAo;
            return p;
        }
        public static SoPhuc operator *(SoPhuc a, SoPhuc b)
        {
            SoPhuc p = new SoPhuc();
            p.phanThuc = (a.phanThuc * b.phanThuc - a.phanAo * b.phanAo);
            p.phanAo = (a.phanThuc * b.phanAo + a.phanAo * b.phanThuc);
            return p;
        }
        string NhapLieu(string mes)
        {
            Console.Write("Nhập {0}:", mes);
            return Console.ReadLine();
        }
    }
}
